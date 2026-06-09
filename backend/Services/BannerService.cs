// ============================================
// 📁 Services/BannerService.cs - Banner Business Logic
// ============================================

using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;
using CarTechShowcase.Models;
using CarTechShowcase.DTOs;

namespace CarTechShowcase.Services;

public class BannerService
{
    private readonly AppDbContext _db;
    public BannerService(AppDbContext db) => _db = db;

    public async Task<List<Banner>> GetAllAsync()
        => await _db.Banners.Where(b => b.IsActive).ToListAsync();

    public async Task<Banner?> GetByIdAsync(int id)
        => await _db.Banners.FindAsync(id);

    public async Task<Banner> CreateAsync(BannerCreateDto dto)
    {
        var banner = new Banner { Banner1 = dto.Banner1, Banner2 = dto.Banner2 };
        _db.Banners.Add(banner);
        await _db.SaveChangesAsync();
        return banner;
    }

    public async Task<Banner?> UpdateAsync(int id, BannerUpdateDto dto)
    {
        var banner = await _db.Banners.FindAsync(id);
        if (banner == null) return null;
        banner.Banner1 = dto.Banner1 ?? banner.Banner1;
        banner.Banner2 = dto.Banner2 ?? banner.Banner2;
        await _db.SaveChangesAsync();
        return banner;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var banner = await _db.Banners.FindAsync(id);
        if (banner == null) return false;
        banner.IsActive = false;
        await _db.SaveChangesAsync();
        return true;
    }
}