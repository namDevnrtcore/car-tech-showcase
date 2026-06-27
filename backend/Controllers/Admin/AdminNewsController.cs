using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;
using CarTechShowcase.Models;

namespace CarTechShowcase.Controllers.Admin;

[Route("Admin/News")]
public class AdminNewsController : AdminBaseController
{
    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;
    public AdminNewsController(AppDbContext db, IWebHostEnvironment env) { _db = db; _env = env; }

    [HttpGet("")]
    public async Task<IActionResult> Index(string? search)
    {
        ViewData["Title"] = "Quản lý tin tức";
        ViewBag.Search = search ?? "";

        var query = _db.News.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(n => n.Title!.Contains(search));

        var news = await query.OrderByDescending(n => n.CreatedAt).ToListAsync();
        return View("~/Views/Admin/News/Index.cshtml", news);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        ViewData["Title"] = "Thêm tin tức";
        return View("~/Views/Admin/News/Create.cshtml", new News());
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(News model)
    {
        ModelState.Remove("Id");
        model.CreatedAt = DateTime.Now;
        model.IsActive  = true;
        _db.News.Add(model);
        await _db.SaveChangesAsync();
        TempData["Success"] = $"Đã thêm bài viết \"{model.Title}\"!";
        return Redirect("/Admin/News");
    }

    [HttpGet("Edit/{id:int}")]
    public async Task<IActionResult> Edit(int id)
    {
        var news = await _db.News.FindAsync(id);
        if (news == null) return NotFound();
        ViewData["Title"] = "Sửa tin tức";
        return View("~/Views/Admin/News/Edit.cshtml", news);
    }

    [HttpPost("Edit/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, News model)
    {
        if (id != model.Id) return BadRequest();
        ModelState.Remove("Id");
        _db.News.Update(model);
        await _db.SaveChangesAsync();
        TempData["Success"] = $"Đã cập nhật bài viết \"{model.Title}\"!";
        return Redirect("/Admin/News");
    }

    [HttpPost("Delete/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var news = await _db.News.FindAsync(id);
        if (news != null)
        {
            _db.News.Remove(news);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã xóa bài viết \"{news.Title}\"!";
        }
        return Redirect("/Admin/News");
    }

    [HttpPost("UploadImage")]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> UploadImage(IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return Ok(new { success = false, error = "Không có file" });

        var ext = Path.GetExtension(file.FileName).ToLower();
        if (ext is not ".jpg" and not ".jpeg" and not ".png" and not ".webp" and not ".gif")
            return Ok(new { success = false, error = "Chỉ chấp nhận JPG, PNG, WebP, GIF" });

        var fileName = $"news-{Guid.NewGuid():N}{ext}";
        var savePath = Path.Combine(_env.WebRootPath, "images", fileName);
        Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);
        using var stream = System.IO.File.Create(savePath);
        await file.CopyToAsync(stream);
        return Ok(new { success = true, path = $"/images/{fileName}" });
    }

    [HttpPost("Toggle/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Toggle(int id)
    {
        var news = await _db.News.FindAsync(id);
        if (news != null)
        {
            news.IsActive = !news.IsActive;
            await _db.SaveChangesAsync();
            TempData["Success"] = news.IsActive
                ? $"\"{news.Title}\" đã hiển thị."
                : $"\"{news.Title}\" đã ẩn.";
        }
        return Redirect("/Admin/News");
    }
}
