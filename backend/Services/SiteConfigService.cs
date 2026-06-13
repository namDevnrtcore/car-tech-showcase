using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;
using CarTechShowcase.Models;

namespace CarTechShowcase.Services;

public class SiteConfigService
{
    private readonly AppDbContext _db;
    public SiteConfigService(AppDbContext db) => _db = db;

    public async Task<SiteConfig> GetAsync()
    {
        return await _db.SiteConfigs.FirstOrDefaultAsync() ?? new SiteConfig();
    }

    public async Task SaveAsync(SiteConfig incoming)
    {
        var existing = await _db.SiteConfigs.FirstOrDefaultAsync();
        if (existing == null)
        {
            _db.SiteConfigs.Add(incoming);
        }
        else
        {
            existing.CompanyName          = incoming.CompanyName;
            existing.AboutShort           = incoming.AboutShort;
            existing.Address              = incoming.Address;
            existing.Phone                = incoming.Phone;
            existing.Email                = incoming.Email;
            existing.WorkingHoursWeekday  = incoming.WorkingHoursWeekday;
            existing.WorkingHoursSunday   = incoming.WorkingHoursSunday;
            existing.ZaloPhone            = incoming.ZaloPhone;
            existing.FacebookUrl          = incoming.FacebookUrl;
            existing.MapEmbedUrl          = incoming.MapEmbedUrl;
        }
        await _db.SaveChangesAsync();
    }
}
