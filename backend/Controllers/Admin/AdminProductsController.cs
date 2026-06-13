using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public AdminProductsController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index(string? search, string? category)
    {
        ViewData["Title"] = "Quản lý sản phẩm";
        ViewBag.Search    = search ?? "";
        ViewBag.Category  = category ?? "";
        ViewBag.Categories = Categories;

        var query = _db.Products.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(p => p.ProductName.Contains(search));
        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(p => p.Category == category);

        var products = await query.OrderByDescending(p => p.Id).ToListAsync();
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
}
