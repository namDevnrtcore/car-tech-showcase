// ============================================
// 📁 services/news.service.ts - News Data Service
// ============================================

import { Article } from "@/models/types"

/** Lấy danh sách bài viết tin tức */
export const getArticles = (): Article[] => [
  {
    id: 1,
    title: "5 Lý do nên nâng cấp màn hình Android cho xe của bạn",
    excerpt: "Khám phá những lợi ích vượt trội khi nâng cấp màn hình Android cho ô tô và tại sao đây là khoản đầu tư đáng giá.",
    image: "https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800&auto=format&fit=crop",
    category: "guide",
    date: "15/01/2024",
    author: "Admin",
    readTime: "5 phút đọc",
  },
  {
    id: 2,
    title: "Cách chọn màn hình ô tô phù hợp với dòng xe Toyota",
    excerpt: "Hướng dẫn chi tiết giúp bạn lựa chọn màn hình Android phù hợp nhất cho các dòng xe Toyota phổ biến tại Việt Nam.",
    image: "https://images.unsplash.com/photo-1609521263047-f8f205293f24?w=800&auto=format&fit=crop",
    category: "guide",
    date: "12/01/2024",
    author: "Admin",
    readTime: "7 phút đọc",
  },
  {
    id: 3,
    title: "Xu hướng công nghệ màn hình ô tô năm 2024",
    excerpt: "Cập nhật những xu hướng mới nhất trong công nghệ màn hình ô tô, từ AI đến kết nối không dây tiên tiến.",
    image: "https://images.unsplash.com/photo-1581092918056-0c4c3acd3789?w=800&auto=format&fit=crop",
    category: "news",
    date: "10/01/2024",
    author: "Admin",
    readTime: "6 phút đọc",
  },
  {
    id: 4,
    title: "So sánh màn hình Android vs màn hình zin theo xe",
    excerpt: "Đánh giá chi tiết ưu nhược điểm của màn hình Android aftermarket so với màn hình zin theo xe.",
    image: "https://images.unsplash.com/photo-1617654112368-307921291f42?w=800&auto=format&fit=crop",
    category: "review",
    date: "08/01/2024",
    author: "Admin",
    readTime: "8 phút đọc",
  },
  {
    id: 5,
    title: "Hướng dẫn sử dụng CarPlay và Android Auto hiệu quả",
    excerpt: "Tìm hiểu cách tận dụng tối đa tính năng CarPlay và Android Auto trên màn hình ô tô của bạn.",
    image: "https://images.unsplash.com/photo-1555597673-b21d5c935865?w=800&auto=format&fit=crop",
    category: "guide",
    date: "05/01/2024",
    author: "Admin",
    readTime: "6 phút đọc",
  },
  {
    id: 6,
    title: "Bảo dưỡng màn hình ô tô đúng cách",
    excerpt: "Những mẹo đơn giản giúp màn hình ô tô của bạn luôn hoạt động tốt và bền bỉ theo thời gian.",
    image: "https://images.unsplash.com/photo-1486262715619-67b85e0b08d3?w=800&auto=format&fit=crop",
    category: "guide",
    date: "01/01/2024",
    author: "Admin",
    readTime: "4 phút đọc",
  },
]

/** Danh mục bài viết */
export const getNewsCategories = (): { id: string; name: string }[] => [
  { id: "all", name: "Tất cả" },
  { id: "guide", name: "Hướng dẫn" },
  { id: "news", name: "Tin tức" },
  { id: "review", name: "Đánh giá" },
]

/** Lọc bài viết theo danh mục */
export const filterArticles = (articles: Article[], category: string): Article[] => {
  return category === "all" ? articles : articles.filter((a) => a.category === category)
}