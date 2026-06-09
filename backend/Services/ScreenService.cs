// ============================================
// 📁 Services/ScreenService.cs
// ============================================

using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;
using CarTechShowcase.Models;
using CarTechShowcase.DTOs;

namespace CarTechShowcase.Services;

public class ScreenService
{
    private readonly AppDbContext _db;
    public ScreenService(AppDbContext db) => _db = db;

    public async Task<List<CarScreen>> GetAllAsync() => await _db.CarScreens.Where(s => s.IsActive).ToListAsync();
    public async Task<CarScreen?> GetByIdAsync(int id) => await _db.CarScreens.FindAsync(id);

    public async Task<CarScreen> CreateAsync(ScreenCreateDto dto)
    {
        var screen = new CarScreen { ScreenName = dto.ScreenName, Location = dto.Location, Note = dto.Note, TypeId = dto.TypeId };
        _db.CarScreens.Add(screen);
        await _db.SaveChangesAsync();
        return screen;
    }

    public async Task<CarScreen?> UpdateAsync(int id, ScreenUpdateDto dto)
    {
        var screen = await _db.CarScreens.FindAsync(id);
        if (screen == null) return null;
        screen.ScreenName = dto.ScreenName ?? screen.ScreenName;
        screen.Location = dto.Location ?? screen.Location;
        screen.Note = dto.Note ?? screen.Note;
        screen.TypeId = dto.TypeId ?? screen.TypeId;
        if (dto.IsActive.HasValue) screen.IsActive = dto.IsActive.Value;
        await _db.SaveChangesAsync();
        return screen;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var screen = await _db.CarScreens.FindAsync(id);
        if (screen == null) return false;
        screen.IsActive = false;
        await _db.SaveChangesAsync();
        return true;
    }
}