using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;
using CarTechShowcase.Models;

namespace CarTechShowcase.Controllers.Mvc;

[Route("Order")]
public class OrderMvcController : Controller
{
    private readonly AppDbContext _db;
    public OrderMvcController(AppDbContext db) => _db = db;

    [HttpGet("{productId:int}")]
    public async Task<IActionResult> Create(int productId)
    {
        var product = await _db.Products.FindAsync(productId);
        if (product == null || !product.IsActive) return NotFound();
        ViewData["Title"] = $"Đặt hàng — {product.ProductName}";
        ViewBag.Product = product;
        return View("~/Views/Order/Create.cshtml");
    }

    [HttpPost("Submit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Submit(int productId, string fullName, string phone, int quantity)
    {
        var product = await _db.Products.FindAsync(productId);
        if (product == null) return BadRequest();

        long price = (long)(product.Price ?? 0);
        long total = price * (quantity < 1 ? 1 : quantity);

        var order = new Order
        {
            ProductName = product.ProductName,
            Price       = string.Format("{0:N0}", price),
            Quantity    = quantity < 1 ? 1 : quantity,
            TotalAmount = string.Format("{0:N0}", total),
            FullName    = fullName?.Trim(),
            Phone       = phone?.Trim(),
            Img         = product.Img,
            Status      = "Chờ xác nhận",
            CreatedAt   = DateTime.Now,
        };

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        TempData["OrderId"]     = order.Id;
        TempData["ProductName"] = order.ProductName;
        TempData["TotalAmount"] = order.TotalAmount;
        TempData["FullName"]    = order.FullName;
        return Redirect("/Order/Success");
    }

    [HttpGet("Success")]
    public IActionResult Success()
    {
        ViewData["Title"] = "Đặt hàng thành công";
        return View("~/Views/Order/Success.cshtml");
    }
}
