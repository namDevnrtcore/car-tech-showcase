using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using CarTechShowcase.Data;
using CarTechShowcase.Models;

namespace CarTechShowcase.Controllers.Admin;

[Route("Admin/Products")]
public class AdminProductsController : AdminBaseController
{
    private static readonly string[] Categories = new[]
    {
        "Camera Hành Trình",
        "Camera Nghị Định 10",
        "Màn Hình Android",
        "Màn Hình Android Ô Tô",
    };

    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;

    public AdminProductsController(AppDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index(string? search, string? category, int pg = 1)
    {
        const int pageSize = 10;
        ViewData["Title"]  = "Quản lý sản phẩm";
        ViewBag.Search     = search ?? "";
        ViewBag.Category   = category ?? "";
        ViewBag.Categories = Categories;

        var query = _db.Products.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(p => p.ProductName.Contains(search));
        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(p => p.Category == category);

        int total      = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(total / (double)pageSize);
        pg             = Math.Clamp(pg, 1, Math.Max(1, totalPages));

        ViewBag.Page       = pg;
        ViewBag.TotalPages = totalPages;
        ViewBag.Total      = total;

        var products = await query
            .OrderByDescending(p => p.Id)
            .Skip((pg - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return View("~/Views/Admin/Products/Index.cshtml", products);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        ViewData["Title"] = "Thêm sản phẩm";
        ViewBag.Categories = Categories;
        return View("~/Views/Admin/Products/Create.cshtml", new Product());
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product model)
    {
        ModelState.Remove("Id");
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = Categories;
            return View("~/Views/Admin/Products/Create.cshtml", model);
        }
        model.IsActive = true;
        _db.Products.Add(model);
        await _db.SaveChangesAsync();
        TempData["Success"] = $"Đã thêm sản phẩm \"{model.ProductName}\" thành công!";
        return Redirect("/Admin/Products");
    }

    // ─── UPLOAD IMAGE ─────────────────────────────────────────────────────────
    [HttpPost("UploadImage")]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> UploadImage(IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return Ok(new { success = false, error = "Không có file" });

        var ext = Path.GetExtension(file.FileName).ToLower();
        if (ext is not ".jpg" and not ".jpeg" and not ".png" and not ".webp" and not ".gif")
            return Ok(new { success = false, error = "Chỉ chấp nhận JPG, PNG, WebP, GIF" });

        var fileName = $"product-{Guid.NewGuid():N}{ext}";
        var savePath = Path.Combine(_env.WebRootPath, "images", fileName);
        Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

        using var stream = System.IO.File.Create(savePath);
        await file.CopyToAsync(stream);

        return Ok(new { success = true, path = $"/images/{fileName}" });
    }

    // ─── SCRAPE FROM URL ───────────────────────────────────────────────────────
    [HttpPost("Scrape")]
    public async Task<IActionResult> Scrape([FromBody] ScrapeRequest req)
    {
        if (string.IsNullOrWhiteSpace(req?.Url) ||
            !Uri.TryCreate(req.Url.Trim(), UriKind.Absolute, out var uri) ||
            (uri.Scheme != "http" && uri.Scheme != "https"))
        {
            return Ok(new { success = false, error = "URL không hợp lệ" });
        }

        try
        {
            using var http = new HttpClient();
            http.Timeout = TimeSpan.FromSeconds(20);
            http.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 Chrome/124.0 Safari/537.36");
            http.DefaultRequestHeaders.Add("Accept-Language", "vi-VN,vi;q=0.9,en;q=0.8");

            var html = await http.GetStringAsync(uri);
            var doc  = new HtmlDocument();
            doc.LoadHtml(html);

            string name = "", description = "", spec = "", imageUrl = "";
            decimal price = 0;

            // ── 1. JSON-LD structured data ─────────────────────────────────
            foreach (var ldNode in doc.DocumentNode.SelectNodes("//script[@type='application/ld+json']") ?? Enumerable.Empty<HtmlNode>())
            {
                try
                {
                    var root = JsonDocument.Parse(ldNode.InnerText).RootElement;
                    // Handle both root object and @graph array
                    JsonElement product = default;
                    if (root.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var el in root.EnumerateArray())
                            if (el.TryGetProperty("@type", out var t) && t.GetString()?.Contains("Product") == true)
                            { product = el; break; }
                    }
                    else if (root.TryGetProperty("@type", out var t) && t.GetString()?.Contains("Product") == true)
                        product = root;
                    else if (root.TryGetProperty("@graph", out var graph))
                    {
                        foreach (var el in graph.EnumerateArray())
                            if (el.TryGetProperty("@type", out var t2) && t2.GetString()?.Contains("Product") == true)
                            { product = el; break; }
                    }

                    if (product.ValueKind != JsonValueKind.Undefined)
                    {
                        if (string.IsNullOrEmpty(name) && product.TryGetProperty("name", out var n))
                            name = n.GetString() ?? "";
                        if (string.IsNullOrEmpty(description) && product.TryGetProperty("description", out var d))
                            description = d.GetString() ?? "";

                        // Image
                        if (string.IsNullOrEmpty(imageUrl) && product.TryGetProperty("image", out var img))
                        {
                            imageUrl = img.ValueKind == JsonValueKind.Array
                                ? img.EnumerateArray().FirstOrDefault().GetString() ?? ""
                                : img.GetString() ?? "";
                        }

                        // Price from offers
                        if (price == 0 && product.TryGetProperty("offers", out var offers))
                        {
                            var offer = offers.ValueKind == JsonValueKind.Array
                                ? offers.EnumerateArray().FirstOrDefault()
                                : offers;
                            if (offer.TryGetProperty("price", out var p))
                                decimal.TryParse(p.GetRawText().Trim('"'), out price);
                        }
                        break;
                    }
                }
                catch { /* ignore bad JSON */ }
            }

            // ── 2. Open Graph / meta tags ─────────────────────────────────
            name        = name.Length > 0 ? name : GetMeta(doc, "og:title") ?? GetMeta(doc, "twitter:title") ?? "";
            description = description.Length > 0 ? description : GetMeta(doc, "og:description") ?? GetMeta(doc, "description") ?? "";
            imageUrl    = imageUrl.Length > 0 ? imageUrl : GetMeta(doc, "og:image") ?? "";

            if (price == 0)
            {
                var ogPrice = GetMeta(doc, "og:price:amount") ?? GetMeta(doc, "product:price:amount") ?? "";
                if (!string.IsNullOrEmpty(ogPrice)) decimal.TryParse(ogPrice, out price);
            }

            // ── 3. HTML selectors (WooCommerce + generic) ─────────────────
            if (string.IsNullOrEmpty(name))
            {
                name = (
                    doc.DocumentNode.SelectSingleNode("//h1[@class[contains(.,'product_title')]]") ??
                    doc.DocumentNode.SelectSingleNode("//h1[@class[contains(.,'entry-title')]]") ??
                    doc.DocumentNode.SelectSingleNode("//h1[@class[contains(.,'product-name')]]") ??
                    doc.DocumentNode.SelectSingleNode("//h1")
                )?.InnerText?.Trim() ?? "";
            }

            // Price
            if (price == 0)
            {
                var priceNode =
                    doc.DocumentNode.SelectSingleNode("//ins//span[contains(@class,'amount')]") ??
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'price')]//bdi") ??
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'woocommerce-Price-amount')]") ??
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'product-price')]") ??
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'price')]");
                if (priceNode != null)
                    price = ParseVietnamesePrice(priceNode.InnerText);
            }

            // Description
            if (string.IsNullOrEmpty(description))
            {
                var descNode =
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'woocommerce-product-details__short-description')]") ??
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'short-description')]") ??
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'product-description')]") ??
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'description')]");
                if (descNode != null)
                    description = HtmlEntity.DeEntitize(descNode.InnerText).Trim();
            }

            // Spec from table or list
            var specNodes = doc.DocumentNode.SelectNodes(
                "//*[contains(@class,'specifications')]//tr | //*[contains(@class,'spec')]//tr | //table[contains(@class,'shop_attribute')]//tr");
            if (specNodes != null && specNodes.Count > 0)
            {
                var specParts = specNodes
                    .Select(tr =>
                    {
                        var cells = tr.SelectNodes(".//th | .//td");
                        return cells != null && cells.Count >= 2
                            ? $"{cells[0].InnerText.Trim()}: {cells[1].InnerText.Trim()}"
                            : null;
                    })
                    .Where(s => s != null)
                    .Take(8);
                spec = string.Join(" | ", specParts);
            }

            // Image
            if (string.IsNullOrEmpty(imageUrl))
            {
                var imgNode =
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'woocommerce-product-gallery__image')]//img") ??
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'product-gallery')]//img") ??
                    doc.DocumentNode.SelectSingleNode("//*[contains(@class,'product-image')]//img") ??
                    doc.DocumentNode.SelectSingleNode("//article//img");
                imageUrl = imgNode?.GetAttributeValue("data-large_image",
                           imgNode.GetAttributeValue("data-src",
                           imgNode.GetAttributeValue("src", ""))) ?? "";
            }

            // Make image URL absolute
            if (!string.IsNullOrEmpty(imageUrl) && imageUrl.StartsWith("/"))
                imageUrl = $"{uri.Scheme}://{uri.Host}{imageUrl}";

            // Download image to wwwroot/images/
            string savedImgPath = "";
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    using var imgClient = new HttpClient();
                    imgClient.Timeout = TimeSpan.FromSeconds(10);
                    imgClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
                    var imgBytes = await imgClient.GetByteArrayAsync(imageUrl);
                    var ext      = Path.GetExtension(new Uri(imageUrl).LocalPath).ToLower();
                    if (ext is not ".jpg" and not ".jpeg" and not ".png" and not ".webp") ext = ".jpg";
                    var fileName = $"import-{Guid.NewGuid():N}{ext}";
                    var savePath = Path.Combine(_env.WebRootPath, "images", fileName);
                    await System.IO.File.WriteAllBytesAsync(savePath, imgBytes);
                    savedImgPath = $"/images/{fileName}";
                }
                catch { /* keep external URL if download fails */ }
            }

            // Clean up
            name        = HtmlEntity.DeEntitize(name).Trim();
            description = CleanText(description);
            if (description.Length > 1000) description = description[..1000];

            return Ok(new
            {
                success      = true,
                name,
                price,
                description,
                spec,
                imageUrl     = savedImgPath.Length > 0 ? savedImgPath : imageUrl,
                sourceUrl    = req.Url
            });
        }
        catch (TaskCanceledException)
        {
            return Ok(new { success = false, error = "Timeout — trang web phản hồi quá chậm" });
        }
        catch (HttpRequestException ex)
        {
            return Ok(new { success = false, error = $"Không thể kết nối: {ex.Message}" });
        }
        catch (Exception ex)
        {
            return Ok(new { success = false, error = ex.Message });
        }
    }

    // ─── EDIT ──────────────────────────────────────────────────────────────────
    [HttpGet("Edit/{id:int}")]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return NotFound();
        ViewData["Title"] = "Sửa sản phẩm";
        ViewBag.Categories = Categories;
        return View("~/Views/Admin/Products/Edit.cshtml", product);
    }

    [HttpPost("Edit/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product model)
    {
        if (id != model.Id) return BadRequest();
        ModelState.Remove("Id");
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = Categories;
            return View("~/Views/Admin/Products/Edit.cshtml", model);
        }
        _db.Products.Update(model);
        await _db.SaveChangesAsync();
        TempData["Success"] = $"Đã cập nhật sản phẩm \"{model.ProductName}\"!";
        return Redirect("/Admin/Products");
    }

    [HttpPost("Delete/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product != null)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã xóa sản phẩm \"{product.ProductName}\"!";
        }
        return Redirect("/Admin/Products");
    }

    [HttpPost("Toggle/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Toggle(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product != null)
        {
            product.IsActive = !product.IsActive;
            await _db.SaveChangesAsync();
            TempData["Success"] = product.IsActive
                ? $"\"{product.ProductName}\" đã hiển thị trên trang chính."
                : $"\"{product.ProductName}\" đã ẩn khỏi trang chính.";
        }
        return Redirect("/Admin/Products");
    }

    // ─── HELPERS ───────────────────────────────────────────────────────────────
    private static string? GetMeta(HtmlDocument doc, string property)
    {
        var node = doc.DocumentNode.SelectSingleNode($"//meta[@property='{property}']")
                ?? doc.DocumentNode.SelectSingleNode($"//meta[@name='{property}']");
        return node?.GetAttributeValue("content", null);
    }

    private static decimal ParseVietnamesePrice(string raw)
    {
        // "2.990.000 ₫" or "2,990,000" → 2990000
        var digits = Regex.Replace(raw, @"[^\d]", "");
        return decimal.TryParse(digits, out var val) ? val : 0;
    }

    private static string CleanText(string html)
    {
        if (string.IsNullOrEmpty(html)) return "";
        // Remove HTML tags and extra whitespace
        var plain = Regex.Replace(html, "<[^>]+>", " ");
        plain = HtmlEntity.DeEntitize(plain);
        plain = Regex.Replace(plain, @"\s{2,}", " ").Trim();
        return plain;
    }
}

public record ScrapeRequest(string? Url);
