using CarTechShowcase.Models;

namespace CarTechShowcase.Data;

public static class SeedData
{
    // ── HTML description builder ──────────────────────────────────────────────
    private static string Html(string name, string intro, string[] specs, string[] pros, string box = "")
    {
        var specRows = string.Join("", specs.Select((s, i) =>
        {
            var parts = s.Split(':', 2);
            var label = parts[0].Trim();
            var val   = parts.Length > 1 ? parts[1].Trim() : s;
            var bg    = i % 2 == 0 ? "#1e1e1e" : "#161616";
            return $"<tr style='background:{bg}'><td style='padding:8px 12px;border:1px solid #333;font-weight:600;width:40%;color:#ccc'>{label}</td><td style='padding:8px 12px;border:1px solid #333;color:#eee'>{val}</td></tr>";
        }));
        var proItems = string.Join("", pros.Select(p => $"<li style='margin-bottom:6px'>{p}</li>"));
        var boxContent = string.IsNullOrEmpty(box)
            ? "<li>01 Sản phẩm chính</li><li>01 Hướng dẫn sử dụng tiếng Việt</li><li>01 Dây nguồn 4m + đầu cắm cốc xe</li><li>01 Giá đỡ kính + băng keo 3M</li>"
            : box;
        return $@"<h2 style='font-size:1.4em;margin-bottom:12px'>{name}</h2>
<p style='line-height:1.8;margin-bottom:16px'>{intro}</p>
<h3 style='border-left:4px solid #ff6b00;padding-left:10px;margin:20px 0 12px'>📋 Thông số kỹ thuật chi tiết</h3>
<table style='width:100%;border-collapse:collapse;margin-bottom:20px'>
{specRows}
</table>
<h3 style='border-left:4px solid #ff6b00;padding-left:10px;margin:20px 0 12px'>✅ Điểm nổi bật</h3>
<ul style='line-height:1.9;padding-left:20px;margin-bottom:20px'>
{proItems}
</ul>
<h3 style='border-left:4px solid #ff6b00;padding-left:10px;margin:20px 0 12px'>📦 Nội dung hộp sản phẩm</h3>
<ul style='line-height:1.9;padding-left:20px;margin-bottom:20px'>
{boxContent}
</ul>
<h3 style='border-left:4px solid #ff6b00;padding-left:10px;margin:20px 0 12px'>🛡️ Chính sách bảo hành</h3>
<p style='line-height:1.9'>✅ Bảo hành chính hãng 12–24 tháng tại hệ thống VinMap toàn quốc<br/>
✅ Đổi mới trong 7 ngày nếu lỗi nhà sản xuất<br/>
✅ Giao hàng toàn quốc 2–5 ngày, <strong>lắp đặt miễn phí tại TP.HCM và Hà Nội</strong><br/>
✅ Hotline hỗ trợ kỹ thuật 24/7: <strong style='color:#ff6b00'>0909-123-456</strong></p>";
    }

    public static void Initialize(AppDbContext context)
    {
        // ── 1. Banners ─────────────────────────────────────────────────────────
        context.Banners.AddRange(
            new Banner { Banner1 = "/images/hero-car-screen.jpg", Banner2 = "/images/product-1.jpg", IsActive = true },
            new Banner { Banner1 = "/images/product-2.jpg",       Banner2 = "/images/product-3.jpg", IsActive = true }
        );

        // ── 2. CarScreens ──────────────────────────────────────────────────────
        context.CarScreens.AddRange(
            new CarScreen { ScreenName = "Màn hình Android 10\" Taplo",   Location = "Taplo trung tâm",      Note = "Android 12, RAM 4GB, GPS, SIM 4G, Camera lùi",               TypeId = 1, IsActive = true },
            new CarScreen { ScreenName = "Màn hình Android 9\" IPS",      Location = "Taplo trung tâm",      Note = "CarPlay không dây, Android Auto, DSP 8-band",                TypeId = 1, IsActive = true },
            new CarScreen { ScreenName = "Màn hình Ô Tô Toyota 9\"",      Location = "Taplo trung tâm",      Note = "Tích hợp theo xe Toyota Camry, Vios, Fortuner",              TypeId = 1, IsActive = true },
            new CarScreen { ScreenName = "Màn hình Ô Tô Honda 10\"",      Location = "Taplo trung tâm",      Note = "Tích hợp theo xe Honda CR-V, City, Civic",                   TypeId = 1, IsActive = true },
            new CarScreen { ScreenName = "Camera Hành Trình 4K",          Location = "Kính chắn gió trước", Note = "4K UHD, GPS, WiFi, G-Sensor, Parking Monitor 24/7",          TypeId = 2, IsActive = true },
            new CarScreen { ScreenName = "Camera Nghị Định 10 GPS Cloud", Location = "Kính chắn gió trước", Note = "Chuẩn NĐ10/2020, GPS Cloud, truyền dữ liệu 4G thời gian thực", TypeId = 3, IsActive = true }
        );

        // ── 3. Products ────────────────────────────────────────────────────────

        // [A] Camera Hành Trình (6 sản phẩm)
        context.Products.AddRange(
            new Product
            {
                ProductName = "Camera 70mai A800S 4K",
                Price       = 2990000,
                Category    = "Camera Hành Trình",
                Description = "Camera hành trình 70mai A800S quay 4K Ultra HD, tích hợp GPS, cảnh báo ADAS thông minh. Màn hình 3 inch cảm ứng, kết nối WiFi.",
                Img  = "/images/product-2.jpg",
                Img2 = "/images/product-1.jpg",
                Img3 = "/images/product-3.jpg",
                Img4 = "/images/hero-car-screen.jpg",
                Spec = "Độ phân giải: 4K UHD | GPS tích hợp | ADAS | WiFi | Màn hình: 3 inch | Thẻ nhớ: đến 128GB | Góc quay: 140°",
                ContentHtml = Html(
                    "Camera 70mai A800S 4K — Flagship 4K Ultra HD",
                    "70mai A800S là đỉnh cao dòng camera hành trình của thương hiệu 70mai (Xiaomi). Với cảm biến Sony IMX415 và độ phân giải 4K UHD thực sự, mỗi khung hình đều rõ nét đến từng biển số xe. Hệ thống ADAS (Advanced Driver Assistance System) cảnh báo khoảng cách, lệch làn, giúp bạn lái xe an toàn hơn mỗi ngày.",
                    new[] { "Độ phân giải: 4K UHD 3840×2160 30fps", "Cảm biến: Sony IMX415", "GPS: Tích hợp sẵn (Glonass + GPS)", "Góc quay: 140° siêu rộng", "Màn hình: 3 inch IPS cảm ứng", "ADAS: Cảnh báo khoảng cách + lệch làn", "WiFi: 5GHz kết nối app 70mai", "Thẻ nhớ: MicroSD đến 128GB Class10", "Chống rung: EIS điện tử 6 trục", "Dải nhiệt độ: -20°C đến 70°C" },
                    new[] { "Video 4K cực nét, nhận rõ biển số xe ngay cả đêm tối nhờ chế độ WDR nâng cao", "GPS chính xác cao, theo dõi hành trình và tốc độ trên bản đồ trực tiếp", "ADAS cảnh báo thông minh: khoảng cách xe phía trước, lệch làn đường, đèn đỏ", "Kết nối WiFi 5GHz, xem lại video trên điện thoại siêu nhanh qua app 70mai", "Thiết kế nhỏ gọn 59×33mm, không che khuất tầm nhìn người lái", "Ghi đè tự động khi đầy thẻ, không bao giờ lo mất video mới nhất" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Vietmap C61 Pro 2K",
                Price       = 1890000,
                Category    = "Camera Hành Trình",
                Description = "Vietmap C61 Pro quay 2K Quad HD, WDR chống ngược sáng xuất sắc, góc rộng 170°. Bản đồ dẫn đường Vietmap tích hợp sẵn.",
                Img  = "/images/product-2.jpg",
                Img2 = "/images/product-4.jpg",
                Img3 = "/images/product-1.jpg",
                Spec = "Độ phân giải: 2K QHD | WDR | Góc quay: 170° | Bản đồ Vietmap | Cảnh báo tốc độ | Thẻ nhớ: đến 64GB",
                ContentHtml = Html(
                    "Vietmap C61 Pro 2K — Bản đồ tích hợp, WDR đỉnh cao",
                    "Vietmap C61 Pro là camera hành trình 2K của thương hiệu Việt Nam hàng đầu Vietmap. Điểm khác biệt lớn nhất so với đối thủ là bản đồ Vietmap được tích hợp sẵn trong máy — không cần điện thoại, không cần internet vẫn có chỉ đường và cảnh báo tốc độ theo biển báo.",
                    new[] { "Độ phân giải: 2K QHD 2560×1440 30fps", "Cảm biến: OV4689 1/3\"", "Góc quay: 170° cực rộng", "WDR: High Dynamic Range chống ngược sáng", "Bản đồ: Vietmap tích hợp sẵn", "Cảnh báo tốc độ: Theo biển báo GPS", "Màn hình: 2.7 inch LCD", "Thẻ nhớ: MicroSD đến 64GB", "Ghi đè: Loop recording tự động" },
                    new[] { "Bản đồ Vietmap tích hợp sẵn — không cần điện thoại, cảnh báo tốc độ theo biển báo", "WDR (Wide Dynamic Range) xuất sắc, xử lý tốt khi vào hầm hay lúc ngược sáng", "Góc quay 170° siêu rộng, ghi lại toàn cảnh làn đường 4-6 xe", "Thương hiệu Việt Nam uy tín 10+ năm, bảo hành và hỗ trợ tại chỗ dễ dàng", "Giá tốt nhất phân khúc 2K, đáng đồng tiền cho người mới bắt đầu dùng camera hành trình", "Cập nhật bản đồ và phần mềm miễn phí trọn đời" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Hikvision C6S 4K WiFi",
                Price       = 3200000,
                Category    = "Camera Hành Trình",
                Description = "Hikvision C6S 4K với công nghệ HDR giúp hình ảnh cực nét cả ban đêm. Kết nối WiFi, xem lại video trực tiếp qua smartphone.",
                Img  = "/images/product-2.jpg",
                Img2 = "/images/hero-car-screen.jpg",
                Img3 = "/images/product-4.jpg",
                Img4 = "/images/product-3.jpg",
                Spec = "Độ phân giải: 4K UHD | HDR | WiFi | Góc quay: 140° | Cảm biến: Sony STARVIS | Thẻ nhớ: đến 128GB",
                ContentHtml = Html(
                    "Hikvision C6S 4K — Cảm biến Sony STARVIS, ban đêm rõ như ban ngày",
                    "Hikvision là thương hiệu camera an ninh số 1 thế giới với hơn 50 năm kinh nghiệm. C6S là sản phẩm camera hành trình đầu bảng của họ, trang bị cảm biến Sony STARVIS cho hiệu năng ban đêm vượt trội mà không camera hành trình nào ở mức giá này có thể sánh kịp.",
                    new[] { "Độ phân giải: 4K UHD 3840×2160", "Cảm biến: Sony STARVIS IMX317", "HDR: High Dynamic Range thế hệ mới", "Góc quay: 140° với kính không méo WLP", "WiFi: 2.4GHz + 5GHz dual-band", "Thẻ nhớ: MicroSD đến 128GB", "Parking Mode: Ghi khi có va chạm", "Dải nhiệt độ: -30°C đến 75°C", "G-Sensor: 3 trục khóa video sự cố" },
                    new[] { "Sony STARVIS cảm biến ánh sáng thấp đỉnh nhất — đêm tối vẫn thấy rõ biển số xe đối diện", "HDR thế hệ mới xử lý hoàn hảo cả cảnh ngược sáng mạnh lẫn bóng tối sâu", "Thương hiệu Hikvision uy tín toàn cầu, linh kiện chuẩn công nghiệp bền bỉ hơn hàng tiêu dùng thông thường", "Parking Mode giám sát 24/7 khi tắt máy — phát hiện va chạm, ghi lại kẻ xấu gõ cửa xe", "App Hik-Connect trực quan, livestream xem camera ngay trên điện thoại", "Bảo hành 24 tháng chính hãng tại Việt Nam" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Camera 70mai Dash Cam M300",
                Price       = 990000,
                Category    = "Camera Hành Trình",
                Description = "70mai M300 — Camera hành trình entry-level 1296P cực nhỏ gọn, giá siêu hợp lý. Lý tưởng cho người mới bắt đầu.",
                Img  = "/images/product-2.jpg",
                Img2 = "/images/product-1.jpg",
                Img3 = "/images/product-4.jpg",
                Spec = "Độ phân giải: 1296P QHD | WiFi | Góc quay: 140° | G-Sensor | Thẻ nhớ: đến 64GB | App 70mai",
                ContentHtml = Html(
                    "Camera 70mai M300 — Entry-level thông minh, giá dưới 1 triệu",
                    "70mai M300 là lựa chọn hoàn hảo cho những ai muốn có một chiếc camera hành trình chất lượng tốt với ngân sách dưới 1 triệu đồng. Không đánh đổi quá nhiều về chất lượng hình ảnh (1296P) nhưng vẫn có WiFi, G-Sensor và ứng dụng thông minh.",
                    new[] { "Độ phân giải: 1296P (2304×1296) 30fps", "Cảm biến: CMOS 3MP", "WiFi: 2.4GHz (kết nối app 70mai)", "Góc quay: 140°", "G-Sensor: Tự động lưu video khi va chạm", "Thẻ nhớ: MicroSD đến 64GB", "Kích thước: 63.8×31.2×33mm siêu nhỏ", "Ghi đêm: F2.0 khẩu độ lớn" },
                    new[] { "Giá dưới 1 triệu nhưng chất lượng vượt xa mức giá — lý tưởng cho xe cũ hoặc mới bắt đầu", "Siêu nhỏ gọn, gần như vô hình sau gương chiếu hậu, không che tầm nhìn", "WiFi kết nối app 70mai — xem lại, tải video, cài đặt ngay trên điện thoại", "G-Sensor tự động khóa và lưu video khi phanh gấp hoặc va chạm", "Thương hiệu 70mai (Xiaomi) uy tín, linh kiện chất lượng cao" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Vietmap G79 2K WiFi GPS",
                Price       = 2490000,
                Category    = "Camera Hành Trình",
                Description = "Vietmap G79 màn hình lớn 3.5 inch, quay 2K, GPS + Bản đồ tích hợp, cảnh báo tốc độ, camera sau tùy chọn.",
                Img  = "/images/product-2.jpg",
                Img2 = "/images/product-3.jpg",
                Img3 = "/images/hero-car-screen.jpg",
                Spec = "Độ phân giải: 2K QHD | Màn hình: 3.5 inch | GPS | Bản đồ Vietmap | Camera sau: Tùy chọn | WiFi | Thẻ nhớ: 128GB",
                ContentHtml = Html(
                    "Vietmap G79 — Màn hình 3.5 inch, GPS và bản đồ đầy đủ",
                    "Vietmap G79 là camera hành trình cao cấp hơn với màn hình lớn 3.5 inch, cho phép xem bản đồ dẫn đường và hình ảnh camera trực tiếp ngay trên màn hình mà không cần điện thoại. Hỗ trợ kết nối camera sau để ghi toàn cảnh trước-sau cùng lúc.",
                    new[] { "Độ phân giải trước: 2K QHD 60fps", "Màn hình: 3.5 inch IPS màu", "GPS: Glonass + GPS dual", "Bản đồ: Vietmap offline 3D", "Camera sau: Hỗ trợ thêm (bán kèm)", "WiFi: 2.4GHz + app Vietmap", "Thẻ nhớ: MicroSD đến 128GB", "Ghi đêm: Super Night Vision 2.0" },
                    new[] { "Màn hình 3.5 inch lớn — xem bản đồ dẫn đường và hình ảnh camera song song ngay trên thiết bị", "Ghi đồng thời trước + sau với camera sau tùy chọn — bằng chứng toàn diện 360°", "Super Night Vision 2.0 — công nghệ tăng sáng ban đêm thuần Việt Nam phát triển", "Bản đồ Vietmap cập nhật 4 lần/năm miễn phí, dữ liệu Việt Nam chuẩn nhất", "Wifi xem video, tải clip, điều chỉnh cài đặt từ điện thoại không cần lấy thẻ nhớ" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "BlackVue DR900X-2CH 4K",
                Price       = 6500000,
                Category    = "Camera Hành Trình",
                Description = "BlackVue DR900X flagship Hàn Quốc — 4K trước, 1080P sau, WiFi + LTE cloud, parking mode 24/7. Đỉnh cao camera hành trình.",
                Img  = "/images/product-2.jpg",
                Img2 = "/images/product-4.jpg",
                Img3 = "/images/product-1.jpg",
                Img4 = "/images/product-3.jpg",
                Img5 = "/images/hero-car-screen.jpg",
                Spec = "Camera trước: 4K UHD | Camera sau: 1080P FHD | WiFi + LTE | Cloud BlackVue | Parking 24/7 | Thẻ nhớ: đến 256GB | Sony STARVIS 2",
                ContentHtml = Html(
                    "BlackVue DR900X-2CH 4K — Đỉnh cao camera hành trình 2 kênh Hàn Quốc",
                    "BlackVue DR900X-2CH là flagship camera hành trình cao cấp nhất của BlackVue (Hàn Quốc) — thương hiệu camera hành trình được ưa chuộng nhất tại Âu Mỹ và Nhật Bản. Với cảm biến Sony STARVIS 2 thế hệ mới, ghi 4K trước và 1080P sau, LTE kết nối cloud mọi lúc mọi nơi.",
                    new[] { "Camera trước: 4K UHD 30fps (Sony STARVIS 2)", "Camera sau: 1080P FHD 60fps", "LTE: Kết nối internet 4G tích hợp", "Cloud: BlackVue Cloud — xem video từ bất kỳ đâu", "WiFi: 5GHz kết nối trực tiếp điện thoại", "Parking: Mode 24/7 có pin dự phòng", "Thẻ nhớ: eMMC 64GB tích hợp + MicroSD đến 256GB", "GPS: Glonass + GPS + BeiDou triple", "App: BlackVue (iOS + Android)" },
                    new[] { "4K trước + 1080P sau — toàn bộ sự cố từ mọi góc độ đều được ghi lại với độ nét cực cao", "LTE cloud — xem video trực tiếp từ điện thoại dù xe đang đỗ ở Hà Nội trong khi bạn ở Sài Gòn", "Sony STARVIS 2 — cảm biến ban đêm tốt nhất trong lịch sử camera hành trình dân dụng", "Parking mode 24/7 với chế độ tiết kiệm pin (sleep mode) bảo vệ xe suốt đêm", "eMMC 64GB tích hợp — dữ liệu không bao giờ mất dù mất thẻ nhớ", "Thương hiệu BlackVue uy tín 15 năm, bảo hành 2 năm chính hãng" }
                ),
                IsActive = true
            }
        );

        // [B] Camera Nghị Định 10 (6 sản phẩm)
        context.Products.AddRange(
            new Product
            {
                ProductName = "Vietmap ND10 Pro GPS Cloud",
                Price       = 4500000,
                Category    = "Camera Nghị Định 10",
                Description = "Camera đạt chuẩn Nghị Định 10/2020, truyền dữ liệu GPS lên Cloud 24/7 qua SIM 4G. Được Bộ GTVT cấp phép.",
                Img  = "/images/product-4.jpg",
                Img2 = "/images/product-2.jpg",
                Img3 = "/images/product-3.jpg",
                Img4 = "/images/hero-car-screen.jpg",
                Spec = "Chuẩn: Nghị Định 10/2020 | GPS Cloud | SIM 4G | Độ phân giải: 1080P | Lưu Cloud 24/7 | Báo cáo tự động",
                ContentHtml = Html(
                    "Vietmap ND10 Pro — Camera chuẩn Nghị Định 10 uy tín nhất thị trường",
                    "Vietmap ND10 Pro là camera hành trình dành cho xe kinh doanh vận tải đạt chuẩn Nghị Định 10/2020 của Chính phủ. Được Cục Đường bộ Việt Nam cấp phép và đã lắp đặt cho hơn 50,000 xe trên toàn quốc. Tích hợp SIM 4G riêng, truyền GPS + video lên Cloud 24/7.",
                    new[] { "Chuẩn: Nghị Định 10/2020 (Bộ GTVT cấp phép)", "Độ phân giải: 1080P FHD 30fps (trước) + 720P (cabin)", "GPS: Glonass + GPS, độ chính xác ±5m", "Kết nối: SIM 4G LTE riêng tích hợp", "Cloud: Server Cục ĐBVN + server doanh nghiệp", "Lưu trữ: Cloud 90 ngày + thẻ nhớ 32GB tại chỗ", "Báo cáo: Hành trình, tốc độ, vi phạm tự động", "Cảnh báo: Buồn ngủ, dùng điện thoại, mất làn" },
                    new[] { "Đạt chuẩn NĐ10/2020 — doanh nghiệp lắp là đủ điều kiện kinh doanh, không bị phạt", "SIM 4G tích hợp sẵn, kết nối liên tục, không phụ thuộc wifi hay điện thoại tài xế", "Server Cloud 24/7 — quản lý đội xe từ xa, xem vị trí và video trực tiếp qua web/app", "Báo cáo hành trình tự động gửi email/SMS cho quản lý mỗi ngày", "Cảnh báo thời gian thực: tài xế buồn ngủ, lái xe quá giờ quy định, vượt tốc độ" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Huviron ND-10 GPS WiFi 4G",
                Price       = 3800000,
                Category    = "Camera Nghị Định 10",
                Description = "Camera Huviron ND-10 chuẩn Nghị Định 10, GPS tracking WiFi + 4G. Màn hình LCD 2.4 inch. Thích hợp xe tải, xe khách, taxi.",
                Img  = "/images/product-4.jpg",
                Img2 = "/images/product-1.jpg",
                Img3 = "/images/product-2.jpg",
                Spec = "Chuẩn: Nghị Định 10/2020 | GPS | WiFi + 4G | Màn hình: 2.4 inch LCD | Độ phân giải: 1080P FHD | IP67",
                ContentHtml = Html(
                    "Huviron ND-10 — Giải pháp tầm trung chuẩn Nghị Định 10",
                    "Huviron ND-10 là giải pháp cân bằng giữa chi phí và tính năng cho doanh nghiệp vận tải vừa và nhỏ. Đạt đầy đủ chuẩn Nghị Định 10/2020, có màn hình hiển thị thông tin trực tiếp cho tài xế, chống nước IP67.",
                    new[] { "Chuẩn: Nghị Định 10/2020", "Độ phân giải: 1080P FHD 30fps", "Màn hình: 2.4 inch LCD màu", "GPS: Glonass + GPS chính xác ±3m", "Kết nối: WiFi 2.4GHz + 4G LTE", "Chống nước: IP67 (hoàn toàn kín nước)", "Thẻ nhớ: 32GB tích hợp + MicroSD 128GB", "Cảnh báo: Tốc độ, quay đầu xe, ra vào vùng địa lý" },
                    new[] { "IP67 chống nước hoàn toàn — lắp bên ngoài xe tải không sợ mưa hay rửa xe", "Màn hình 2.4 inch tài xế xem tốc độ và cảnh báo ngay trên camera — không cần thiết bị thêm", "WiFi + 4G dual connectivity — luôn online dù ở vùng phủ sóng kém", "Giá hợp lý nhất phân khúc NĐ10, phù hợp đội xe nhỏ 5-20 chiếc", "Phần mềm quản lý đội xe web-based, không cần cài app, dùng ngay trên trình duyệt" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Hikvision ND10S 4G AI",
                Price       = 5200000,
                Category    = "Camera Nghị Định 10",
                Description = "Hikvision ND10S tích hợp AI phát hiện tài xế buồn ngủ, nghe điện thoại khi lái. Chuẩn NĐ10/2020, SIM 4G, GPS Cloud.",
                Img  = "/images/product-4.jpg",
                Img2 = "/images/product-3.jpg",
                Img3 = "/images/hero-car-screen.jpg",
                Img4 = "/images/product-2.jpg",
                Spec = "Chuẩn: Nghị Định 10/2020 | AI phát hiện buồn ngủ | SIM 4G | GPS Cloud | Độ phân giải: 1080P | Cảnh báo realtime",
                ContentHtml = Html(
                    "Hikvision ND10S — AI an toàn giao thông, chuẩn Nghị Định 10",
                    "Hikvision ND10S là camera NĐ10 cao cấp nhất với công nghệ AI nhận diện hành vi tài xế: buồn ngủ, phân tâm, sử dụng điện thoại, hút thuốc trong ca lái. Đây là giải pháp quản lý an toàn đội xe toàn diện nhất cho doanh nghiệp lớn.",
                    new[] { "Chuẩn: Nghị Định 10/2020", "AI: Nhận diện buồn ngủ, điện thoại, hút thuốc, mất tập trung", "Camera: 1080P FHD trước + 720P cabin AI", "SIM 4G: Tích hợp dual SIM dự phòng", "GPS Cloud: Server Hikvision + Cục ĐBVN", "Cảnh báo: Realtime qua app + loa cảnh báo trong cabin", "Nhiệt độ: -40°C đến 85°C cấp công nghiệp", "Chứng chỉ: CE, FCC, ROHS, Bộ GTVT VN" },
                    new[] { "AI DMS (Driver Monitoring System) — phát hiện tài xế buồn ngủ và cảnh báo ngay lập tức, ngăn chặn tai nạn trước khi xảy ra", "Dual SIM 4G — luôn có kết nối dự phòng, đảm bảo không bao giờ mất liên lạc với trung tâm", "Nhiệt độ hoạt động cấp công nghiệp -40°C → +85°C, hoạt động ổn định mọi điều kiện thời tiết", "Tích hợp hệ thống quản lý Hikvision HikCentral — nền tảng quản lý đội xe chuyên nghiệp nhất thế giới", "Phù hợp xe tải nặng, xe container, xe khách đường dài — cần mức độ an toàn và giám sát cao nhất" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "VinCam Pro ND-10 LTE Cloud",
                Price       = 3500000,
                Category    = "Camera Nghị Định 10",
                Description = "VinCam Pro — Giải pháp NĐ10 giá tốt nhất thị trường, lắp đặt nhanh trong 30 phút, quản lý đội xe qua web.",
                Img  = "/images/product-4.jpg",
                Img2 = "/images/product-2.jpg",
                Img3 = "/images/product-1.jpg",
                Spec = "Chuẩn: Nghị Định 10/2020 | 4G LTE | GPS Cloud | 1080P | Web quản lý | Lắp đặt 30 phút | Hỗ trợ 24/7",
                ContentHtml = Html(
                    "VinCam Pro ND-10 LTE — Giá rẻ nhất, chuẩn đủ NĐ10",
                    "VinCam Pro hướng đến phân khúc xe taxi, xe hợp đồng nhỏ lẻ với giá lắp đặt thấp nhất mà vẫn đầy đủ chuẩn Nghị Định 10. Quy trình lắp đặt chỉ 30 phút, kích hoạt SIM ngay tại chỗ, sử dụng được trong ngày.",
                    new[] { "Chuẩn: Nghị Định 10/2020 (đã được phê duyệt)", "Độ phân giải: 1080P FHD", "Kết nối: 4G LTE (SIM Viettel/Vina tương thích)", "GPS: Cập nhật vị trí mỗi 5 giây", "Lưu trữ: Cloud 30 ngày + thẻ nhớ 32GB", "Web quản lý: vincam.vn không cần cài app", "Lắp đặt: 30 phút, kích hoạt tức thì", "Hỗ trợ: Kỹ thuật 8h-22h hằng ngày" },
                    new[] { "Giá lắp đặt thấp nhất thị trường NĐ10 — tiết kiệm chi phí đầu tư cho chủ xe taxi, xe hợp đồng", "Kích hoạt SIM tại chỗ, sử dụng ngay trong ngày — không chờ đợi thủ tục phức tạp", "Web quản lý đơn giản, không cần đào tạo, chủ xe tự xem báo cáo trên điện thoại", "Hỗ trợ kỹ thuật 8h-22h, có nhân viên đến tận nơi xử lý sự cố trong vòng 4 giờ tại TP.HCM" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Navicom ND10 GPS 4G Pro",
                Price       = 4100000,
                Category    = "Camera Nghị Định 10",
                Description = "Navicom ND10 — Camera NĐ10 với màn hình 3.5 inch cảm ứng, xem video trực tiếp và cài đặt ngay trên màn hình.",
                Img  = "/images/product-4.jpg",
                Img2 = "/images/hero-car-screen.jpg",
                Img3 = "/images/product-3.jpg",
                Spec = "Chuẩn: Nghị Định 10/2020 | Màn hình: 3.5 inch cảm ứng | 4G | GPS | 1080P | Thẻ nhớ: 64GB | Cảnh báo tốc độ",
                ContentHtml = Html(
                    "Navicom ND10 Pro — Màn hình 3.5 inch, chuẩn NĐ10 dễ dùng nhất",
                    "Navicom ND10 Pro là camera NĐ10 duy nhất trên thị trường có màn hình cảm ứng 3.5 inch tích hợp, cho phép tài xế xem trực tiếp hình ảnh camera, kiểm tra kết nối và tốc độ ngay trên thiết bị mà không cần điện thoại hay thiết bị ngoại vi.",
                    new[] { "Chuẩn: Nghị Định 10/2020", "Màn hình: 3.5 inch IPS cảm ứng điện dung", "Độ phân giải: 1080P FHD trước + 720P sau (cabin)", "4G LTE: Dual SIM, kết nối Cloud liên tục", "GPS: Độ chính xác ±3m, cập nhật 1 giây/lần", "Thẻ nhớ: 64GB MicroSD tích hợp sẵn", "Cảnh báo: Tốc độ, mệt mỏi, địa lý điện tử", "Pin dự phòng: 400mAh ghi thêm 5 phút sau mất điện" },
                    new[] { "Màn hình cảm ứng 3.5 inch — tài xế tự kiểm tra camera, xem video, kiểm tra kết nối mà không cần điện thoại", "Giao diện tiếng Việt hoàn toàn — dễ dùng cho tài xế lớn tuổi, không cần hướng dẫn nhiều", "Pin dự phòng ghi thêm 5 phút sau mất điện — đảm bảo ghi lại đoạn cuối nếu xe bị đột ngột tắt máy", "Bảo hành thiết bị 24 tháng + bảo trì SIM/Cloud miễn phí 12 tháng đầu" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Dahua ND10S AI Cloud Plus",
                Price       = 5800000,
                Category    = "Camera Nghị Định 10",
                Description = "Dahua ND10S — AI giám sát tài xế cấp doanh nghiệp, Cloud 90 ngày, phân tích hành trình thông minh cho đội xe lớn.",
                Img  = "/images/product-4.jpg",
                Img2 = "/images/product-2.jpg",
                Img3 = "/images/product-1.jpg",
                Img4 = "/images/product-3.jpg",
                Spec = "Chuẩn: Nghị Định 10/2020 | AI DMS | 4G Dual SIM | Cloud 90 ngày | 2K QHD | Phân tích hành trình | Fleet Management",
                ContentHtml = Html(
                    "Dahua ND10S AI Cloud Plus — Chuẩn doanh nghiệp, AI đỉnh cao",
                    "Dahua là thương hiệu camera an ninh lớn thứ 2 thế giới (sau Hikvision). ND10S là giải pháp quản lý đội xe AI cao cấp nhất của họ, phù hợp cho doanh nghiệp vận tải quy mô 50-1000 xe với nhu cầu phân tích dữ liệu nâng cao.",
                    new[] { "Chuẩn: Nghị Định 10/2020 (Bộ GTVT)", "Độ phân giải: 2K QHD trước + 1080P cabin", "AI DMS: Buồn ngủ, điện thoại, hút thuốc, thắt dây an toàn", "SIM: Dual 4G LTE (2 nhà mạng song song)", "Cloud: Lưu trữ 90 ngày, phân tích AI tự động", "GPS: Tri-band (GPS + Glonass + BeiDou)", "Fleet Management: Dashboard, KPI, báo cáo Excel tự động", "API: Tích hợp được với ERP, phần mềm quản lý xe" },
                    new[] { "2K QHD — video rõ nét gấp 2 lần 1080P, nhận diện biển số và khuôn mặt trong mọi điều kiện ánh sáng", "AI phân tích hành trình 24/7, tự động tạo báo cáo KPI tài xế gửi email quản lý mỗi tuần", "Cloud 90 ngày — tra cứu và tải video sự cố bất kỳ thời điểm nào trong 3 tháng gần nhất", "API mở tích hợp với phần mềm ERP, phần mềm điều hành xe của doanh nghiệp", "Hỗ trợ doanh nghiệp lớn với SLA 99.9% uptime và đội kỹ thuật riêng 24/7" }
                ),
                IsActive = true
            }
        );

        // [C] Màn Hình Android (6 sản phẩm)
        context.Products.AddRange(
            new Product
            {
                ProductName = "GOTECH GT10 Pro 10 inch",
                Price       = 8500000,
                Category    = "Màn Hình Android",
                Description = "GOTECH GT10 Pro màn hình Android 10 inch, Android 13 mượt mà, RAM 4GB ROM 64GB. CarPlay không dây, GPS offline, DSP 32 kênh.",
                Img  = "/images/product-1.jpg",
                Img2 = "/images/product-3.jpg",
                Img3 = "/images/hero-car-screen.jpg",
                Img4 = "/images/product-2.jpg",
                Spec = "RAM: 4GB | ROM: 64GB | Màn hình: 10 inch IPS | Android 13 | CarPlay | GPS offline | DSP 32-band | Bluetooth 5.0",
                ContentHtml = Html(
                    "GOTECH GT10 Pro — Màn hình Android 10 inch flagship Việt Nam",
                    "GOTECH GT10 Pro là sản phẩm flagship của thương hiệu màn hình ô tô Việt Nam GOTECH. Với 10 năm phát triển, GOTECH hiểu người dùng Việt cần gì và GT10 Pro chính là câu trả lời: màn hình lớn 10 inch, Android 13 nhanh nhạy, CarPlay không dây và GPS offline không cần data.",
                    new[] { "RAM: 4GB LPDDR4X", "ROM: 64GB eMMC 5.1 (mở rộng USB)", "Màn hình: 10 inch IPS 1280×720", "Hệ điều hành: Android 13", "CarPlay: Không dây (Wireless CarPlay)", "Android Auto: Không dây", "GPS: Offline Vietmap S1 không cần 4G", "DSP: 32 kênh, bộ xử lý âm thanh rời", "Bluetooth: 5.0 đa điểm kết nối 2 thiết bị", "Wifi: 2.4GHz + 5GHz dual band" },
                    new[] { "CarPlay và Android Auto không dây — cắm điện là dùng, không cần cáp USB luộm thuộm", "GPS Vietmap S1 offline cực kỳ chính xác, bản đồ Việt Nam cập nhật liên tục, không cần data", "DSP 32 kênh rời biệt — âm thanh chất lượng, tùy chỉnh EQ, crossover, time alignment cho dàn âm thanh xịn", "Android 13 mượt mà, cài được đầy đủ app Google Play Store", "Thương hiệu Việt Nam — bảo hành, sửa chữa, hỗ trợ dễ dàng trên toàn quốc", "Tương thích rộng với đa số xe phổ thông Nhật, Hàn" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "GOTECH GT9 Max 9 inch",
                Price       = 7200000,
                Category    = "Màn Hình Android",
                Description = "GOTECH GT9 Max 9 inch Android 13 với thiết kế siêu mỏng 7mm. RAM 4GB, SIM 4G, GPS Navigation offline, Camera lùi 1080P.",
                Img  = "/images/product-1.jpg",
                Img2 = "/images/product-2.jpg",
                Img3 = "/images/product-4.jpg",
                Spec = "RAM: 4GB | ROM: 32GB | Màn hình: 9 inch IPS | Android 13 | SIM 4G | GPS | Camera lùi 1080P | Bluetooth 5.0",
                ContentHtml = Html(
                    "GOTECH GT9 Max — Siêu mỏng 7mm, đầy đủ tính năng 4G",
                    "GOTECH GT9 Max là sự kết hợp hoàn hảo giữa thiết kế tinh tế và tính năng đầy đủ. Với độ mỏng chỉ 7mm (mỏng nhất phân khúc), nó lắp vào xe trông như màn hình theo xe gốc. SIM 4G tích hợp cho phép dùng Zalo, YouTube, Google Maps trực tiếp trên xe.",
                    new[] { "RAM: 4GB LPDDR4", "ROM: 32GB (mở rộng thẻ nhớ 128GB)", "Màn hình: 9 inch IPS Full Lamination", "Độ mỏng: 7mm (siêu mỏng nhất phân khúc)", "Android: 13", "SIM 4G: Nano SIM tích hợp khe cắm", "Camera lùi: 1080P FHD tích hợp kết nối trực tiếp", "GPS: Offline + Online dual", "CarPlay: Có dây + Không dây tùy chọn", "DSP: 8 kênh âm thanh xe" },
                    new[] { "Siêu mỏng 7mm — lắp vào xe trông như màn hình zin theo xe, thẩm mỹ vượt trội", "SIM 4G nano tích hợp — dùng data riêng, không tốn data điện thoại, luôn online", "Camera lùi 1080P FHD kết nối trực tiếp — hình ảnh sắc nét khi lùi xe, màu sắc chính xác", "Full Lamination màn hình — không có khe hở giữa kính và LCD, không bị lóa, nhìn đẹp hơn 50%", "ROM 32GB + mở rộng microSD 128GB — lưu nhạc, bản đồ offline thoải mái" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "GOTECH GT12 Ultra 12 inch",
                Price       = 12500000,
                Category    = "Màn Hình Android",
                Description = "GOTECH GT12 Ultra flagship 12 inch, RAM 6GB ROM 128GB Android 13. Màn hình IPS 2K sắc nét, CarPlay không dây, Camera 360°.",
                Img  = "/images/product-1.jpg",
                Img2 = "/images/hero-car-screen.jpg",
                Img3 = "/images/product-3.jpg",
                Img4 = "/images/product-4.jpg",
                Img5 = "/images/product-2.jpg",
                Spec = "RAM: 6GB | ROM: 128GB | Màn hình: 12 inch IPS 2K | Android 13 | CarPlay | Camera 360 | DSP 32-band | WiFi 6",
                ContentHtml = Html(
                    "GOTECH GT12 Ultra — Flagship 12 inch 2K, đỉnh cao màn hình aftermarket",
                    "GOTECH GT12 Ultra là đỉnh cao của màn hình Android aftermarket tại Việt Nam. Màn hình 12 inch IPS 2K rộng lớn, RAM 6GB xử lý mượt mà đa nhiệm, ROM 128GB chứa đầy đủ media. Hỗ trợ Camera 360° toàn cảnh — tính năng trước đây chỉ có trên xe sang.",
                    new[] { "RAM: 6GB LPDDR4X", "ROM: 128GB UFS 2.1", "Màn hình: 12 inch IPS 2K (2000×1200)", "Android: 13 (cập nhật OTA)", "CarPlay: Không dây thế hệ 2 (kết nối 1 giây)", "Camera 360°: Hỗ trợ 4 camera Birds Eye View", "DSP: 32 kênh âm thanh chuyên nghiệp", "WiFi: 6E (2.4 + 5 + 6GHz)", "Bluetooth: 5.2", "SIM: Dual 4G LTE + eSIM" },
                    new[] { "12 inch IPS 2K — trải nghiệm nội dung như màn hình xe sang, cực sắc nét dưới ánh nắng trực tiếp", "Camera 360° Birds Eye View — nhìn toàn cảnh quanh xe khi đỗ và lùi, tính năng xe sang nay có trên xe bình dân", "RAM 6GB + ROM 128GB — đa nhiệm mượt mà, cài nhiều app, lưu toàn bộ nhạc không cần streaming", "WiFi 6E tốc độ cực cao — kết nối hotspot điện thoại siêu nhanh, xem 4K YouTube mượt", "CarPlay thế hệ 2 — kết nối chỉ 1 giây, không lag, trải nghiệm như iPhone gắn trên taplo" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Kovar K9 Pro 9 inch",
                Price       = 6800000,
                Category    = "Màn Hình Android",
                Description = "Kovar K9 Pro — Màn hình 9 inch QLED Android 13, màu sắc rực rỡ hơn IPS 30%, CarPlay không dây, DSP 16 kênh.",
                Img  = "/images/product-1.jpg",
                Img2 = "/images/product-2.jpg",
                Img3 = "/images/product-4.jpg",
                Spec = "RAM: 4GB | ROM: 64GB | Màn hình: 9 inch QLED | Android 13 | CarPlay không dây | DSP 16 kênh | Bluetooth 5.0 | GPS offline",
                ContentHtml = Html(
                    "Kovar K9 Pro — Màn hình QLED sống động, âm thanh DSP premium",
                    "Kovar K9 Pro mang đến điểm khác biệt lớn so với IPS thông thường: màn hình QLED (Quantum LED) cho màu sắc rực rỡ hơn 30%, độ tương phản cao hơn, xem video và ảnh sắc nét đến từng chi tiết. Kết hợp với DSP 16 kênh cho âm thanh xe hơi chuẩn audiophile.",
                    new[] { "RAM: 4GB LPDDR4X", "ROM: 64GB eMMC", "Màn hình: 9 inch QLED 1280×720", "Độ tương phản: 5000:1 (gấp 2.5 lần IPS)", "Android: 13 tùy biến", "CarPlay: Không dây + Apple FindMy", "DSP: 16 kênh 32-bit xử lý âm thanh", "GPS: Offline Vietmap + Google Maps online", "Bluetooth: 5.0 aptX HD", "Cổng: USB-A x2, USB-C x1, AUX 3.5mm" },
                    new[] { "QLED màn hình — màu sắc rực rỡ hơn 30% so với IPS, trải nghiệm xem video và ảnh như TV QLED Samsung", "DSP 16 kênh 32-bit — điều chỉnh âm thanh chi tiết: EQ, crossover, time alignment, subwoofer", "Apple FindMy tích hợp — xe bị mất cắp, tìm lại trên iPhone như tìm AirTag", "USB-C hỗ trợ sạc nhanh và truyền dữ liệu — kết nối thiết bị hiện đại không cần adapter", "aptX HD Bluetooth — âm thanh không dây chất lượng HD, nghe nhạc từ điện thoại không lag, không mất chất" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Wincar X10 10 inch Octa-Core",
                Price       = 9800000,
                Category    = "Màn Hình Android",
                Description = "Wincar X10 — Vi xử lý Octa-Core 8 nhân 2.0GHz, RAM 8GB, Android 13, màn hình 10 inch 2.5D kính cong. Nhanh nhất phân khúc.",
                Img  = "/images/product-1.jpg",
                Img2 = "/images/product-3.jpg",
                Img3 = "/images/hero-car-screen.jpg",
                Img4 = "/images/product-2.jpg",
                Spec = "Vi xử lý: Octa-Core 2.0GHz | RAM: 8GB | ROM: 128GB | Màn hình: 10 inch 2.5D | Android 13 | 4G | CarPlay | WiFi 6",
                ContentHtml = Html(
                    "Wincar X10 — Mạnh nhất phân khúc, Octa-Core 8GB RAM",
                    "Wincar X10 dành cho những ai không chấp nhận compromise về hiệu suất. Vi xử lý Octa-Core 8 nhân 2.0GHz kết hợp RAM 8GB LPDDR5 — cấu hình này mạnh hơn nhiều smartphone tầm trung. Chạy đồng thời 10 app, phát 4K, dẫn đường GPS mà không giật lag.",
                    new[] { "Vi xử lý: Octa-Core 8 nhân 2.0GHz", "RAM: 8GB LPDDR5 (cao nhất phân khúc)", "ROM: 128GB UFS 3.1 (tốc độ đọc 2100MB/s)", "Màn hình: 10 inch IPS 2.5D kính cong 1920×1080", "Android: 13 thuần (không bloatware)", "4G: Nano SIM tích hợp", "CarPlay: Không dây + Android Auto không dây", "WiFi: 6 (802.11ax) 2.4+5GHz", "Bluetooth: 5.2 aptX Adaptive", "Làm mát: Buồng hơi copper (tản nhiệt tốt hơn)" },
                    new[] { "Octa-Core 2.0GHz + 8GB RAM — nhanh nhất phân khúc aftermarket, không bao giờ lag dù chạy nhiều app", "Màn hình 2.5D kính cong — cạnh màn hình cong tự nhiên, tay cầm mượt, thẩm mỹ cao cấp", "UFS 3.1 tốc độ cao — app mở trong 0.5 giây, bản đồ load ngay lập tức", "Buồng hơi copper tản nhiệt — không bao giờ bị throttle hiệu suất do nhiệt, hiệu năng ổn định suốt hành trình", "Android thuần không bloatware — khởi động nhanh, ít rác, pin (khi dùng với pin ngoài) lâu hơn" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "OLED Touch 10 inch Android 13",
                Price       = 14900000,
                Category    = "Màn Hình Android",
                Description = "Màn hình OLED ô tô đầu tiên tại Việt Nam — đen tuyệt đối, màu sắc như iPhone Pro. RAM 8GB, Android 13, CarPlay không dây.",
                Img  = "/images/product-1.jpg",
                Img2 = "/images/hero-car-screen.jpg",
                Img3 = "/images/product-3.jpg",
                Img4 = "/images/product-4.jpg",
                Img5 = "/images/product-2.jpg",
                Spec = "Màn hình: 10 inch OLED 2K | RAM: 8GB | ROM: 256GB | Android 13 | CarPlay | Camera 360 | WiFi 6E | DSP 32-band | Bluetooth 5.2",
                ContentHtml = Html(
                    "OLED Touch 10 inch — Lần đầu tiên màn hình OLED xuất hiện trên xe hơi aftermarket",
                    "Đây là sản phẩm đột phá đầu tiên tại thị trường Việt Nam — màn hình OLED cho xe hơi aftermarket. OLED cho phép từng pixel tự phát sáng, đen hoàn toàn khi tắt, màu sắc chuẩn P3 như iPhone 15 Pro Max. Trải nghiệm xem phim, ảnh, bản đồ trên xe sẽ không bao giờ như cũ.",
                    new[] { "Màn hình: 10 inch OLED 2K (2560×1600)", "Tỷ lệ tương phản: Vô hạn (∞:1)", "Không gian màu: DCI-P3 100%", "RAM: 8GB LPDDR5", "ROM: 256GB UFS 3.1", "Android: 13 + Lớp giao diện tùy chỉnh", "CarPlay: Không dây thế hệ 3", "Camera 360°: 4 camera 1080P Birds Eye", "WiFi: 6E tri-band", "DSP: 32 kênh + Dolby Atmos Vehicle" },
                    new[] { "Màn hình OLED — đen tuyệt đối, mỗi pixel tự tắt → tiết kiệm điện + độ tương phản vô hạn, không sản phẩm IPS nào sánh được", "DCI-P3 100% — không gian màu chuyên nghiệp, ảnh và video hiển thị chính xác màu sắc như ý định của nhà sản xuất nội dung", "Dolby Atmos Vehicle — âm thanh không gian 3D trong cabin xe, như rạp phim di động", "Camera 360° Birds Eye 4 camera 1080P — hình ảnh bao quanh xe sắc nét, màu sắc chuẩn dù dùng ban đêm", "Chế độ không phát xạ xanh (Low Blue Light) — lái xe đêm không mỏi mắt, an toàn hơn" }
                ),
                IsActive = true
            }
        );

        // [D] Màn Hình Android Ô Tô (6 sản phẩm)
        context.Products.AddRange(
            new Product
            {
                ProductName = "Xenon X9 Toyota 9 inch",
                Price       = 9500000,
                Category    = "Màn Hình Android Ô Tô",
                Description = "Màn hình Xenon X9 tích hợp chuyên biệt cho xe Toyota (Camry, Vios, Fortuner, Innova). Khớp hoàn hảo taplo gốc, giữ nút vật lý.",
                Img  = "/images/product-3.jpg",
                Img2 = "/images/product-1.jpg",
                Img3 = "/images/hero-car-screen.jpg",
                Img4 = "/images/product-2.jpg",
                Spec = "Phù hợp: Toyota | Màn hình: 9 inch IPS | Android 13 | RAM: 4GB | CarPlay không dây | DSP | GPS | Giữ nút gốc",
                ContentHtml = Html(
                    "Xenon X9 Toyota — Tích hợp hoàn hảo, giữ nguyên nút xe gốc",
                    "Xenon X9 Toyota được thiết kế và kiểm tra chuyên biệt cho từng model xe Toyota tại Việt Nam: Camry 2019-2024, Vios 2019-2024, Fortuner 2020-2024, Innova 2016-2024. Khớp hoàn hảo với taplo gốc, không cần frame phụ, giữ nguyên toàn bộ nút điều khiển gốc của xe.",
                    new[] { "Phù hợp: Toyota Camry, Vios, Fortuner, Innova (2016-2024)", "Màn hình: 9 inch IPS 1280×720 Full Lamination", "RAM: 4GB | ROM: 64GB", "Android: 13 tùy chỉnh theo Toyota", "CarPlay: Không dây", "Điều hòa: Giữ nguyên màn hình điều hòa xe gốc", "Nút vật lý: Giữ hoàn toàn (volume, mode, phone)", "Canbus: Kết nối thông tin xe (nhiệt độ, tốc độ, vòng tua)", "DSP: 32 kênh tối ưu cho hệ thống âm thanh JBL Toyota" },
                    new[] { "Thiết kế khớp 100% với taplo xe Toyota — nhìn như màn hình factory tích hợp sẵn, không biết là đồ thay thế", "Giữ nguyên nút điều hòa và nút vật lý — không mất tính năng gốc, vợ/chồng không biết mình đã thay", "Canbus Toyota — màn hình nhận thông tin từ ECU: nhiên liệu, tốc độ, RPM, cảnh báo động cơ", "DSP tối ưu cho Toyota JBL — thay màn hình xong âm thanh còn hay hơn trước, không cần chỉnh lại", "Bảo hành 24 tháng, có kỹ thuật đến tận nhà lắp đặt và chỉnh âm thanh tại TP.HCM" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Xenon X10 Honda 10 inch",
                Price       = 10200000,
                Category    = "Màn Hình Android Ô Tô",
                Description = "Màn hình Xenon X10 tích hợp chuyên biệt cho Honda (CR-V, City, Civic, HR-V). 4G, GPS Cloud, điều khiển giọng nói tiếng Việt.",
                Img  = "/images/product-3.jpg",
                Img2 = "/images/product-4.jpg",
                Img3 = "/images/product-2.jpg",
                Spec = "Phù hợp: Honda | Màn hình: 10 inch IPS | Android 13 | RAM: 4GB | 4G + GPS | CarPlay | Giọng nói tiếng Việt",
                ContentHtml = Html(
                    "Xenon X10 Honda — Giọng nói tiếng Việt, thiết kế zin theo xe",
                    "Xenon X10 Honda được phát triển riêng cho dòng xe Honda phổ biến tại Việt Nam: CR-V 2017-2024, City 2020-2024, Civic 2021-2024, HR-V 2021-2024. Tính năng nổi bật nhất là điều khiển giọng nói tiếng Việt hoàn toàn — gọi điện, nhắn tin, tìm đường chỉ bằng lệnh thoại.",
                    new[] { "Phù hợp: Honda CR-V, City, Civic, HR-V, Accord (2017-2024)", "Màn hình: 10 inch IPS 1280×800 Full Lamination", "RAM: 4GB | ROM: 64GB", "Android: 13 + Honda Interface Skin", "Giọng nói: Tiếng Việt hoàn toàn (Hey Xenon)", "4G: Nano SIM tích hợp", "GPS Cloud: Online + Offline Vietmap", "CarPlay: Không dây", "Canbus Honda: Kết nối ECU đầy đủ", "DSP: 32 kênh tối ưu Honda Premium Audio" },
                    new[] { "\"Hey Xenon\" điều khiển giọng nói tiếng Việt chuẩn — không cần tay, gọi điện, nhắn tin, chỉ đường bằng tiếng Việt bình thường", "Honda Interface Skin — giao diện tùy chỉnh theo màu sắc Honda, cảm giác như màn hình OEM", "4G tích hợp + GPS Cloud — luôn có traffic realtime, không bao giờ bị kẹt xe mà không hay biết", "Canbus Honda đầy đủ — thông tin xe hiển thị chính xác: fuel, odometer, camera lùi gốc tương thích", "Bảo hành 24 tháng, cập nhật phần mềm OTA không cần mang xe đến" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Xenon X12 Mazda 12 inch",
                Price       = 11800000,
                Category    = "Màn Hình Android Ô Tô",
                Description = "Màn hình Xenon X12 chuyên biệt cho Mazda (CX-5, Mazda3, CX-8, CX-30). Màn hình 12 inch 2K, RAM 6GB, Dual System song song.",
                Img  = "/images/product-3.jpg",
                Img2 = "/images/hero-car-screen.jpg",
                Img3 = "/images/product-1.jpg",
                Img4 = "/images/product-4.jpg",
                Spec = "Phù hợp: Mazda | Màn hình: 12 inch IPS 2K | Android 13 | RAM: 6GB | Dual System | CarPlay | GPS | DSP cao cấp",
                ContentHtml = Html(
                    "Xenon X12 Mazda — 12 inch 2K, Dual System, cao cấp nhất phân khúc",
                    "Xenon X12 Mazda là sản phẩm cao cấp nhất của dòng màn hình tích hợp theo xe. Được phát triển cho xe Mazda với thiết kế sang trọng (Mazda Connect), X12 duy trì hoàn toàn giao diện Mazda Connect gốc và thêm hệ Android 13 song song — đây là Dual System chính hãng đầu tiên ở Việt Nam.",
                    new[] { "Phù hợp: Mazda CX-5 (2017+), Mazda3 (2019+), CX-8, CX-30, CX-3", "Màn hình: 12 inch IPS 2K (2000×1200)", "RAM: 6GB | ROM: 128GB", "Android: 13 + Mazda Connect gốc (Dual System)", "CarPlay: Không dây + Android Auto không dây", "Canbus: Mazda Gen2 đầy đủ", "DSP: Bose Optimization (nếu xe có Bose)", "Camera lùi: Tương thích camera gốc Mazda", "WiFi 6: 2.4 + 5GHz", "GPS: Vietmap 3D offline" },
                    new[] { "Dual System — chạy song song Mazda Connect gốc + Android 13: bạn chọn dùng hệ nào thì dùng, không bao giờ mất tính năng xe gốc", "12 inch 2K màn hình — to và sắc nhất trong mọi xe phân khúc C-SUV (CX-5, CX-30) — lắp xong như xe sang hạng E", "Bose Optimization DSP — nếu xe có loa Bose, thay màn hình này âm thanh Bose hoạt động đúng 100% không giảm chất", "Camera lùi gốc Mazda tương thích — giữ nguyên camera 360° gốc nếu xe đã có, hiển thị chuẩn chỉnh", "Cập nhật Mazda Connect qua OTA — bản đồ Mazda và firmware theo xe vẫn được cập nhật bình thường" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Joying 9 inch Hyundai/Kia",
                Price       = 8900000,
                Category    = "Màn Hình Android Ô Tô",
                Description = "Joying 9 inch tích hợp cho Hyundai (Tucson, Santa Fe, Accent) và Kia (Seltos, Sorento, K5). Android 13, RAM 4GB, CarPlay.",
                Img  = "/images/product-3.jpg",
                Img2 = "/images/product-2.jpg",
                Img3 = "/images/product-4.jpg",
                Spec = "Phù hợp: Hyundai + Kia | Màn hình: 9 inch IPS 2.5D | Android 13 | RAM: 4GB | CarPlay không dây | DSP | Canbus",
                ContentHtml = Html(
                    "Joying 9 inch Hyundai/Kia — Một sản phẩm cho hai thương hiệu",
                    "Joying 9 inch là giải pháp thông minh cho chủ xe Hyundai hoặc Kia — cùng một bo mạch chủ nhưng được cấu hình firmware riêng cho từng model xe, đảm bảo Canbus tương thích 100%. Một trong số ít sản phẩm hỗ trợ tốt cả hai thương hiệu cùng tập đoàn Hyundai Motor.",
                    new[] { "Phù hợp: Hyundai (Tucson, Santa Fe, Accent, i10, Kona) + Kia (Seltos, Sorento, K5, Morning, Sportage) 2019-2024", "Màn hình: 9 inch IPS 2.5D (1280×720)", "RAM: 4GB | ROM: 64GB", "Android: 13 + HMG Skin tùy chọn", "CarPlay: Không dây + Android Auto", "Canbus: Hyundai/Kia Gen3 đầy đủ", "DSP: 8 kênh tối ưu Harman Kardon (HK models)", "Camera lùi: HD 720P tích hợp" },
                    new[] { "Hỗ trợ cả Hyundai và Kia (cùng tập đoàn HMG) — giá trị tốt hơn vì firmware được duy trì cho cả hai nhãn hiệu lớn", "Canbus Gen3 — đọc thông tin ECU: tốc độ, nhiên liệu, cảnh báo TPMS, cửa, ghế", "Harman Kardon DSP Optimization — xe HK trang bị sẵn loa HK, thay màn hình này âm thanh HK vẫn hoàn hảo", "Android 13 thuần + HMG Skin tùy chọn — muốn dùng giao diện Hyundai/Kia hay Android thuần đều được", "Joying thương hiệu Trung Quốc xuất khẩu Mỹ/Châu Âu uy tín 8 năm — hàng chất lượng xuất khẩu" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Eonon GA13 Nissan 10 inch",
                Price       = 9200000,
                Category    = "Màn Hình Android Ô Tô",
                Description = "Eonon GA13 chuyên dụng cho xe Nissan (X-Trail, Navara, Terra, Sunny). Android 13, RAM 4GB, màn hình 10 inch, CarPlay không dây.",
                Img  = "/images/product-3.jpg",
                Img2 = "/images/product-1.jpg",
                Img3 = "/images/hero-car-screen.jpg",
                Spec = "Phù hợp: Nissan | Màn hình: 10 inch IPS | Android 13 | RAM: 4GB | ROM: 64GB | CarPlay | Canbus Nissan | GPS offline",
                ContentHtml = Html(
                    "Eonon GA13 Nissan — Giải pháp chuyên biệt cho xe Nissan Việt Nam",
                    "Xe Nissan lâu nay thiếu vắng các giải pháp màn hình tích hợp chuyên biệt. Eonon GA13 lấp đầy khoảng trống đó với thiết kế khớp hoàn hảo cho X-Trail, Navara, Terra và Sunny — những dòng xe Nissan bán chạy nhất tại Việt Nam.",
                    new[] { "Phù hợp: Nissan X-Trail (2014-2022), Navara (2015-2024), Terra (2018-2024), Sunny (2011-2020)", "Màn hình: 10 inch IPS 1280×720 Full Lamination", "RAM: 4GB | ROM: 64GB", "Android: 13", "CarPlay: Không dây", "Android Auto: Không dây", "Canbus: Nissan CAN đầy đủ", "DSP: 16 kênh", "GPS: Vietmap offline", "Camera lùi: HD 720P tích hợp, tương thích camera gốc" },
                    new[] { "Thiết kế khớp hoàn hảo xe Nissan — lắp xong như xe xuất xưởng, không có khoảng hở hay frame nhựa xấu", "Canbus Nissan đầy đủ — thông tin xe hiển thị chính xác, locking door, gear position, TPMS", "Hỗ trợ camera sau gốc Nissan — nếu xe đã có camera gốc, giữ nguyên và hiển thị trên màn hình mới", "10 inch Full Lamination — màn hình không khe hở, nhìn sắc nét hơn, không đọng nước, không bụi vào trong", "Eonon thương hiệu US-based, quality control nghiêm ngặt, bảo hành 2 năm toàn cầu" }
                ),
                IsActive = true
            },
            new Product
            {
                ProductName = "Pioneer AVIC-Z930DAB 10 inch",
                Price       = 15000000,
                Category    = "Màn Hình Android Ô Tô",
                Description = "Pioneer AVIC-Z930DAB — Flagship Pioneer với màn hình WVGA 10 inch, DAB+, CarPlay không dây, Android Auto, 50Wx4 amplifier.",
                Img  = "/images/product-3.jpg",
                Img2 = "/images/product-2.jpg",
                Img3 = "/images/product-4.jpg",
                Img4 = "/images/hero-car-screen.jpg",
                Img5 = "/images/product-1.jpg",
                Spec = "Màn hình: 10 inch WVGA | DAB+ | CarPlay không dây | Android Auto | Amplifier 50Wx4 | DSP 13-band | Bluetooth 5.0 | GPS tích hợp",
                ContentHtml = Html(
                    "Pioneer AVIC-Z930DAB — Flagship Pioneer, âm thanh và điều hướng đỉnh cao",
                    "Pioneer là thương hiệu head unit xe hơi nổi tiếng nhất thế giới với lịch sử hơn 80 năm. AVIC-Z930DAB là sản phẩm flagship của họ, kết hợp hoàn hảo giữa hệ thống giải trí và điều hướng cao cấp với amplifier tích hợp 50W×4 và bộ xử lý DSP chuyên nghiệp.",
                    new[] { "Màn hình: 10 inch WVGA 800×480 (IPS chuẩn Pioneer)", "DAB+: Radio kỹ thuật số chất lượng cao (FM/AM/DAB+)", "Amplifier: 50W×4 Pioneer Class-D tích hợp", "DSP: 13-band EQ + Time Alignment + Crossover", "CarPlay: Không dây (WiFi 5GHz)", "Android Auto: Không dây (WiFi 5GHz)", "GPS: HERE Maps + AVIC Cloud", "Bluetooth: 5.0 đa điểm 3 thiết bị", "HDMI: Input cho camera/ngoại vi", "SiriusXM: Ready (cần tuner riêng)" },
                    new[] { "Pioneer AVIC flagship — thương hiệu 80 năm, lựa chọn của audiophile và người lái xe chuyên nghiệp trên toàn thế giới", "Amplifier 50W×4 tích hợp — không cần mua ampli rời, chất lượng vượt trội mọi OEM head unit", "DSP 13-band chuyên nghiệp — Pioneer là thương hiệu phát minh ra DSP car audio, chất âm không đối thủ", "DAB+ radio kỹ thuật số — âm thanh radio không nhiễu, chất lượng CD, tính năng chỉ có xe châu Âu cao cấp", "HERE Maps — hệ thống bản đồ của Nokia, chuẩn nhất thế giới, offline hoàn toàn không cần internet" },
                    "<li>01 Pioneer AVIC-Z930DAB</li><li>01 Harness kết nối xe (chọn theo model xe)</li><li>01 GPS antenna đa tần</li><li>01 Microphone BT tích hợp</li><li>01 Remote control</li><li>01 Hướng dẫn sử dụng (English, tiếng Việt download)</li>"
                ),
                IsActive = true
            }
        );

        // ── 4. News ────────────────────────────────────────────────────────────
        context.News.AddRange(
            new News { Title = "Xu hướng Màn Hình Android Ô Tô 2025: AI và không dây lên ngôi", Summary = "Năm 2025, màn hình Android ô tô bùng nổ với AI nhận diện giọng nói tiếng Việt, CarPlay/Android Auto không dây và màn hình 2K cong.", Content = "Năm 2025 đánh dấu bước ngoặt lớn cho thị trường màn hình Android ô tô tại Việt Nam...", Img = "/images/hero-car-screen.jpg", IsActive = true, CreatedAt = new DateTime(2025, 1, 10) },
            new News { Title = "Top 3 Camera Hành Trình Tốt Nhất 2025 — Đánh giá thực tế", Summary = "70mai A800S, Vietmap C61 Pro hay Hikvision C6S? Chúng tôi đã test cả 3 trên cùng một hành trình Hà Nội — Hải Phòng.", Content = "Chúng tôi đã lắp cả 3 camera lên cùng một chiếc Toyota Camry và chạy 105km...", Img = "/images/product-2.jpg", IsActive = true, CreatedAt = new DateTime(2025, 2, 14) },
            new News { Title = "Camera Nghị Định 10: Xe nào bắt buộc lắp và lắp loại nào?", Summary = "Nghị Định 10/2020 yêu cầu bắt buộc gắn camera có GPS cho xe kinh doanh vận tải.", Content = "Nghị Định 10/2020 của Chính phủ quy định xe ô tô kinh doanh vận tải bắt buộc phải lắp camera...", Img = "/images/product-4.jpg", IsActive = true, CreatedAt = new DateTime(2025, 3, 5) },
            new News { Title = "Màn Hình Android Tích Hợp vs Aftermarket: Nên chọn loại nào?", Summary = "Màn hình tích hợp theo xe hay aftermarket phổ thông? Phân tích chi tiết ưu nhược điểm.", Content = "Thị trường chia làm 2 dòng chính: màn hình tích hợp và aftermarket...", Img = "/images/product-3.jpg", IsActive = true, CreatedAt = new DateTime(2025, 4, 20) },
            new News { Title = "Hướng dẫn lắp Camera Hành Trình đúng cách — Tránh 5 lỗi phổ biến", Summary = "Lắp camera hành trình sai vị trí, sai góc quay khiến camera hoạt động kém hoặc hỏng sớm.", Content = "Lỗi 1 — Lắp sai vị trí: Camera phải nằm phía sau gương chiếu hậu...", Img = "/images/product-2.jpg", IsActive = true, CreatedAt = new DateTime(2025, 5, 8) }
        );

        // ── 5. Orders ──────────────────────────────────────────────────────────
        context.Orders.AddRange(
            new Order { ProductName = "GOTECH GT10 Pro 10 inch",   Price = "8,500,000",  Quantity = 1, TotalAmount = "8,500,000",  FullName = "Nguyễn Văn An",   Phone = "0901234567", Img = "/images/product-1.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 3, 10) },
            new Order { ProductName = "Vietmap ND10 Pro GPS Cloud", Price = "4,500,000",  Quantity = 1, TotalAmount = "4,500,000",  FullName = "Trần Thị Bình",   Phone = "0912345678", Img = "/images/product-4.jpg", Status = "Đang xử lý",     CreatedAt = new DateTime(2025, 4, 2)  },
            new Order { ProductName = "Camera 70mai A800S 4K",      Price = "2,990,000",  Quantity = 1, TotalAmount = "2,990,000",  FullName = "Lê Hoàng Dũng",   Phone = "0923456789", Img = "/images/product-2.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 4, 10) },
            new Order { ProductName = "Xenon X9 Toyota 9 inch",     Price = "9,500,000",  Quantity = 1, TotalAmount = "9,500,000",  FullName = "Phạm Minh Tuấn",  Phone = "0934567890", Img = "/images/product-3.jpg", Status = "Chờ xác nhận",   CreatedAt = new DateTime(2025, 4, 18) },
            new Order { ProductName = "GOTECH GT12 Ultra 12 inch",  Price = "12,500,000", Quantity = 1, TotalAmount = "12,500,000", FullName = "Hoàng Thị Mai",   Phone = "0945678901", Img = "/images/product-1.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 5, 1)  },
            new Order { ProductName = "Hikvision ND10S 4G AI",      Price = "5,200,000",  Quantity = 2, TotalAmount = "10,400,000", FullName = "Vũ Đức Khải",     Phone = "0956789012", Img = "/images/product-4.jpg", Status = "Đang giao hàng", CreatedAt = new DateTime(2025, 5, 20) },
            new Order { ProductName = "Xenon X10 Honda 10 inch",    Price = "10,200,000", Quantity = 1, TotalAmount = "10,200,000", FullName = "Đỗ Thanh Long",   Phone = "0967890123", Img = "/images/product-3.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 6, 1)  },
            new Order { ProductName = "Vietmap C61 Pro 2K",         Price = "1,890,000",  Quantity = 3, TotalAmount = "5,670,000",  FullName = "Bùi Thị Hương",   Phone = "0978901234", Img = "/images/product-2.jpg", Status = "Đã giao",         CreatedAt = new DateTime(2025, 6, 5)  }
        );

        context.SaveChanges();
        Console.WriteLine("✅ Seed data 24 sản phẩm + ContentHtml + gallery hoàn tất!");
    }
}
