using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;

namespace CarTechShowcase.Services;

public class HomeService
{
    private readonly AppDbContext _db;
    public HomeService(AppDbContext db) => _db = db;

    // ---------- Static config (không cần DB) ----------

    public string GetHeroImage() => "/images/hero-car-screen.jpg";

    public object GetFeatures() => new[]
    {
        new { Icon = "Shield",     Title = "Bảo hành 2 năm",      Description = "Chính hãng, uy tín" },
        new { Icon = "Headphones", Title = "Hỗ trợ 24/7",         Description = "Tư vấn nhiệt tình" },
        new { Icon = "Check",      Title = "Lắp đặt miễn phí",    Description = "Tận nơi, chuyên nghiệp" },
    };

    public object GetCompatibleCars() => new object[]
    {
        new { Name = "Toyota",   Img = "/images/logocars/toyota.png",   Models = "Camry, Vios, Fortuner..." },
        new { Name = "Honda",    Img = "/images/logocars/honda.png",    Models = "CR-V, City, Civic..." },
        new { Name = "Mazda",    Img = "/images/logocars/mazda.png",    Models = "CX-5, Mazda3, CX-8..." },
        new { Name = "Hyundai",  Img = "/images/logocars/hyundai.webp", Models = "Tucson, i10, Santa Fe..." },
        new { Name = "Kia",      Img = "/images/logocars/kia.png",      Models = "Seltos, Morning, Sorento..." },
        new { Name = "Mercedes", Img = "/images/logocars/mercedes.png", Models = "C-Class, E-Class, GLC..." },
    };

    public object GetNewsCategories() => new object[]
    {
        new { Id = "all",    Name = "Tất cả" },
        new { Id = "guide",  Name = "Hướng dẫn" },
        new { Id = "news",   Name = "Tin tức" },
        new { Id = "review", Name = "Đánh giá" },
    };

    // ---------- Load từ database ----------

    public async Task<object[]> GetProductsAsync()
    {
        var products = await _db.Products.Where(p => p.IsActive).ToListAsync();
        return products.Select(p => (object)new
        {
            Id    = p.Id,
            Name  = p.ProductName,
            Price = (long)(p.Price ?? 0),
            Image = p.Img ?? "",
            Size  = ExtractSize(p.Spec),
            Specs = p.Spec ?? "",
            Features = ExtractFeatures(p.Spec),
        }).ToArray();
    }

    public async Task<object[]> GetCategoriesAsync()
    {
        var products = await _db.Products.Where(p => p.IsActive).ToListAsync();
        var groups = products.GroupBy(p => p.Category ?? "Khác").ToList();
        return groups.Select((g, i) => (object)new
        {
            Id          = i + 1,
            Name        = g.Key,
            Icon        = GetCategoryIcon(g.Key),
            Description = GetCategoryDescription(g.Key),
            Products    = g.Take(3).Select(p => new
            {
                Id    = p.Id,
                Name  = p.ProductName,
                Price = FormatPrice((long)(p.Price ?? 0)),
                Specs = p.Spec ?? "",
                Image = p.Img ?? "",
            }).ToArray(),
        }).ToArray();
    }

    public async Task<object[]> GetHomeNewsAsync()
    {
        var news = await _db.News
            .Where(n => n.IsActive)
            .OrderByDescending(n => n.CreatedAt)
            .Take(3)
            .ToListAsync();

        return news.Select(n => (object)new
        {
            Id      = n.Id,
            Title   = n.Title ?? "",
            Excerpt = n.Summary ?? "",
            Image   = n.Img ?? GetHeroImage(),
            Date    = n.CreatedAt.ToString("dd/MM/yyyy"),
            Tag     = GuessCategoryName(n.Title ?? ""),
        }).ToArray();
    }

    public async Task<object?> GetNewsDetailAsync(int id)
    {
        var news = await _db.News.FindAsync(id);
        if (news == null) return null;
        return new
        {
            Id       = news.Id,
            Title    = news.Title ?? "",
            Summary  = news.Summary ?? "",
            Content  = news.Content ?? "",
            Img      = news.Img ?? GetHeroImage(),
            Date     = news.CreatedAt.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("vi-VN")),
            Category = GuessCategoryName(news.Title ?? ""),
            ReadTime = EstimateReadTime(news.Content),
        };
    }

    public async Task<object[]> GetRelatedNewsAsync(int currentId)
    {
        var news = await _db.News
            .Where(n => n.IsActive && n.Id != currentId)
            .OrderByDescending(n => n.CreatedAt)
            .Take(3)
            .ToListAsync();
        return news.Select(n => (object)new
        {
            Id      = n.Id,
            Title   = n.Title ?? "",
            Excerpt = n.Summary ?? "",
            Image   = n.Img ?? GetHeroImage(),
            Date    = n.CreatedAt.ToString("dd/MM/yyyy"),
            Tag     = GuessCategoryName(n.Title ?? ""),
        }).ToArray();
    }

    public async Task<object[]> GetArticlesAsync()
    {
        var news = await _db.News
            .Where(n => n.IsActive)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();

        return news.Select(n => (object)new
        {
            Id           = n.Id,
            Title        = n.Title ?? "",
            Excerpt      = n.Summary ?? "",
            Image        = n.Img ?? GetHeroImage(),
            Category     = GuessCategoryId(n.Title ?? ""),
            CategoryName = GuessCategoryName(n.Title ?? ""),
            Date         = n.CreatedAt.ToString("dd/MM/yyyy"),
            Author       = "Admin",
            ReadTime     = EstimateReadTime(n.Content),
        }).ToArray();
    }

    // ---------- Helper methods ----------

    private static string FormatPrice(long price) => string.Format("{0:N0}đ", price);

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

    private static string GetCategoryIcon(string cat) => cat switch
    {
        "Camera Hành Trình"      => "🎬",
        "Camera Nghị Định 10"    => "📡",
        "Màn Hình Android"       => "📱",
        "Màn Hình Android Ô Tô"  => "🖥️",
        _                        => "📦",
    };

    private static string GetCategoryDescription(string cat) => cat switch
    {
        "Camera Hành Trình"     => "Ghi lại mọi hành trình, bảo vệ quyền lợi của bạn",
        "Camera Nghị Định 10"   => "Camera GPS Cloud chuẩn Nghị Định 10/2020, bắt buộc cho xe kinh doanh vận tải",
        "Màn Hình Android"      => "Hệ thống giải trí thông minh, CarPlay & Android Auto không dây",
        "Màn Hình Android Ô Tô" => "Màn hình tích hợp chuyên biệt theo từng dòng xe Toyota, Honda, Mazda...",
        _                       => "Phụ kiện công nghệ cho xe hơi",
    };

    private static string GuessCategoryId(string title)
    {
        var t = title.ToLower();
        if (t.Contains("hướng dẫn") || t.Contains("cách chọn") || t.Contains("tiêu chí") || t.Contains("sử dụng")) return "guide";
        if (t.Contains("đánh giá") || t.Contains("so sánh") || t.Contains("review") || t.Contains("thực tế")) return "review";
        return "news";
    }

    private static string GuessCategoryName(string title)
    {
        var id = GuessCategoryId(title);
        return id switch { "guide" => "Hướng dẫn", "review" => "Đánh giá", _ => "Tin tức" };
    }

    private static string EstimateReadTime(string? content)
    {
        if (string.IsNullOrEmpty(content)) return "3 phút đọc";
        var minutes = Math.Max(1, content.Split(' ').Length / 200);
        return $"{minutes} phút đọc";
    }
}
