using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;

namespace CarTechShowcase.Services;

public class ProductDataService
{
    private readonly AppDbContext _db;
    public ProductDataService(AppDbContext db) => _db = db;

    public string FormatPrice(long price) => string.Format("{0:N0}đ", price);

    public async Task<object[]> GetProductsAsync()
    {
        var products = await _db.Products.Where(p => p.IsActive).ToListAsync();
        return products.Select(p => (object)new
        {
            Id       = p.Id,
            Name     = p.ProductName,
            Price    = (long)(p.Price ?? 0),
            Image    = p.Img ?? "",
            Size     = ExtractSize(p.Spec),
            Specs    = p.Spec ?? "",
            Features = ExtractFeatures(p.Spec),
        }).ToArray();
    }

    public async Task<object> GetProductDetailAsync(int id)
    {
        var p = await _db.Products.FindAsync(id);
        if (p == null) return new { };

        return new
        {
            Id       = p.Id,
            Name     = p.ProductName,
            Price    = (long)(p.Price ?? 0),
            Status   = "Còn hàng",
            Rating   = 4.8,
            Reviews  = 0,
            Images   = new[] { p.Img ?? "" },
            Description     = p.Description ?? "",
            Size            = ExtractSize(p.Spec),
            Specs           = p.Spec ?? "",
            DetailedSpecs   = ParseDetailedSpecs(p.Spec),
            ProductFeatures = new object[]
            {
                new { Title = "Màn hình IPS Full HD",  Description = "Độ phân giải cao, góc nhìn rộng, sắc nét mọi điều kiện" },
                new { Title = "Kết nối đa dạng",       Description = "Hỗ trợ CarPlay không dây, Android Auto, Bluetooth, WiFi" },
                new { Title = "GPS tích hợp",          Description = "Định vị chính xác, dẫn đường thông minh với bản đồ offline" },
                new { Title = "Bảo hành 2 năm",        Description = "Chính hãng, hỗ trợ kỹ thuật tận nơi" },
            },
        };
    }

    public async Task<object[]> GetRelatedProductsAsync(int currentId)
    {
        var current = await _db.Products.FindAsync(currentId);
        var query = _db.Products.Where(p => p.IsActive && p.Id != currentId);

        if (current?.Category != null)
            query = query.Where(p => p.Category == current.Category);

        var related = await query.Take(3).ToListAsync();

        // Fallback: nếu không đủ sản phẩm cùng category thì lấy bất kỳ
        if (related.Count < 2)
            related = await _db.Products.Where(p => p.IsActive && p.Id != currentId).Take(3).ToListAsync();

        return related.Select(p => (object)new
        {
            Id    = p.Id,
            Name  = p.ProductName,
            Price = (long)(p.Price ?? 0),
            Image = p.Img ?? "",
        }).ToArray();
    }

    // ---------- Helpers ----------

    private static string ExtractSize(string? spec)
    {
        if (spec == null) return "-";
        var m = System.Text.RegularExpressions.Regex.Match(spec, @"(\d+(?:\.\d+)?)\s*inch", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        return m.Success ? m.Groups[1].Value + " inch" : "-";
    }

    private static string[] ExtractFeatures(string? spec)
    {
        if (spec == null) return Array.Empty<string>();
        var list = new List<string>();
        foreach (var kw in new[] { "GPS", "Bluetooth", "WiFi", "CarPlay", "Android Auto", "4G", "5G", "DSP" })
            if (spec.Contains(kw, StringComparison.OrdinalIgnoreCase)) list.Add(kw);
        return list.ToArray();
    }

    private static Dictionary<string, string> ParseDetailedSpecs(string? spec)
    {
        var result = new Dictionary<string, string>();
        if (string.IsNullOrEmpty(spec)) return result;
        foreach (var part in spec.Split('|'))
        {
            var kv = part.Trim().Split(':', 2);
            if (kv.Length == 2 && !string.IsNullOrWhiteSpace(kv[0]))
                result[kv[0].Trim()] = kv[1].Trim();
        }
        return result;
    }
}
