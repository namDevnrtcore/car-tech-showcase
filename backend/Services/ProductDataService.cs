// ============================================
// 📁 Services/ProductDataService.cs - Product Data
// Matches client/src/services/product.service.ts exactly
// ============================================

namespace CarTechShowcase.Services;

public class ProductDataService
{
    public string FormatPrice(long price) => string.Format("{0:N0}đ", price);

    public object GetProducts() => new object[]
    {
        new { Id = 1, Name = "GOTECH GT10 Pro", Price = (long)8500000, Image = "/images/product-1.jpg", Size = "10 inch", Specs = "Android 13 | 4GB RAM | 64GB ROM", Features = new[] { "GPS", "Bluetooth", "WiFi", "CarPlay" } },
        new { Id = 2, Name = "GOTECH GT9 Max", Price = (long)7200000, Image = "/images/product-2.jpg", Size = "9 inch", Specs = "Android 13 | 4GB RAM | 32GB ROM", Features = new[] { "GPS", "Bluetooth", "WiFi" } },
        new { Id = 3, Name = "GOTECH GT12 Ultra", Price = (long)12500000, Image = "/images/product-3.jpg", Size = "12 inch", Specs = "Android 13 | 6GB RAM | 128GB ROM", Features = new[] { "GPS", "Bluetooth", "WiFi", "CarPlay", "Camera 360" } },
        new { Id = 4, Name = "GOTECH GT7 Compact", Price = (long)5500000, Image = "/images/product-4.jpg", Size = "7 inch", Specs = "Android 12 | 2GB RAM | 32GB ROM", Features = new[] { "GPS", "Bluetooth" } },
        new { Id = 5, Name = "GOTECH GT10 Standard", Price = (long)6800000, Image = "/images/product-1.jpg", Size = "10 inch", Specs = "Android 12 | 3GB RAM | 32GB ROM", Features = new[] { "GPS", "Bluetooth", "WiFi" } },
        new { Id = 6, Name = "GOTECH GT9 Pro", Price = (long)9200000, Image = "/images/product-2.jpg", Size = "9 inch", Specs = "Android 13 | 4GB RAM | 64GB ROM", Features = new[] { "GPS", "Bluetooth", "WiFi", "CarPlay" } },
    };

    public object GetProductDetail(int id) => new
    {
        Id = id,
        Name = "GOTECH GT10 Pro",
        Price = (long)8500000,
        Status = "Còn hàng",
        Rating = 4.8,
        Reviews = 127,
        Images = new[] { "/images/product-1.jpg", "/images/product-2.jpg", "/images/product-3.jpg" },
        Description = "Màn hình Android GOTECH GT10 Pro là giải pháp hoàn hảo để nâng cấp hệ thống giải trí trên xe của bạn với công nghệ hiện đại nhất.",
        Size = "10 inch",
        Specs = "Android 13 | 4GB RAM | 64GB ROM",
        DetailedSpecs = new Dictionary<string, string>
        {
            { "Size", "10 inch IPS" },
            { "OS", "Android 13" },
            { "RAM", "4GB" },
            { "ROM", "64GB" },
            { "Connectivity", "Bluetooth 5.0, WiFi, USB, CarPlay không dây" },
            { "Warranty", "2 năm chính hãng" },
        },
        ProductFeatures = new object[]
        {
            new { Title = "Màn hình IPS Full HD", Description = "Độ phân giải cao, góc nhìn rộng, hiển thị sắc nét trong mọi điều kiện ánh sáng" },
            new { Title = "Android 13 mới nhất", Description = "Hệ điều hành mượt mà, ổn định với khả năng tùy biến cao" },
            new { Title = "Kết nối đa dạng", Description = "Hỗ trợ CarPlay không dây, Android Auto, Bluetooth, WiFi" },
            new { Title = "GPS tích hợp", Description = "Định vị chính xác, dẫn đường thông minh với bản đồ offline" },
            new { Title = "Camera 360 độ", Description = "Hỗ trợ camera lùi, camera 360 độ giúp quan sát toàn cảnh" },
            new { Title = "Âm thanh DSP", Description = "Xử lý âm thanh DSP 32 kênh, mang đến trải nghiệm nghe nhạc đỉnh cao" },
        },
    };

    public object GetRelatedProducts() => new object[]
    {
        new { Id = 2, Name = "GOTECH GT9 Max", Price = (long)7200000, Image = "/images/product-2.jpg" },
        new { Id = 3, Name = "GOTECH GT12 Ultra", Price = (long)12500000, Image = "/images/product-3.jpg" },
    };
}