using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;

namespace CarTechShowcase.Controllers.Admin;

[Route("Admin/Orders")]
public class AdminOrdersController : AdminBaseController
{
    private static readonly string[] Statuses = new[]
    {
        "Chờ xác nhận",
        "Đang xử lý",
        "Đang giao hàng",
        "Đã giao",
        "Đã hủy",
    };

    private readonly AppDbContext _db;
    public AdminOrdersController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index(string? status, string? search)
    {
        ViewData["Title"] = "Quản lý đơn hàng";
        ViewBag.Statuses = Statuses;
        ViewBag.Status   = status ?? "";
        ViewBag.Search   = search ?? "";

        var query = _db.Orders.AsQueryable();
        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(o => o.Status == status);
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(o =>
                (o.FullName != null && o.FullName.Contains(search)) ||
                (o.Phone    != null && o.Phone.Contains(search))    ||
                (o.ProductName != null && o.ProductName.Contains(search)));

        var orders = await query.OrderByDescending(o => o.CreatedAt).ToListAsync();
        return View("~/Views/Admin/Orders/Index.cshtml", orders);
    }

    [HttpPost("UpdateStatus/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, string newStatus)
    {
        var order = await _db.Orders.FindAsync(id);
        if (order != null)
        {
            order.Status = newStatus;
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đơn #{id} đã chuyển sang \"{newStatus}\".";
        }
        return Redirect("/Admin/Orders");
    }

    [HttpPost("Delete/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _db.Orders.FindAsync(id);
        if (order != null)
        {
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã xóa đơn hàng #{id}.";
        }
        return Redirect("/Admin/Orders");
    }
}
