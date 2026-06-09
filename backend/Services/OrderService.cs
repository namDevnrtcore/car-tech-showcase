// ============================================
// 📁 Services/OrderService.cs
// ============================================

using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;
using CarTechShowcase.Models;
using CarTechShowcase.DTOs;

namespace CarTechShowcase.Services;

public class OrderService
{
    private readonly AppDbContext _db;
    public OrderService(AppDbContext db) => _db = db;

    public async Task<List<Order>> GetAllAsync() => await _db.Orders.OrderByDescending(o => o.CreatedAt).ToListAsync();
    public async Task<Order?> GetByIdAsync(int id) => await _db.Orders.FindAsync(id);

    public async Task<Order> CreateAsync(OrderCreateDto dto)
    {
        var order = new Order { ProductName = dto.ProductName, Price = dto.Price, Quantity = dto.Quantity, TotalAmount = dto.TotalAmount, FullName = dto.FullName, Phone = dto.Phone, Img = dto.Img };
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> UpdateStatusAsync(int id, string status)
    {
        var order = await _db.Orders.FindAsync(id);
        if (order == null) return null;
        order.Status = status;
        await _db.SaveChangesAsync();
        return order;
    }
}