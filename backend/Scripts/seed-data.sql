-- ============================================
-- 📁 seed-data.sql - Thêm dữ liệu mẫu vào Database
-- Chạy file này trực tiếp trên SQL Server
-- ============================================

USE [vin06887_vimap.vn];
GO

-- Xóa dữ liệu cũ (nếu có)
DELETE FROM [orders];
DELETE FROM [news];
DELETE FROM [product];
DELETE FROM [carScreen];
DELETE FROM [banner];
GO

-- ============================================
-- 1. BANNER
-- ============================================
SET IDENTITY_INSERT [banner] ON;

INSERT INTO [banner] ([id], [banner1], [banner2], [isActive]) VALUES
(1, '/images/banners/banner-car-tech-main.jpg', '/images/banners/banner-car-tech-sub.jpg', 1),
(2, '/images/banners/banner-promo-2024.jpg', '/images/banners/banner-new-arrivals.jpg', 1);

SET IDENTITY_INSERT [banner] OFF;

-- ============================================
-- 2. CARSCREEN
-- ============================================
SET IDENTITY_INSERT [carScreen] ON;

INSERT INTO [carScreen] ([id], [screenName], [location], [note], [typeId], [isActive]) VALUES
(1, N'Màn hình Android ô tô 10 inch', N'Taplo trung tâm', N'Hỗ trợ GPS, Bluetooth, Camera lùi', NULL, 1),
(2, N'Màn hình DVD Android 9 inch', N'Taplo trung tâm', N'Mỏng nhẹ, giao diện đơn giản', NULL, 1),
(3, N'Màn hình Camera 360 độ 11 inch', N'Taplo + Mirror', N'Góc nhìn toàn cảnh, quan sát 4 phía', NULL, 1),
(4, N'Màn hình rear seat entertainment 13 inch', N'Tựa đầu hàng ghế sau', N'Giải trí cho hành khách phía sau', NULL, 1),
(5, N'Đồng hồ màn hình kỹ thuật số TFT 7 inch', N'Bảng đồng hồ taplo', N'Hiển thị tốc độ, vòng tua, nhiệt độ', NULL, 1);

SET IDENTITY_INSERT [carScreen] OFF;

-- ============================================
-- 3. PRODUCT
-- ============================================
SET IDENTITY_INSERT [product] ON;

INSERT INTO [product] ([id], [productName], [price], [category], [description], [img], [spec], [isActive]) VALUES
(1, N'Màn hình Android G09 Pro - 10 inch', 3500000, N'Màn hình Android',
 N'Màn hình Android 10 inch cao cấp, RAM 4GB, ROM 64GB. Hỗ trợ SIM 4G, GPS Navigation, Camera lùi, Bluetooth 5.0. Giao diện mượt mà, tương thích với tất cả dòng xe.',
 '/images/products/g09-pro-10inch.jpg',
 N'RAM: 4GB | ROM: 64GB | Màn hình: 10 inch IPS | Hệ điều hành: Android 12 | Kết nối: WiFi, Bluetooth 5.0, SIM 4G', 1),

(2, N'Màn hình Android Teyes CC3L - 9 inch', 2800000, N'Màn hình Android',
 N'Màn hình Android Teyes CC3L 9 inch với thiết kế sang trọng, chất lượng âm thanh tuyệt vời. Hỗ trợ Apple CarPlay không dây và Android Auto.',
 '/images/products/teyes-cc3l-9inch.jpg',
 N'RAM: 2GB | ROM: 32GB | Màn hình: 9 inch IPS | Hệ điều hành: Android 11 | Kết nối: WiFi, Bluetooth 5.0', 1),

(3, N'Camera 360 Owin S1 Full HD', 4500000, N'Camera 360',
 N'Hệ thống camera 360 độ Owin S1 với 4 camera FULL HD 1080P, góc nhìn toàn cảnh xe. Hỗ trợ ghi hình ban đêm, hiển thị 3D, radar đỗ xe.',
 '/images/products/owin-s1-360.jpg',
 N'Độ phân giải: 1080P | Số camera: 4 | Góc nhìn: 360° | Chế độ: 2D/3D | Tính năng: Ghi đêm, radar', 1),

(4, N'Camera lùi xe hơi Full HD', 750000, N'Camera',
 N'Camera lùi Full HD 1080P chống nước IP68, góc rộng 170°, chip Sony STARVIS cho hình ảnh rõ nét cả ban đêm.',
 '/images/products/camera-lui-hd.jpg',
 N'Độ phân giải: 1080P | Góc rộng: 170° | Chống nước: IP68 | Chip: Sony STARVIS | LED hồng ngoại', 1),

(5, N'Bộ Camera hành trình Carcam D600', 1900000, N'Camera hành trình',
 N'Camera hành trình trước sau Carcam D600, quay video 4K trước và 1080P sau. Tính năng G-Sensor, đỗ xe có giám sát, GPS gắn dấu đường.',
 '/images/products/carcam-d600.jpg',
 N'Camera trước: 4K | Camera sau: 1080P | Góc nhìn: 170° (trước) + 140° (sau) | Tính năng: G-Sensor, GPS, Parking Monitor', 1),

(6, N'Màn hình rear seat 12.5 inch Android', 2200000, N'Màn hình rear seat',
 N'Màn hình giải trí dành cho hành khách phía sau, cài đặt Android, hỗ trợ xem phim, lướt web, chơi game. Lắp đặt dễ dàng trên tựa đầu.',
 '/images/products/rear-seat-125.jpg',
 N'Màn hình: 12.5 inch IPS Full HD | RAM: 3GB | ROM: 32GB | Hệ điều hành: Android 11 | Kết nối: WiFi, Bluetooth, USB', 1);

SET IDENTITY_INSERT [product] OFF;

-- ============================================
-- 4. NEWS
-- ============================================
SET IDENTITY_INSERT [news] ON;

INSERT INTO [news] ([id], [title], [summary], [content], [img], [isActive], [createdAt]) VALUES
(1, N'Xu hướng màn hình Android ô tô năm 2024',
 N'Các xu hướng công nghệ mới nhất trong lĩnh vực màn hình Android cho ô tô, từ tính năng AI đến giao diện hiện đại.',
 N'Năm 2024 chứng kiến sự phát triển mạnh mẽ của công nghệ màn hình Android cho ô tô. Các tính năng mới bao gồm: nhận diện giọng nói nâng cao với AI, tích hợp trợ lý ảo, hỗ trợ Apple CarPlay và Android Auto không dây, cũng như giao diện người dùng được tối ưu hóa cho tài xế. Đặc biệt, các dòng màn hình RAM 4GB trở lên đang trở thành xu hướng phổ biến, mang lại trải nghiệm mượt mà không khác gì smartphone cao cấp.',
 '/images/news/trend-2024.jpg', 1, '2024-03-01 10:00:00'),

(2, N'Camera 360 độ: Có nên trang bị cho xe hơi?',
 N'Phân tích ưu nhược điểm của hệ thống camera 360 độ và lý do tại sao đây là phụ kiện không thể thiếu.',
 N'Camera 360 độ cho xe hơi đã trở thành một trong những phụ kiện được quan tâm nhất hiện nay. Hệ thống gồm 4 camera đặt ở 4 vị trí trên xe, tạo ra hình ảnh toàn cảnh 360° giúp tài xế quan sát mọi góc blindspot. Ưu điểm bao gồm: hỗ trợ đỗ xe an toàn, giảm thiểu va chạm, quan sát cả ban đêm. Nhược điểm: chi phí lắp đặt khá cao (3-6 triệu), cần thợ có kinh nghiệm. Tuy nhiên, so với chi phí sửa chữa sau va chạm, đây vẫn là khoản đầu tư đáng giá.',
 '/images/news/camera360-review.jpg', 1, '2024-03-15 14:30:00'),

(3, N'Hướng dẫn chọn màn hình Android phù hợp với xe của bạn',
 N'Các tiêu chí quan trọng khi lựa chọn màn hình Android ô tô: kích thước, cấu hình, tính năng và giá thành.',
 N'Việc lựa chọn màn hình Android phù hợp cho xe hơi phụ thuộc vào nhiều yếu tố. Thứ nhất là kích thước: xe sedan thường dùng màn 9-10 inch, xe SUV có thể dùng 10-12 inch. Thứ hai là cấu hình: RAM 2GB đủ cho nhu cầu cơ bản, RAM 4GB phù hợp cho người dùng đa nhiệm. Thứ ba là tính năng: Apple CarPlay, Camera lùi, GPS là những tính năng cơ bản cần có. Cuối cùng là thương hiệu: các thương hiệu uy tín như Teyes, G09, Owin thường có chế độ bảo hành tốt.',
 '/images/news/huong-don-chon-man-hinh.jpg', 1, '2024-04-01 09:00:00'),

(4, N'Lắp Camera hành trình: Những điều cần biết',
 N'Kinh nghiệm chọn và lắp camera hành trình cho xe hơi, từ phân khúc giá rẻ đến cao cấp.',
 N'Camera hành trình đang trở thành phụ kiện cần thiết cho mọi tài xế. Sản phẩm không chỉ giúp ghi lại hành trình mà còn là bằng chứng quan trọng khi xảy ra sự cố giao thông. Khi chọn mua, cần lưu ý: độ phân giải (tối thiểu 1080P), góc quay (140° trở lên), tính năng ban đêm, dung lượng thẻ nhớ hỗ trợ. Phân khúc giá phổ thông từ 500K-2 triệu, phân khúc cao cấp từ 2-5 triệu với nhiều tính năng nâng cao như 4K, GPS, WiFi.',
 '/images/news/camera-hanh-trinh.jpg', 1, '2024-04-10 16:00:00');

SET IDENTITY_INSERT [news] OFF;

-- ============================================
-- 5. ORDERS
-- ============================================
SET IDENTITY_INSERT [orders] ON;

INSERT INTO [orders] ([id], [productName], [price], [quantity], [totalAmount], [fullName], [phone], [img], [status], [createdAt]) VALUES
(1, N'Màn hình Android G09 Pro - 10 inch', N'3,500,000', 1, N'3,500,000',
 N'Nguyễn Văn An', N'0901234567', '/images/products/g09-pro-10inch.jpg', N'Đã giao', '2024-03-15 10:30:00'),

(2, N'Camera 360 Owin S1 Full HD', N'4,500,000', 1, N'4,500,000',
 N'Trần Thị Bình', N'0912345678', '/images/products/owin-s1-360.jpg', N'Đang xử lý', '2024-04-02 14:15:00'),

(3, N'Camera lùi xe hơi Full HD', N'750,000', 2, N'1,500,000',
 N'Lê Hoàng Dũng', N'0923456789', '/images/products/camera-lui-hd.jpg', N'Đã giao', '2024-04-10 09:00:00'),

(4, N'Bộ Camera hành trình Carcam D600', N'1,900,000', 1, N'1,900,000',
 N'Phạm Minh Tuấn', N'0934567890', '/images/products/carcam-d600.jpg', N'Chờ xác nhận', '2024-04-18 16:45:00');

SET IDENTITY_INSERT [orders] OFF;

PRINT N'✅ Đã thêm dữ liệu mẫu thành công!';
GO