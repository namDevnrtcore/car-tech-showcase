using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;

namespace CarTechShowcase.Controllers.Admin;

[Route("Admin/Dashboard")]
public class AdminDashboardController : AdminBaseController
{
    private readonly AppDbContext _db;
    public AdminDashboardController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Dashboard";
        ViewBag.ProductCount  = await _db.Products.CountAsync();
        ViewBag.ActiveProducts = await _db.Products.CountAsync(p => p.IsActive);
        ViewBag.NewsCount     = await _db.News.CountAsync();
        ViewBag.OrderCount    = await _db.Orders.CountAsync();
        ViewBag.PendingOrders = await _db.Orders.CountAsync(o =>
            o.Status == "Chờ xác nhận" || o.Status == "Đang xử lý" || o.Status == "Đang giao hàng");
        ViewBag.RecentOrders  = await _db.Orders
            .OrderByDescending(o => o.CreatedAt).Take(7).ToListAsync();
        return View("~/Views/Admin/Dashboard/Index.cshtml");
    }
}
