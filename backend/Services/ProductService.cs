// ============================================
// 📁 Services/ProductService.cs
// ============================================

using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;
using CarTechShowcase.Models;
using CarTechShowcase.DTOs;

namespace CarTechShowcase.Services;

public class ProductService
{
    private readonly AppDbContext _db;
    public ProductService(AppDbContext db) => _db = db;

    public async Task<List<Product>> GetAllAsync() => await _db.Products.Where(p => p.IsActive).ToListAsync();
    public async Task<Product?> GetByIdAsync(int id) => await _db.Products.FindAsync(id);

    public async Task<Product> CreateAsync(ProductCreateDto dto)
    {
        var product = new Product { ProductName = dto.ProductName, Price = dto.Price, Category = dto.Category, Description = dto.Description, Img = dto.Img, Spec = dto.Spec };
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateAsync(int id, ProductUpdateDto dto)
    {
        var p = await _db.Products.FindAsync(id);
        if (p == null) return null;
        p.ProductName = dto.ProductName ?? p.ProductName;
        p.Price = dto.Price ?? p.Price;
        p.Category = dto.Category ?? p.Category;
        p.Description = dto.Description ?? p.Description;
        p.Img = dto.Img ?? p.Img;
        p.Spec = dto.Spec ?? p.Spec;
        if (dto.IsActive.HasValue) p.IsActive = dto.IsActive.Value;
        await _db.SaveChangesAsync();
        return p;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var p = await _db.Products.FindAsync(id);
        if (p == null) return false;
        p.IsActive = false;
        await _db.SaveChangesAsync();
        return true;
    }
}