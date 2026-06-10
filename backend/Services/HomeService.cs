// ============================================
// 📁 Services/HomeService.cs - Home Page Data Service
// Matches client/src/services/home.service.ts + product.service.ts
// ============================================

namespace CarTechShowcase.Services;

public class HomeService
{
    // All products for Products page
    public object GetProducts() => new object[]
    {
        new { Id = 1, Name = "Camera 70mai A800S", Price = (long)2990000, Image = "/images/product-1.jpg", Size = "4K", Specs = "4K | GPS | ADAS", Features = new[] { "GPS", "ADAS", "WiFi" } },
        new { Id = 2, Name = "Vietmap C61 Pro", Price = (long)1890000, Image = "/images/product-2.jpg", Size = "2K", Specs = "2K | WDR | 170°", Features = new[] { "WDR", "WiFi" } },
        new { Id = 3, Name = "Hikvision C6S", Price = (long)3200000, Image = "/images/product-3.jpg", Size = "4K", Specs = "4K | HDR | WiFi", Features = new[] { "HDR", "WiFi", "GPS" } },
        new { Id = 4, Name = "Vietmap ND10 Pro", Price = (long)4500000, Image = "/images/product-1.jpg", Size = "10 inch", Specs = "GPS | Cloud | 4G", Features = new[] { "GPS", "4G", "Cloud" } },
        new { Id = 5, Name = "Huviron ND-10", Price = (long)3800000, Image = "/images/product-2.jpg", Size = "10 inch", Specs = "GPS | WiFi | FHD", Features = new[] { "GPS", "WiFi" } },
        new { Id = 6, Name = "Hikvision ND10S", Price = (long)5200000, Image = "/images/product-3.jpg", Size = "10 inch", Specs = "4G | GPS | Cloud", Features = new[] { "4G", "GPS", "Cloud" } },
        new { Id = 7, Name = "GOTECH GT10 Pro", Price = (long)8500000, Image = "/images/product-1.jpg", Size = "10 inch", Specs = "10 inch | Android 13 | 4GB RAM", Features = new[] { "GPS", "Bluetooth", "WiFi", "CarPlay" } },
        new { Id = 8, Name = "GOTECH GT9 Max", Price = (long)7200000, Image = "/images/product-2.jpg", Size = "9 inch", Specs = "9 inch | Android 13 | GPS", Features = new[] { "GPS", "Bluetooth", "WiFi" } },
        new { Id = 9, Name = "GOTECH GT12 Ultra", Price = (long)12500000, Image = "/images/product-3.jpg", Size = "12 inch", Specs = "12 inch | Android 13 | 6GB RAM", Features = new[] { "GPS", "Bluetooth", "WiFi", "CarPlay", "Camera 360" } },
        new { Id = 10, Name = "Xenon X9 Toyota", Price = (long)9500000, Image = "/images/product-1.jpg", Size = "9 inch", Specs = "9 inch | Carplay | DSP", Features = new[] { "CarPlay", "DSP", "GPS" } },
        new { Id = 11, Name = "Xenon X10 Honda", Price = (long)10200000, Image = "/images/product-2.jpg", Size = "10 inch", Specs = "10 inch | 4G | GPS", Features = new[] { "4G", "GPS", "CarPlay" } },
        new { Id = 12, Name = "Xenon X12 Mazda", Price = (long)11800000, Image = "/images/product-3.jpg", Size = "12 inch", Specs = "12 inch | Carplay | 6GB", Features = new[] { "CarPlay", "6GB RAM", "GPS" } },
    };

    public object GetHeroImage() => "/images/hero-car-screen.jpg";

    public object GetFeatures() => new[]
    {
        new { Icon = "Shield", Title = "Bảo hành 2 năm", Description = "Chính hãng, uy tín" },
        new { Icon = "Headphones", Title = "Hỗ trợ 24/7", Description = "Tư vấn nhiệt tình" },
        new { Icon = "Check", Title = "Lắp đặt miễn phí", Description = "Tận nơi, chuyên nghiệp" },
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

    // 4 categories matching getCategories() in product.service.ts
    public object GetCategories() => new object[]
    {
        new
        {
            Id = 1,
            Name = "Camera Hành Trình",
            Icon = "🎥",
            Description = "Ghi lại mọi hành trình, bảo vệ quyền lợi của bạn",
            Products = new object[]
            {
                new { Id = 1, Name = "Camera 70mai A800S", Price = "2.990.000đ", Specs = "4K | GPS | ADAS", Image = "/images/product-1.jpg" },
                new { Id = 2, Name = "Vietmap C61 Pro", Price = "1.890.000đ", Specs = "2K | WDR | 170°", Image = "/images/product-2.jpg" },
                new { Id = 3, Name = "Hikvision C6S", Price = "3.200.000đ", Specs = "4K | HDR | WiFi", Image = "/images/product-3.jpg" },
            }
        },
        new
        {
            Id = 2,
            Name = "Camera Nghị Định 10",
            Icon = "📷",
            Description = "Đáp ứng tiêu chuẩn Nghị định 10 của Bộ GTVT",
            Products = new object[]
            {
                new { Id = 4, Name = "Vietmap ND10 Pro", Price = "4.500.000đ", Specs = "GPS | Cloud | 4G", Image = "/images/product-1.jpg" },
                new { Id = 5, Name = "Huviron ND-10", Price = "3.800.000đ", Specs = "GPS | WiFi | FHD", Image = "/images/product-2.jpg" },
                new { Id = 6, Name = "Hikvision ND10S", Price = "5.200.000đ", Specs = "4G | GPS | Cloud", Image = "/images/product-3.jpg" },
            }
        },
        new
        {
            Id = 3,
            Name = "Màn Hình Android",
            Icon = "📱",
            Description = "Hệ thống giải trí thông minh cho xe hơi",
            Products = new object[]
            {
                new { Id = 7, Name = "GOTECH GT10 Pro", Price = "8.500.000đ", Specs = "10 inch | Android 13 | 4GB RAM", Image = "/images/product-1.jpg" },
                new { Id = 8, Name = "GOTECH GT9 Max", Price = "7.200.000đ", Specs = "9 inch | Android 13 | GPS", Image = "/images/product-2.jpg" },
                new { Id = 9, Name = "GOTECH GT12 Ultra", Price = "12.500.000đ", Specs = "12 inch | Android 13 | 6GB RAM", Image = "/images/product-3.jpg" },
            }
        },
        new
        {
            Id = 4,
            Name = "Màn Hình Android Ô Tô",
            Icon = "🖥️",
            Description = "Màn hình chuyên dụng tích hợp theo xe",
            Products = new object[]
            {
                new { Id = 10, Name = "Xenon X9 Toyota", Price = "9.500.000đ", Specs = "9 inch | Carplay | DSP", Image = "/images/product-1.jpg" },
                new { Id = 11, Name = "Xenon X10 Honda", Price = "10.200.000đ", Specs = "10 inch | 4G | GPS", Image = "/images/product-2.jpg" },
                new { Id = 12, Name = "Xenon X12 Mazda", Price = "11.800.000đ", Specs = "12 inch | Carplay | 6GB", Image = "/images/product-3.jpg" },
            }
        }
    };

    // Home news - 3 items matching getHomeNews() in home.service.ts
    public object GetHomeNews() => new object[]
    {
        new
        {
            Id = 1,
            Title = "5 Lý do nên nâng cấp màn hình Android cho xe của bạn",
            Excerpt = "Khám phá những lợi ích vượt trội khi nâng cấp màn hình Android cho ô tô và tại sao đây là khoản đầu tư đáng giá.",
            Image = "https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800&auto=format&fit=crop",
            Date = "15/01/2024",
            Tag = "Hướng dẫn",
        },
        new
        {
            Id = 2,
            Title = "Cách chọn màn hình ô tô phù hợp với dòng xe Toyota",
            Excerpt = "Hướng dẫn chi tiết giúp bạn lựa chọn màn hình Android phù hợp nhất cho các dòng xe Toyota phổ biến tại Việt Nam.",
            Image = "https://images.unsplash.com/photo-1609521263047-f8f205293f24?w=800&auto=format&fit=crop",
            Date = "12/01/2024",
            Tag = "Hướng dẫn",
        },
        new
        {
            Id = 3,
            Title = "Xu hướng công nghệ màn hình ô tô năm 2024",
            Excerpt = "Cập nhật những xu hướng mới nhất trong công nghệ màn hình ô tô, từ AI đến kết nối không dây tiên tiến.",
            Image = "https://images.unsplash.com/photo-1581092918056-0c4c3acd3789?w=800&auto=format&fit=crop",
            Date = "10/01/2024",
            Tag = "Tin tức",
        },
    };

    // News categories matching getNewsCategories() in news.service.ts
    public object GetNewsCategories() => new object[]
    {
        new { Id = "all", Name = "Tất cả" },
        new { Id = "guide", Name = "Hướng dẫn" },
        new { Id = "news", Name = "Tin tức" },
        new { Id = "review", Name = "Đánh giá" },
    };

    // News articles matching getArticles() in news.service.ts
    public object GetArticles() => new object[]
    {
        new { Id = 1, Title = "5 Lý do nên nâng cấp màn hình Android cho xe của bạn", Excerpt = "Khám phá những lợi ích vượt trội khi nâng cấp màn hình Android cho ô tô và tại sao đây là khoản đầu tư đáng giá.", Image = "https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800&auto=format&fit=crop", Category = "guide", CategoryName = "Hướng dẫn", Date = "15/01/2024", Author = "Admin", ReadTime = "5 phút đọc" },
        new { Id = 2, Title = "Cách chọn màn hình ô tô phù hợp với dòng xe Toyota", Excerpt = "Hướng dẫn chi tiết giúp bạn lựa chọn màn hình Android phù hợp nhất cho các dòng xe Toyota phổ biến tại Việt Nam.", Image = "https://images.unsplash.com/photo-1609521263047-f8f205293f24?w=800&auto=format&fit=crop", Category = "guide", CategoryName = "Hướng dẫn", Date = "12/01/2024", Author = "Admin", ReadTime = "7 phút đọc" },
        new { Id = 3, Title = "Xu hướng công nghệ màn hình ô tô năm 2024", Excerpt = "Cập nhật những xu hướng mới nhất trong công nghệ màn hình ô tô, từ AI đến kết nối không dây tiên tiến.", Image = "https://images.unsplash.com/photo-1581092918056-0c4c3acd3789?w=800&auto=format&fit=crop", Category = "news", CategoryName = "Tin tức", Date = "10/01/2024", Author = "Admin", ReadTime = "6 phút đọc" },
        new { Id = 4, Title = "So sánh màn hình Android vs màn hình zin theo xe", Excerpt = "Đánh giá chi tiết ưu nhược điểm của màn hình Android aftermarket so với màn hình zin theo xe.", Image = "https://images.unsplash.com/photo-1617654112368-307921291f42?w=800&auto=format&fit=crop", Category = "review", CategoryName = "Đánh giá", Date = "08/01/2024", Author = "Admin", ReadTime = "8 phút đọc" },
        new { Id = 5, Title = "Hướng dẫn sử dụng CarPlay và Android Auto hiệu quả", Excerpt = "Tìm hiểu cách tận dụng tối đa tính năng CarPlay và Android Auto trên màn hình ô tô của bạn.", Image = "https://images.unsplash.com/photo-1555597673-b21d5c935865?w=800&auto=format&fit=crop", Category = "guide", CategoryName = "Hướng dẫn", Date = "05/01/2024", Author = "Admin", ReadTime = "6 phút đọc" },
        new { Id = 6, Title = "Bảo dưỡng màn hình ô tô đúng cách", Excerpt = "Những mẹo đơn giản giúp màn hình ô tô của bạn luôn hoạt động tốt và bền bỉ theo thời gian.", Image = "https://images.unsplash.com/photo-1486262715619-67b85e0b08d3?w=800&auto=format&fit=crop", Category = "guide", CategoryName = "Hướng dẫn", Date = "01/01/2024", Author = "Admin", ReadTime = "4 phút đọc" },
    };
}