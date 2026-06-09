// ============================================
// 📁 services/product.service.ts - Product Data Service
// ============================================

import product1 from "@/assets/product-1.jpg"
import product2 from "@/assets/product-2.jpg"
import product3 from "@/assets/product-3.jpg"
import product4 from "@/assets/product-4.jpg"
import { Product, ProductDetail, Category, CategoryProduct } from "@/models/types"

/** Format giá tiền VND */
export const formatPrice = (price: number): string => {
  return new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",
  }).format(price)
}

/** Lấy danh sách sản phẩm */
export const getProducts = (): Product[] => [
  {
    id: 1,
    name: "GOTECH GT10 Pro",
    price: 8500000,
    image: product1,
    size: "10 inch",
    specs: "Android 13 | 4GB RAM | 64GB ROM",
    features: ["GPS", "Bluetooth", "WiFi", "CarPlay"],
  },
  {
    id: 2,
    name: "GOTECH GT9 Max",
    price: 7200000,
    image: product2,
    size: "9 inch",
    specs: "Android 13 | 4GB RAM | 32GB ROM",
    features: ["GPS", "Bluetooth", "WiFi"],
  },
  {
    id: 3,
    name: "GOTECH GT12 Ultra",
    price: 12500000,
    image: product3,
    size: "12 inch",
    specs: "Android 13 | 6GB RAM | 128GB ROM",
    features: ["GPS", "Bluetooth", "WiFi", "CarPlay", "Camera 360"],
  },
  {
    id: 4,
    name: "GOTECH GT7 Compact",
    price: 5500000,
    image: product4,
    size: "7 inch",
    specs: "Android 12 | 2GB RAM | 32GB ROM",
    features: ["GPS", "Bluetooth"],
  },
  {
    id: 5,
    name: "GOTECH GT10 Standard",
    price: 6800000,
    image: product1,
    size: "10 inch",
    specs: "Android 12 | 3GB RAM | 32GB ROM",
    features: ["GPS", "Bluetooth", "WiFi"],
  },
  {
    id: 6,
    name: "GOTECH GT9 Pro",
    price: 9200000,
    image: product2,
    size: "9 inch",
    specs: "Android 13 | 4GB RAM | 64GB ROM",
    features: ["GPS", "Bluetooth", "WiFi", "CarPlay"],
  },
]

/** Lấy chi tiết sản phẩm theo ID */
export const getProductDetail = (id: string | undefined): ProductDetail => ({
  id: Number(id),
  name: "GOTECH GT10 Pro",
  price: 8500000,
  status: "Còn hàng",
  rating: 4.8,
  reviews: 127,
  images: [product1, product2, product3],
  description: "Màn hình Android GOTECH GT10 Pro là giải pháp hoàn hảo để nâng cấp hệ thống giải trí trên xe của bạn với công nghệ hiện đại nhất.",
  size: "10 inch",
  specs: "Android 13 | 4GB RAM | 64GB ROM",
  features: [],
  detailedSpecs: {
    size: "10 inch IPS",
    os: "Android 13",
    ram: "4GB",
    rom: "64GB",
    connectivity: "Bluetooth 5.0, WiFi, USB, CarPlay không dây",
    warranty: "2 năm chính hãng",
  },
  productFeatures: [
    { title: "Màn hình IPS Full HD", description: "Độ phân giải cao, góc nhìn rộng, hiển thị sắc nét trong mọi điều kiện ánh sáng" },
    { title: "Android 13 mới nhất", description: "Hệ điều hành mượt mà, ổn định với khả năng tùy biến cao" },
    { title: "Kết nối đa dạng", description: "Hỗ trợ CarPlay không dây, Android Auto, Bluetooth, WiFi" },
    { title: "GPS tích hợp", description: "Định vị chính xác, dẫn đường thông minh với bản đồ offline" },
    { title: "Camera 360 độ", description: "Hỗ trợ camera lùi, camera 360 độ giúp quan sát toàn cảnh" },
    { title: "Âm thanh DSP", description: "Xử lý âm thanh DSP 32 kênh, mang đến trải nghiệm nghe nhạc đỉnh cao" },
  ],
})

/** Lấy sản phẩm liên quan */
export const getRelatedProducts = (): { id: number; name: string; price: number; image: string }[] => [
  { id: 2, name: "GOTECH GT9 Max", price: 7200000, image: product2 },
  { id: 3, name: "GOTECH GT12 Ultra", price: 12500000, image: product3 },
]

/** Lấy sản phẩm nổi bật trên trang chủ */
export const getFeaturedProducts = (): { id: number; name: string; price: string; image: string; specs: string }[] => [
  { id: 1, name: "GOTECH GT10 Pro", price: "8.500.000đ", image: product1, specs: "10 inch | Android 13 | 4GB RAM" },
  { id: 2, name: "GOTECH GT9 Max", price: "7.200.000đ", image: product2, specs: "9 inch | Android 13 | GPS" },
  { id: 3, name: "GOTECH GT12 Ultra", price: "12.500.000đ", image: product3, specs: "12 inch | Android 13 | 6GB RAM" },
]

/** Lấy danh mục sản phẩm */
export const getCategories = (): Category[] => [
  {
    id: 1,
    name: "Camera Hành Trình",
    description: "Ghi lại mọi hành trình, bảo vệ quyền lợi của bạn",
    specs: "Full HD 1080P | Góc rộng 170° | WDR | Loop Recording",
    icon: "🎥",
    products: [
      { id: 1, name: "Camera 70mai A800S", price: "2.990.000đ", specs: "4K | GPS | ADAS", image: product1 },
      { id: 2, name: "Vietmap C61 Pro", price: "1.890.000đ", specs: "2K | WDR | 170°", image: product2 },
      { id: 3, name: "Hikvision C6S", price: "3.200.000đ", specs: "4K | HDR | WiFi", image: product3 },
    ],
  },
  {
    id: 2,
    name: "Camera Nghị Định 10",
    description: "Đáp ứng tiêu chuẩn Nghị định 10 của Bộ GTVT",
    specs: "GPS tích hợp | Lưu trữ đám mây | Cảnh báo tốc độ",
    icon: "📷",
    products: [
      { id: 4, name: "Vietmap ND10 Pro", price: "4.500.000đ", specs: "GPS | Cloud | 4G", image: product1 },
      { id: 5, name: "Huviron ND-10", price: "3.800.000đ", specs: "GPS | WiFi | FHD", image: product2 },
      { id: 6, name: "Hikvision ND10S", price: "5.200.000đ", specs: "4G | GPS | Cloud", image: product3 },
    ],
  },
  {
    id: 3,
    name: "Màn Hình Android",
    description: "Hệ thống giải trí thông minh cho xe hơi",
    specs: "Android 13 | WiFi | Bluetooth | Google Maps",
    icon: "📱",
    products: [
      { id: 7, name: "GOTECH GT10 Pro", price: "8.500.000đ", specs: "10 inch | Android 13 | 4GB RAM", image: product1 },
      { id: 8, name: "GOTECH GT9 Max", price: "7.200.000đ", specs: "9 inch | Android 13 | GPS", image: product2 },
      { id: 9, name: "GOTECH GT12 Ultra", price: "12.500.000đ", specs: "12 inch | Android 13 | 6GB RAM", image: product3 },
    ],
  },
  {
    id: 4,
    name: "Màn Hình Android Ô Tô",
    description: "Màn hình chuyên dụng tích hợp theo xe",
    specs: "Khớp theo xe | Carplay | 4G | DSP âm thanh",
    icon: "🖥️",
    products: [
      { id: 10, name: "Xenon X9 Toyota", price: "9.500.000đ", specs: "9 inch | Carplay | DSP", image: product1 },
      { id: 11, name: "Xenon X10 Honda", price: "10.200.000đ", specs: "10 inch | 4G | GPS", image: product2 },
      { id: 12, name: "Xenon X12 Mazda", price: "11.800.000đ", specs: "12 inch | Carplay | 6GB", image: product3 },
    ],
  },
]

/** Lọc sản phẩm */
export const filterProducts = (
  products: Product[],
  searchTerm: string,
  priceFilter: string,
  sizeFilter: string
): Product[] => {
  return products.filter((product) => {
    const matchesSearch = product.name.toLowerCase().includes(searchTerm.toLowerCase())
    const matchesPrice =
      priceFilter === "all" ||
      (priceFilter === "low" && product.price < 7000000) ||
      (priceFilter === "mid" && product.price >= 7000000 && product.price < 10000000) ||
      (priceFilter === "high" && product.price >= 10000000)
    const matchesSize = sizeFilter === "all" || product.size === sizeFilter
    return matchesSearch && matchesPrice && matchesSize
  })
}