using CarTechShowcase.Models;

namespace CarTechShowcase.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        // ---------- 1. Banners ----------
        context.Banners.AddRange(
            new Banner { Banner1 = "/images/hero-car-screen.jpg", Banner2 = "/images/product-1.jpg", IsActive = true },
            new Banner { Banner1 = "/images/product-2.jpg",       Banner2 = "/images/product-3.jpg", IsActive = true }
        );

        // ---------- 2. CarScreens ----------
        context.CarScreens.AddRange(
            new CarScreen { ScreenName = "Màn hình Android 10\" Taplo",   Location = "Taplo trung tâm",       Note = "Android 12, RAM 4GB, GPS, SIM 4G, Camera lùi",               TypeId = 1, IsActive = true },
            new CarScreen { ScreenName = "Màn hình Android 9\" IPS",      Location = "Taplo trung tâm",       Note = "CarPlay không dây, Android Auto, DSP 8-band",                TypeId = 1, IsActive = true },
            new CarScreen { ScreenName = "Màn hình Ô Tô Toyota 9\"",      Location = "Taplo trung tâm",       Note = "Tích hợp theo xe Toyota Camry, Vios, Fortuner",              TypeId = 1, IsActive = true },
            new CarScreen { ScreenName = "Màn hình Ô Tô Honda 10\"",      Location = "Taplo trung tâm",       Note = "Tích hợp theo xe Honda CR-V, City, Civic",                   TypeId = 1, IsActive = true },
            new CarScreen { ScreenName = "Camera Hành Trình 4K",          Location = "Kính chắn gió trước",  Note = "4K UHD, GPS, WiFi, G-Sensor, Parking Monitor 24/7",          TypeId = 2, IsActive = true },
            new CarScreen { ScreenName = "Camera Nghị Định 10 GPS Cloud", Location = "Kính chắn gió trước",  Note = "Chuẩn NĐ10/2020, GPS Cloud, truyền dữ liệu 4G thời gian thực", TypeId = 3, IsActive = true }
        );

        // ---------- 3. Products — đúng 4 danh mục ----------

        // [A] Camera Hành Trình
        context.Products.AddRange(
            new Product
            {
                ProductName = "Camera 70mai A800S 4K",
                Price       = 2990000,
                Category    = "Camera Hành Trình",
                Description = "Camera hành trình 70mai A800S quay 4K Ultra HD, tích hợp GPS, cảnh báo ADAS thông minh (cảnh báo khoảng cách, lệch làn). Màn hình 3 inch cảm ứng, kết nối WiFi với app 70mai. Thẻ nhớ tối đa 128GB.",
                Img         = "/images/product-2.jpg",
                Spec        = "Độ phân giải: 4K UHD | GPS tích hợp | ADAS | WiFi | Màn hình: 3 inch | Thẻ nhớ: đến 128GB | Góc quay: 140°",
                IsActive    = true
            },
            new Product
            {
                ProductName = "Vietmap C61 Pro 2K",
                Price       = 1890000,
                Category    = "Camera Hành Trình",
                Description = "Vietmap C61 Pro quay 2K Quad HD, WDR chống ngược sáng xuất sắc, góc rộng 170°. Bản đồ dẫn đường Vietmap tích hợp sẵn, cảnh báo tốc độ theo biển báo. Thương hiệu Việt Nam uy tín.",
                Img         = "/images/product-2.jpg",
                Spec        = "Độ phân giải: 2K QHD | WDR | Góc quay: 170° | Bản đồ Vietmap | Cảnh báo tốc độ | Thẻ nhớ: đến 64GB",
                IsActive    = true
            },
            new Product
            {
                ProductName = "Hikvision C6S 4K WiFi",
                Price       = 3200000,
                Category    = "Camera Hành Trình",
                Description = "Hikvision C6S 4K với công nghệ HDR (High Dynamic Range) giúp hình ảnh cực nét cả ban đêm. Kết nối WiFi, xem lại video trực tiếp qua smartphone. Thiết kế gọn nhẹ, lắp đặt dễ dàng.",
                Img         = "/images/product-2.jpg",
                Spec        = "Độ phân giải: 4K UHD | HDR | WiFi | Góc quay: 140° | Cảm biến: Sony STARVIS | Thẻ nhớ: đến 128GB",
                IsActive    = true
            }
        );

        // [B] Camera Nghị Định 10
        context.Products.AddRange(
            new Product
            {
                ProductName = "Vietmap ND10 Pro GPS Cloud",
                Price       = 4500000,
                Category    = "Camera Nghị Định 10",
                Description = "Camera đạt chuẩn Nghị Định 10/2020, truyền dữ liệu GPS lên Cloud 24/7 qua SIM 4G. Quay Full HD, lưu trữ đám mây, báo cáo hành trình tự động cho doanh nghiệp vận tải. Được Bộ GTVT cấp phép.",
                Img         = "/images/product-4.jpg",
                Spec        = "Chuẩn: Nghị Định 10/2020 | GPS Cloud | SIM 4G | Độ phân giải: 1080P | Lưu Cloud 24/7 | Báo cáo tự động",
                IsActive    = true
            },
            new Product
            {
                ProductName = "Huviron ND-10 GPS WiFi",
                Price       = 3800000,
                Category    = "Camera Nghị Định 10",
                Description = "Camera Huviron ND-10 chuẩn Nghị Định 10, GPS tracking WiFi + 4G. Màn hình LCD 2.4 inch hiển thị tốc độ và trạng thái. Thích hợp xe tải, xe khách, taxi. Lắp đặt bởi đội kỹ thuật chuyên nghiệp.",
                Img         = "/images/product-4.jpg",
                Spec        = "Chuẩn: Nghị Định 10/2020 | GPS | WiFi + 4G | Màn hình: 2.4 inch LCD | Độ phân giải: 1080P FHD | IP67",
                IsActive    = true
            },
            new Product
            {
                ProductName = "Hikvision ND10S 4G AI",
                Price       = 5200000,
                Category    = "Camera Nghị Định 10",
                Description = "Hikvision ND10S tích hợp AI phát hiện tài xế buồn ngủ, nghe điện thoại khi lái xe. Chuẩn NĐ10/2020, SIM 4G, GPS Cloud, cảnh báo thời gian thực qua app. Giải pháp toàn diện cho đội xe.",
                Img         = "/images/product-4.jpg",
                Spec        = "Chuẩn: Nghị Định 10/2020 | AI phát hiện buồn ngủ | SIM 4G | GPS Cloud | Độ phân giải: 1080P | Cảnh báo realtime",
                IsActive    = true
            }
        );

        // [C] Màn Hình Android
        context.Products.AddRange(
            new Product
            {
                ProductName = "GOTECH GT10 Pro 10 inch",
                Price       = 8500000,
                Category    = "Màn Hình Android",
                Description = "GOTECH GT10 Pro màn hình Android 10 inch, hệ điều hành Android 13 mượt mà, RAM 4GB ROM 64GB. Hỗ trợ CarPlay không dây, GPS offline, âm thanh DSP 32 kênh. Thương hiệu Việt Nam chất lượng cao.",
                Img         = "/images/product-1.jpg",
                Spec        = "RAM: 4GB | ROM: 64GB | Màn hình: 10 inch IPS | Android 13 | CarPlay | GPS offline | DSP 32-band | Bluetooth 5.0",
                IsActive    = true
            },
            new Product
            {
                ProductName = "GOTECH GT9 Max 9 inch",
                Price       = 7200000,
                Category    = "Màn Hình Android",
                Description = "GOTECH GT9 Max 9 inch Android 13 với thiết kế siêu mỏng 7mm. RAM 4GB, hỗ trợ SIM 4G, GPS Navigation offline, Camera lùi 1080P. Tương thích rộng với các dòng xe phổ thông.",
                Img         = "/images/product-1.jpg",
                Spec        = "RAM: 4GB | ROM: 32GB | Màn hình: 9 inch IPS | Android 13 | SIM 4G | GPS | Camera lùi 1080P | Bluetooth 5.0",
                IsActive    = true
            },
            new Product
            {
                ProductName = "GOTECH GT12 Ultra 12 inch",
                Price       = 12500000,
                Category    = "Màn Hình Android",
                Description = "GOTECH GT12 Ultra flagship 12 inch, RAM 6GB ROM 128GB Android 13. Màn hình IPS 2K sắc nét, CarPlay không dây, Camera 360° tương thích, DSP âm thanh 32 kênh cao cấp. Đỉnh cao của màn hình aftermarket.",
                Img         = "/images/product-1.jpg",
                Spec        = "RAM: 6GB | ROM: 128GB | Màn hình: 12 inch IPS 2K | Android 13 | CarPlay | Camera 360 | DSP 32-band | WiFi 6",
                IsActive    = true
            }
        );

        // [D] Màn Hình Android Ô Tô
        context.Products.AddRange(
            new Product
            {
                ProductName = "Xenon X9 Toyota - 9 inch",
                Price       = 9500000,
                Category    = "Màn Hình Android Ô Tô",
                Description = "Màn hình Xenon X9 tích hợp chuyên biệt cho xe Toyota (Camry, Vios, Fortuner, Innova). Khớp hoàn hảo với thiết kế taplo gốc, giữ nguyên chức năng điều hòa và các nút bấm vật lý. CarPlay không dây, DSP.",
                Img         = "/images/product-3.jpg",
                Spec        = "Phù hợp: Toyota | Màn hình: 9 inch IPS | Android 13 | RAM: 4GB | CarPlay không dây | DSP | GPS | Giữ nút gốc",
                IsActive    = true
            },
            new Product
            {
                ProductName = "Xenon X10 Honda - 10 inch",
                Price       = 10200000,
                Category    = "Màn Hình Android Ô Tô",
                Description = "Màn hình Xenon X10 tích hợp chuyên biệt cho xe Honda (CR-V, City, Civic, HR-V). Thiết kế liền mạch với taplo, hỗ trợ 4G, GPS Cloud, điều khiển giọng nói tiếng Việt. Bảo hành 2 năm chính hãng.",
                Img         = "/images/product-3.jpg",
                Spec        = "Phù hợp: Honda | Màn hình: 10 inch IPS | Android 13 | RAM: 4GB | 4G + GPS | CarPlay | Giọng nói tiếng Việt",
                IsActive    = true
            },
            new Product
            {
                ProductName = "Xenon X12 Mazda - 12 inch",
                Price       = 11800000,
                Category    = "Màn Hình Android Ô Tô",
                Description = "Màn hình Xenon X12 tích hợp chuyên biệt cho xe Mazda (CX-5, Mazda3, CX-8, CX-30). Màn hình 12 inch 2K, RAM 6GB, hỗ trợ giao diện Mazda Connect gốc song song Android. Cao cấp nhất phân khúc.",
                Img         = "/images/product-3.jpg",
                Spec        = "Phù hợp: Mazda | Màn hình: 12 inch IPS 2K | Android 13 | RAM: 6GB | Dual System | CarPlay | GPS | DSP cao cấp",
                IsActive    = true
            }
        );

        // ---------- 4. News — ảnh khớp đúng nội dung ----------
        context.News.AddRange(
            new News
            {
                Title     = "Xu hướng Màn Hình Android Ô Tô 2025: AI và không dây lên ngôi",
                Summary   = "Năm 2025, màn hình Android ô tô bùng nổ với AI nhận diện giọng nói tiếng Việt, CarPlay/Android Auto không dây và màn hình 2K cong. Những xu hướng nào đang dẫn đầu thị trường?",
                Content   = "Năm 2025 đánh dấu bước ngoặt lớn cho thị trường màn hình Android ô tô tại Việt Nam. AI tích hợp nhận diện giọng nói tiếng Việt chính xác 97%, điều khiển toàn bộ hệ thống giải trí không cần chạm tay.\n\nCarPlay và Android Auto không dây đã trở thành tiêu chuẩn bắt buộc — kết nối trong vòng dưới 3 giây. Màn hình 2K IPS từ 9-12 inch với RAM 4-6GB đang dần thay thế hoàn toàn màn hình zin theo xe trên các dòng xe tầm trung.\n\nCác thương hiệu Việt như GOTECH đang cạnh tranh sòng phẳng với hàng ngoại nhờ hỗ trợ tiếng Việt tốt hơn và bảo hành tại chỗ. Xenon với dòng màn hình tích hợp theo xe đang chiếm lĩnh phân khúc khách hàng muốn giữ thẩm mỹ nguyên gốc.",
                Img       = "/images/hero-car-screen.jpg",
                IsActive  = true,
                CreatedAt = new DateTime(2025, 1, 10, 9, 0, 0)
            },
            new News
            {
                Title     = "Top 3 Camera Hành Trình Tốt Nhất 2025 — Đánh giá thực tế",
                Summary   = "70mai A800S, Vietmap C61 Pro hay Hikvision C6S? Chúng tôi đã test cả 3 trên cùng một hành trình Hà Nội — Hải Phòng. Kết quả bất ngờ.",
                Content   = "Chúng tôi đã lắp cả 3 camera lên cùng một chiếc Toyota Camry và chạy 105km từ Hà Nội đi Hải Phòng để có kết quả khách quan nhất.\n\n70mai A800S 4K: Hình ảnh sắc nét nhất trong 3 máy, ADAS hoạt động đúng và không báo nhầm. GPS chính xác, app 70mai dễ dùng. Điểm trừ: giá cao nhất nhóm.\n\nVietmap C61 Pro 2K: WDR xuất sắc khi qua hầm và vào ban đêm. Bản đồ Vietmap tích hợp sẵn là điểm cộng lớn, không cần điện thoại. Phù hợp người lái đường dài nhiều.\n\nHikvision C6S: Cảm biến Sony STARVIS cho hình ảnh ban đêm đỉnh nhất nhóm. HDR xử lý tốt cảnh ngược sáng. Thương hiệu camera an ninh hàng đầu thế giới.\n\nKết luận: Ngân sách dưới 2 triệu → Vietmap C61 Pro. Cần ban đêm tốt nhất → Hikvision C6S. Muốn toàn diện nhất → 70mai A800S.",
                Img       = "/images/product-2.jpg",
                IsActive  = true,
                CreatedAt = new DateTime(2025, 2, 14, 10, 30, 0)
            },
            new News
            {
                Title     = "Camera Nghị Định 10: Xe nào bắt buộc lắp và lắp loại nào?",
                Summary   = "Nghị Định 10/2020 yêu cầu bắt buộc gắn camera có GPS cho xe kinh doanh vận tải. Hướng dẫn đầy đủ để tránh bị phạt và chọn đúng thiết bị hợp chuẩn.",
                Content   = "Nghị Định 10/2020 của Chính phủ (sửa đổi bổ sung NĐ86/2014) quy định xe ô tô kinh doanh vận tải hành khách từ 9 chỗ trở lên, xe tải trên 3.5 tấn, xe taxi phải lắp camera giám sát hành trình.\n\nYêu cầu kỹ thuật của camera NĐ10:\n- Quay video liên tục, lưu trữ tối thiểu 3 ngày gần nhất\n- Truyền dữ liệu GPS lên server Cục ĐBVN theo thời gian thực\n- Kết nối SIM 4G, không được mất kết nối quá 10 phút\n- Camera hướng vào cabin ghi lại hành vi tài xế\n\nXe nào BẮT BUỘC: Taxi, xe hợp đồng từ 9 chỗ+, xe du lịch, xe tải >3.5 tấn, xe đầu kéo.\n\nXe KHÔNG bắt buộc: Xe con cá nhân dưới 9 chỗ không kinh doanh vận tải.\n\nMức phạt khi vi phạm: 3-5 triệu đồng/lần kiểm tra. Có thể bị đình chỉ hoạt động.",
                Img       = "/images/product-4.jpg",
                IsActive  = true,
                CreatedAt = new DateTime(2025, 3, 5, 8, 0, 0)
            },
            new News
            {
                Title     = "Màn Hình Android Ô Tô Tích Hợp vs Aftermarket: Nên chọn loại nào?",
                Summary   = "Màn hình tích hợp theo xe (Toyota, Honda, Mazda...) hay màn hình aftermarket phổ thông? Phân tích chi tiết ưu nhược điểm để bạn đưa ra quyết định đúng.",
                Content   = "Thị trường chia làm 2 dòng chính: màn hình tích hợp theo xe cụ thể và màn hình aftermarket phổ thông (dùng cho nhiều xe).\n\nMÀN HÌNH TÍCH HỢP THEO XE (Xenon, Joying, Eonon):\n✅ Ưu điểm: Khớp hoàn hảo với taplo, giữ nguyên nút vật lý, thẩm mỹ cao cấp, tương thích 100% với hệ thống điện xe\n❌ Nhược điểm: Giá cao hơn 20-40%, phải chọn đúng model xe\n\nMÀN HÌNH AFTERMARKET PHỔ THÔNG (GOTECH, Android box):\n✅ Ưu điểm: Giá tốt hơn, linh hoạt thay xe, cộng đồng hỗ trợ lớn\n❌ Nhược điểm: Cần frame lắp thêm, không giữ được nút vật lý gốc\n\nKHUYẾN NGHỊ: Nếu xe còn mới và bạn không có kế hoạch đổi xe trong 3-5 năm → màn hình tích hợp theo xe xứng đáng. Nếu xe cũ hoặc muốn linh hoạt → aftermarket phổ thông.",
                Img       = "/images/product-3.jpg",
                IsActive  = true,
                CreatedAt = new DateTime(2025, 4, 20, 14, 0, 0)
            },
            new News
            {
                Title     = "Hướng dẫn lắp đặt Camera Hành Trình đúng cách — Tránh 5 lỗi phổ biến",
                Summary   = "Lắp camera hành trình sai vị trí, sai góc quay, đi dây lộn xộn khiến camera hoạt động kém hoặc hỏng sớm. 5 lỗi phổ biến nhất và cách khắc phục.",
                Content   = "Lỗi 1 — Lắp sai vị trí: Camera phải nằm phía sau gương chiếu hậu, góc dưới kính. Không lắp quá cao (cắt mất tầm nhìn) hay quá thấp (bị nắp capo che khuất).\n\nLỗi 2 — Góc quay sai: Điều chỉnh để camera thấy đường và biển số xe phía trước. Test bằng cách xem lại video ngay sau khi lắp.\n\nLỗi 3 — Đi dây qua gioăng cửa: Dây bị kẹp sẽ bong cách điện, chạm mass gây cháy. Luôn đi dây qua nẹp nhựa nội thất hoặc dưới tấm ốp trần.\n\nLỗi 4 — Dùng thẻ nhớ không đủ chuẩn: Camera 4K cần thẻ Class 10 / U3. Dùng thẻ rẻ sẽ bị drop frame, video mờ, thậm chí không ghi được.\n\nLỗi 5 — Không bật chế độ loop recording: Nếu không bật, khi đầy thẻ camera dừng ghi. Phải đặt chế độ ghi đè (loop) để luôn có video mới nhất.",
                Img       = "/images/product-2.jpg",
                IsActive  = true,
                CreatedAt = new DateTime(2025, 5, 8, 11, 0, 0)
            }
        );

        // ---------- 5. Orders ----------
        context.Orders.AddRange(
            new Order { ProductName = "GOTECH GT10 Pro 10 inch",      Price = "8,500,000", Quantity = 1, TotalAmount = "8,500,000",  FullName = "Nguyễn Văn An",   Phone = "0901234567", Img = "/images/product-1.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 3, 10, 10, 30, 0) },
            new Order { ProductName = "Vietmap ND10 Pro GPS Cloud",   Price = "4,500,000", Quantity = 1, TotalAmount = "4,500,000",  FullName = "Trần Thị Bình",   Phone = "0912345678", Img = "/images/product-4.jpg", Status = "Đang xử lý",     CreatedAt = new DateTime(2025, 4, 2,  14, 15, 0) },
            new Order { ProductName = "Camera 70mai A800S 4K",        Price = "2,990,000", Quantity = 1, TotalAmount = "2,990,000",  FullName = "Lê Hoàng Dũng",   Phone = "0923456789", Img = "/images/product-2.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 4, 10, 9,  0,  0) },
            new Order { ProductName = "Xenon X9 Toyota - 9 inch",     Price = "9,500,000", Quantity = 1, TotalAmount = "9,500,000",  FullName = "Phạm Minh Tuấn",  Phone = "0934567890", Img = "/images/product-3.jpg", Status = "Chờ xác nhận",   CreatedAt = new DateTime(2025, 4, 18, 16, 45, 0) },
            new Order { ProductName = "GOTECH GT12 Ultra 12 inch",    Price = "12,500,000",Quantity = 1, TotalAmount = "12,500,000", FullName = "Hoàng Thị Mai",   Phone = "0945678901", Img = "/images/product-1.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 5, 1,  8,  30, 0) },
            new Order { ProductName = "Hikvision ND10S 4G AI",        Price = "5,200,000", Quantity = 2, TotalAmount = "10,400,000", FullName = "Vũ Đức Khải",     Phone = "0956789012", Img = "/images/product-4.jpg", Status = "Đang giao hàng", CreatedAt = new DateTime(2025, 5, 20, 13, 0,  0) },
            new Order { ProductName = "Xenon X10 Honda - 10 inch",    Price = "10,200,000",Quantity = 1, TotalAmount = "10,200,000", FullName = "Đỗ Thanh Long",   Phone = "0967890123", Img = "/images/product-3.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 6, 1,  15, 0,  0) },
            new Order { ProductName = "Vietmap C61 Pro 2K",           Price = "1,890,000", Quantity = 3, TotalAmount = "5,670,000",  FullName = "Bùi Thị Hương",   Phone = "0978901234", Img = "/images/product-2.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 6, 5,  10, 0,  0) }
        );

        context.SaveChanges();
        Console.WriteLine("✅ Seed data 4 danh mục chuẩn + ảnh đúng nội dung hoàn tất!");
    }
}
