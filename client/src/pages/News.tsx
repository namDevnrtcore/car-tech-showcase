import { useState } from "react";
import { Card, CardContent } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Calendar, User, ArrowRight } from "lucide-react";

const News = () => {
  const [selectedCategory, setSelectedCategory] = useState("all");

  const categories = [
    { id: "all", name: "Tất cả" },
    { id: "guide", name: "Hướng dẫn" },
    { id: "news", name: "Tin tức" },
    { id: "review", name: "Đánh giá" },
  ];

  const articles = [
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
  ];

  const filteredArticles =
    selectedCategory === "all"
      ? articles
      : articles.filter((article) => article.category === selectedCategory);

  return (
    <div className="min-h-screen py-24">
      <div className="container mx-auto px-4">
        {/* Header */}
        <div className="text-center mb-12">
          <h1 className="text-5xl font-bold mb-4">
            Tin tức & <span className="text-gradient">Hướng dẫn</span>
          </h1>
          <p className="text-lg text-muted-foreground max-w-2xl mx-auto">
            Cập nhật xu hướng công nghệ và kiến thức hữu ích về màn hình ô tô
          </p>
        </div>

        {/* Categories */}
        <div className="flex flex-wrap justify-center gap-3 mb-12">
          {categories.map((category) => (
            <Button
              key={category.id}
              variant={selectedCategory === category.id ? "default" : "outline"}
              onClick={() => setSelectedCategory(category.id)}
            >
              {category.name}
            </Button>
          ))}
        </div>

        {/* Featured Article */}
        {selectedCategory === "all" && (
          <Card className="glass-card border-border overflow-hidden mb-12 hover-lift">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-0">
              <div className="aspect-video md:aspect-auto">
                <img
                  src={articles[0].image}
                  alt={articles[0].title}
                  className="w-full h-full object-cover"
                />
              </div>
              <CardContent className="p-8 flex flex-col justify-center">
                <div className="flex items-center gap-4 text-sm text-muted-foreground mb-4">
                  <span className="px-3 py-1 rounded-full bg-primary/10 text-primary font-medium">
                    Nổi bật
                  </span>
                  <div className="flex items-center gap-1">
                    <Calendar className="w-4 h-4" />
                    <span>{articles[0].date}</span>
                  </div>
                  <div className="flex items-center gap-1">
                    <User className="w-4 h-4" />
                    <span>{articles[0].author}</span>
                  </div>
                </div>
                <h2 className="text-3xl font-bold mb-4">{articles[0].title}</h2>
                <p className="text-muted-foreground mb-6">{articles[0].excerpt}</p>
                <Button className="w-fit">
                  Đọc thêm
                  <ArrowRight className="ml-2 w-4 h-4" />
                </Button>
              </CardContent>
            </div>
          </Card>
        )}

        {/* Articles Grid */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
          {filteredArticles.slice(selectedCategory === "all" ? 1 : 0).map((article) => (
            <Card key={article.id} className="glass-card border-border overflow-hidden group hover-lift">
              <div className="aspect-video overflow-hidden">
                <img
                  src={article.image}
                  alt={article.title}
                  className="w-full h-full object-cover group-hover:scale-110 transition-transform duration-500"
                />
              </div>
              <CardContent className="p-6">
                <div className="flex items-center gap-3 text-xs text-muted-foreground mb-3">
                  <span className="px-2 py-1 rounded-full bg-primary/10 text-primary font-medium">
                    {categories.find((c) => c.id === article.category)?.name}
                  </span>
                  <div className="flex items-center gap-1">
                    <Calendar className="w-3 h-3" />
                    <span>{article.date}</span>
                  </div>
                </div>
                <h3 className="text-xl font-semibold mb-3 line-clamp-2">{article.title}</h3>
                <p className="text-sm text-muted-foreground mb-4 line-clamp-3">
                  {article.excerpt}
                </p>
                <div className="flex items-center justify-between">
                  <span className="text-xs text-muted-foreground">{article.readTime}</span>
                  <Button variant="ghost" size="sm" className="group">
                    Đọc thêm
                    <ArrowRight className="ml-2 w-4 h-4 group-hover:translate-x-1 transition-transform" />
                  </Button>
                </div>
              </CardContent>
            </Card>
          ))}
        </div>

        {filteredArticles.length === 0 && (
          <div className="text-center py-12">
            <p className="text-lg text-muted-foreground">
              Chưa có bài viết nào trong danh mục này.
            </p>
          </div>
        )}
      </div>
    </div>
  );
};

export default News;
