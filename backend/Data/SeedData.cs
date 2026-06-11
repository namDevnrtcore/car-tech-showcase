// ============================================
// 📁 Data/SeedData.cs - Seed Sample Data
// ============================================

using CarTechShowcase.Models;

namespace CarTechShowcase.Data;

public static class SeedData
{
public static void Initialize(AppDbContext context)
{
    // Xóa dữ liệu cũ (nếu có) để seed lại
    if (context.Banners.Any())
    {
        context.Orders.RemoveRange(context.Orders);
        context.News.RemoveRange(context.News);
        context.Products.RemoveRange(context.Products);
        context.CarScreens.RemoveRange(context.CarScreens);
        context.Banners.RemoveRange(context.Banners);
        context.SaveChanges();
    }

    // ---------- 1. Banners ----------
        context.Banners.AddRange(
            new Banner
            {
                Banner1 = "/images/banners/banner-car-tech-main.jpg",
                Banner2 = "/images/banners/banner-car-tech-sub.jpg",
                IsActive = true
            },
            new Banner
            {
                Banner1 = "/images/banners/banner-promo-2024.jpg",
                Banner2 = "/images/banners/banner-new-arrivals.jpg",
                IsActive = true
            }
        );

        // ---------- 2. CarScreens ----------
        context.CarScreens.AddRange(
            new CarScreen
            {
                ScreenName = "Màn hình Android ô tô 10 inch",
                Location = "Taplo trung tâm",
                Note = "Hỗ trợ GPS, Bluetooth, Camera lùi",
                TypeId = null,
                IsActive = true
            },
            new CarScreen
            {
                ScreenName = "Màn hình DVD Android 9 inch",
                Location = "Taplo trung tâm",
                Note = "Mỏng nhẹ, giao diện đơn giản",
                TypeId = null,
                IsActive = true
            },
            new CarScreen
            {
                ScreenName = "Màn hình Camera 360 độ 11 inch",
                Location = "Taplo + Mirror",
                Note = "Góc nhìn toàn cảnh, quan sát 4 phía",
                TypeId = null,
                IsActive = true
            },
            new CarScreen
            {
                ScreenName = "Màn hình rear seat entertainment 13 inch",
                Location = "Tựa đầu hàng ghế sau",
                Note = "Giải trí cho hành khách phía sau",
                TypeId = null,
                IsActive = true
            },
            new CarScreen
            {
                ScreenName = "Đồng hồ màn hình kỹ thuật số TFT 7 inch",
                Location = "Bảng đồng hồ taplo",
                Note = "Hiển thị tốc độ, vòng tua, nhiệt độ",
                TypeId = null,
                IsActive = true
            }
        );

        // ---------- 3. Products ----------
        context.Products.AddRange(
            new Product
            {
                ProductName = "Màn hình Android G09 Pro - 10 inch",
                Price = 3500000,
                Category = "Màn hình Android",
                Description = "Màn hình Android 10 inch cao cấp, RAM 4GB, ROM 64GB. Hỗ trợ SIM 4G, GPS Navigation, Camera lùi, Bluetooth 5.0. Giao diện mượt mà, tương thích với tất cả dòng xe.",
                Img = "/images/products/g09-pro-10inch.jpg",
                Spec = "RAM: 4GB | ROM: 64GB | Màn hình: 10 inch IPS | Hệ điều hành: Android 12 | Kết nối: WiFi, Bluetooth 5.0, SIM 4G",
                IsActive = true
            },
            new Product
            {
                ProductName = "Màn hình Android Teyes CC3L - 9 inch",
                Price = 2800000,
                Category = "Màn hình Android",
                Description = "Màn hình Android Teyes CC3L 9 inch với thiết kế sang trọng, chất lượng âm thanh tuyệt vời. Hỗ trợ Apple CarPlay không dây và Android Auto.",
                Img = "/images/products/teyes-cc3l-9inch.jpg",
                Spec = "RAM: 2GB | ROM: 32GB | Màn hình: 9 inch IPS | Hệ điều hành: Android 11 | Kết nối: WiFi, Bluetooth 5.0",
                IsActive = true
            },
            new Product
            {
                ProductName = "Camera 360度 Owin S1 Full HD",
                Price = 4500000,
                Category = "Camera 360",
                Description = "Hệ thống camera 360 độ Owin S1 với 4 camera FULL HD 1080P, góc nhìn toàn cảnh xe. Hỗ trợ ghi hình ban đêm, hiển thị 3D, radar đỗ xe.",
                Img = "/images/products/owin-s1-360.jpg",
                Spec = "Độ phân giải: 1080P | Số camera: 4 | Góc nhìn: 360° | Chế độ: 2D/3D | Tính năng: Ghi đêm, radar",
                IsActive = true
            },
            new Product
            {
                ProductName = "Camera lùi xe hơi Full HD",
                Price = 750000,
                Category = "Camera",
                Description = "Camera lùi Full HD 1080P chống nước IP68, góc rộng 170°, chip Sony STARVIS cho hình ảnh rõ nét cả ban đêm.",
                Img = "/images/products/camera-lui-hd.jpg",
                Spec = "Độ phân giải: 1080P | Góc rộng: 170° | Chống nước: IP68 | Chip: Sony STARVIS | LED hồng ngoại",
                IsActive = true
            },
            new Product
            {
                ProductName = "Bộ Camera hành trình Carcam D600",
                Price = 1900000,
                Category = "Camera hành trình",
                Description = "Camera hành trình trước sau Carcam D600, quay video 4K trước và 1080P sau. Tính năng G-Sensor, đỗ xe có giám sát, GPS gắn dấu đường.",
                Img = "/images/products/carcam-d600.jpg",
                Spec = "Camera trước: 4K | Camera sau: 1080P | Góc nhìn: 170° (trước) + 140° (sau) | Tính năng: G-Sensor, GPS, Parking Monitor",
                IsActive = true
            },
            new Product
            {
                ProductName = "Màn hình rear seat 12.5 inch Android",
                Price = 2200000,
                Category = "Màn hình rear seat",
                Description = "Màn hình giải trí dành cho hành khách phía sau, cài đặt Android, hỗ trợ xem phim, lướt web, chơi game. Lắp đặt dễ dàng trên tựa đầu.",
                Img = "/images/products/rear-seat-125.jpg",
                Spec = "Màn hình: 12.5 inch IPS Full HD | RAM: 3GB | ROM: 32GB | Hệ điều hành: Android 11 | Kết nối: WiFi, Bluetooth, USB",
                IsActive = true
            }
        );

        // ---------- 4. News ----------
        context.News.AddRange(
            new News
            {
                Title = "Xu hướng màn hình Android ô tô năm 2024",
                Summary = "Các xu hướng công nghệ mới nhất trong lĩnh vực màn hình Android cho ô tô, từ tính năng AI đến giao diện hiện đại.",
                Content = "Năm 2024 chứng kiến sự phát triển mạnh mẽ của công nghệ màn hình Android cho ô tô. Các tính năng mới bao gồm: nhận diện giọng nói nâng cao với AI, tích hợp trợ lý ảo, hỗ trợ Apple CarPlay và Android Auto không dây, cũng như giao diện người dùng được tối ưu hóa cho tài xế. Đặc biệt, các dòng màn hình RAM 4GB trở lên đang trở thành xu hướng phổ biến, mang lại trải nghiệm mượt mà không khác gì smartphone cao cấp.",
                Img = "/images/news/trend-2024.jpg",
                IsActive = true
            },
            new News
            {
                Title = "Camera 360 độ: Có nên trang bị cho xe hơi?",
                Summary = "Phân tích ưu nhược điểm của hệ thống camera 360 độ và lý do tại sao đây là phụ kiện không thể thiếu.",
                Content = "Camera 360 độ cho xe hơi đã trở thành một trong những phụ kiện được quan tâm nhất hiện nay. Hệ thống gồm 4 camera đặt ở 4 vị trí trên xe, tạo ra hình ảnh toàn cảnh 360° giúp tài xế quan sát mọi góc blindspot. Ưu điểm bao gồm: hỗ trợ đỗ xe an toàn, giảm thiểu va chạm, quan sát cả ban đêm. Nhược điểm: chi phí lắp đặt khá cao (3-6 triệu), cần thợ có kinh nghiệm. Tuy nhiên, so với chi phí sửa chữa sau va chạm, đây vẫn là khoản đầu tư đáng giá.",
                Img = "/images/news/camera360-review.jpg",
                IsActive = true
            },
            new News
            {
                Title = "Hướng dẫn chọn màn hình Android phù hợp với xe của bạn",
                Summary = "Các tiêu chí quan trọng khi lựa chọn màn hình Android ô tô: kích thước, cấu hình, tính năng và giá thành.",
                Content = "Việc lựa chọn màn hình Android phù hợp cho xe hơi phụ thuộc vào nhiều yếu tố. Thứ nhất là kích thước: xe sedan thường dùng màn 9-10 inch, xe SUV có thể dùng 10-12 inch. Thứ hai là cấu hình: RAM 2GB đủ cho nhu cầu cơ bản, RAM 4GB phù hợp cho người dùng đa nhiệm. Thứ ba là tính năng: Apple CarPlay, Camera lùi, GPS là những tính năng cơ bản cần có. Cuối cùng là thương hiệu: các thương hiệu uy tín như Teyes, G09, Owin thường có chế độ bảo hành tốt.",
                Img = "/images/news/huong-don-chon-man-hinh.jpg",
                IsActive = true
            },
            new News
            {
                Title = "Lắp Camera hành trình: Những điều cần biết",
                Summary = "Kinh nghiệm chọn và lắp camera hành trình cho xe hơi, từ phân khúc giá rẻ đến cao cấp.",
                Content = "Camera hành trình đang trở thành phụ kiện cần thiết cho mọi tài xế. Sản phẩm không chỉ giúp ghi lại hành trình mà còn là bằng chứng quan trọng khi xảy ra sự cố giao thông. Khi chọn mua, cần lưu ý: độ phân giải (tối thiểu 1080P), góc quay (140° trở lên), tính năng ban đêm, dung lượng thẻ nhớ hỗ trợ. Phân khúc giá phổ thông từ 500K-2 triệu, phân khúc cao cấp từ 2-5 triệu với nhiều tính năng nâng cao như 4K, GPS, WiFi.",
                Img = "/images/news/camera-hanh-trinh.jpg",
                IsActive = true
            }
        );

        // ---------- 5. Orders ----------
        context.Orders.AddRange(
            new Order
            {
                ProductName = "Màn hình Android G09 Pro - 10 inch",
                Price = "3,500,000",
                Quantity = 1,
                TotalAmount = "3,500,000",
                FullName = "Nguyễn Văn An",
                Phone = "0901234567",
                Img = "/images/products/g09-pro-10inch.jpg",
                Status = "Đã giao",
                CreatedAt = new DateTime(2024, 3, 15, 10, 30, 0)
            },
            new Order
            {
                ProductName = "Camera 360度 Owin S1 Full HD",
                Price = "4,500,000",
                Quantity = 1,
                TotalAmount = "4,500,000",
                FullName = "Trần Thị Bình",
                Phone = "0912345678",
                Img = "/images/products/owin-s1-360.jpg",
                Status = "Đang xử lý",
                CreatedAt = new DateTime(2024, 4, 2, 14, 15, 0)
            },
            new Order
            {
                ProductName = "Camera lùi xe hơi Full HD",
                Price = "750,000",
                Quantity = 2,
                TotalAmount = "1,500,000",
                FullName = "Lê Hoàng Dũng",
                Phone = "0923456789",
                Img = "/images/products/camera-lui-hd.jpg",
                Status = "Đã giao",
                CreatedAt = new DateTime(2024, 4, 10, 9, 0, 0)
            },
            new Order
            {
                ProductName = "Bộ Camera hành trình Carcam D600",
                Price = "1,900,000",
                Quantity = 1,
                TotalAmount = "1,900,000",
                FullName = "Phạm Minh Tuấn",
                Phone = "0934567890",
                Img = "/images/products/carcam-d600.jpg",
                Status = "Chờ xác nhận",
                CreatedAt = new DateTime(2024, 4, 18, 16, 45, 0)
            }
        );

        context.SaveChanges();
        Console.WriteLine("✅ Seed data đã được thêm thành công!");
    }
}