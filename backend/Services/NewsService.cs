// ============================================
// 📁 Services/NewsService.cs
// ============================================

using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;
using CarTechShowcase.Models;
using CarTechShowcase.DTOs;

namespace CarTechShowcase.Services;

public class NewsService
{
    private readonly AppDbContext _db;
    public NewsService(AppDbContext db) => _db = db;

    public async Task<List<News>> GetAllAsync() => await _db.News.Where(n => n.IsActive).OrderByDescending(n => n.CreatedAt).ToListAsync();
    public async Task<News?> GetByIdAsync(int id) => await _db.News.FindAsync(id);

    public async Task<News> CreateAsync(NewsCreateDto dto)
    {
        var news = new News { Title = dto.Title, Summary = dto.Summary, Content = dto.Content, Img = dto.Img };
        _db.News.Add(news);
        await _db.SaveChangesAsync();
        return news;
    }

    public async Task<News?> UpdateAsync(int id, NewsUpdateDto dto)
    {
        var news = await _db.News.FindAsync(id);
        if (news == null) return null;
        news.Title = dto.Title ?? news.Title;
        news.Summary = dto.Summary ?? news.Summary;
        news.Content = dto.Content ?? news.Content;
        news.Img = dto.Img ?? news.Img;
        if (dto.IsActive.HasValue) news.IsActive = dto.IsActive.Value;
        await _db.SaveChangesAsync();
        return news;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var news = await _db.News.FindAsync(id);
        if (news == null) return false;
        news.IsActive = false;
        await _db.SaveChangesAsync();
        return true;
    }
}