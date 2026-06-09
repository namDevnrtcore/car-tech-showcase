// ============================================
// 📁 services/home.service.ts - Home Page Data Service
// ============================================

import heroImage from "@/assets/hero-car-screen.jpg"
import toyotaLogo from "@/assets/logocars/toyota.png"
import hondaLogo from "@/assets/logocars/honda.png"
import mazdaLogo from "@/assets/logocars/mazda.png"
import hyundaiLogo from "@/assets/logocars/hyundai.webp"
import kiaLogo from "@/assets/logocars/kia.png"
import mercedesLogo from "@/assets/logocars/mercedes.png"
import product1 from "@/assets/product-1.jpg"
import product2 from "@/assets/product-2.jpg"
import product3 from "@/assets/product-3.jpg"
import { Feature, Testimonial, CompatibleCar } from "@/models/types"

/** Hero image */
export const getHeroImage = () => heroImage

/** Features - Chính sách */
export const getFeatures = (): Feature[] => [
  { icon: "Shield", title: "Bảo hành 2 năm", description: "Chính hãng, uy tín" },
  { icon: "Headphones", title: "Hỗ trợ 24/7", description: "Tư vấn nhiệt tình" },
  { icon: "Check", title: "Lắp đặt miễn phí", description: "Tận nơi, chuyên nghiệp" },
]

/** Testimonials */
export const getTestimonials = (): Testimonial[] => [
  {
    name: "Anh Tuấn",
    car: "Toyota Camry",
    comment: "Màn hình rất mượt, âm thanh chất lượng. Lắp đặt nhanh chóng, chuyên nghiệp!",
    rating: 5,
  },
  {
    name: "Chị Hương",
    car: "Honda CR-V",
    comment: "Giao diện đẹp, dễ sử dụng. Giá cả hợp lý, đội ngũ tư vấn nhiệt tình.",
    rating: 5,
  },
]

/** Xe tương thích */
export const getCompatibleCars = (): CompatibleCar[] => [
  { name: "Toyota",   img: toyotaLogo,   models: "Camry, Vios, Fortuner..." },
  { name: "Honda",    img: hondaLogo,    models: "CR-V, City, Civic..." },
  { name: "Mazda",    img: mazdaLogo,    models: "CX-5, Mazda3, CX-8..." },
  { name: "Hyundai",  img: hyundaiLogo,  models: "Tucson, i10, Santa Fe..." },
  { name: "Kia",      img: kiaLogo,      models: "Seltos, Morning, Sorento..." },
  { name: "Mercedes", img: mercedesLogo, models: "C-Class, E-Class, GLC..." },
]

/** Tin tức nổi bật trên trang chủ */
export const getHomeNews = () => [
  {
    id: 1,
    title: "5 Lý do nên nâng cấp màn hình Android cho xe của bạn",
    excerpt: "Khám phá những lợi ích vượt trội khi nâng cấp màn hình Android cho ô tô và tại sao đây là khoản đầu tư đáng giá.",
    image: "https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800&auto=format&fit=crop",
    date: "15/01/2024",
    tag: "Hướng dẫn",
  },
  {
    id: 2,
    title: "Cách chọn màn hình ô tô phù hợp với dòng xe Toyota",
    excerpt: "Hướng dẫn chi tiết giúp bạn lựa chọn màn hình Android phù hợp nhất cho các dòng xe Toyota phổ biến tại Việt Nam.",
    image: "https://images.unsplash.com/photo-1609521263047-f8f205293f24?w=800&auto=format&fit=crop",
    date: "12/01/2024",
    tag: "Hướng dẫn",
  },
  {
    id: 3,
    title: "Xu hướng công nghệ màn hình ô tô năm 2024",
    excerpt: "Cập nhật những xu hướng mới nhất trong công nghệ màn hình ô tô, từ AI đến kết nối không dây tiên tiến.",
    image: "https://images.unsplash.com/photo-1581092918056-0c4c3acd3789?w=800&auto=format&fit=crop",
    date: "10/01/2024",
    tag: "Tin tức",
  },
]