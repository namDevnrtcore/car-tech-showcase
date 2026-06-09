// ============================================
// 📁 views/pages/News.tsx - News Page View
// ============================================

import { Card, CardContent } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Calendar, User, ArrowRight } from "lucide-react";
import { useNewsController } from "@/controllers/useNewsController";

const News = () => {
  const { categories, selectedCategory, setSelectedCategory, featuredArticle, listArticles } = useNewsController();

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
        {selectedCategory === "all" && featuredArticle && (
          <Card className="glass-card border-border overflow-hidden mb-12 hover-lift">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-0">
              <div className="aspect-video md:aspect-auto">
                <img src={featuredArticle.image} alt={featuredArticle.title} className="w-full h-full object-cover" />
              </div>
              <CardContent className="p-8 flex flex-col justify-center">
                <div className="flex items-center gap-4 text-sm text-muted-foreground mb-4">
                  <span className="px-3 py-1 rounded-full bg-primary/10 text-primary font-medium">Nổi bật</span>
                  <div className="flex items-center gap-1"><Calendar className="w-4 h-4" /><span>{featuredArticle.date}</span></div>
                  <div className="flex items-center gap-1"><User className="w-4 h-4" /><span>{featuredArticle.author}</span></div>
                </div>
                <h2 className="text-3xl font-bold mb-4">{featuredArticle.title}</h2>
                <p className="text-muted-foreground mb-6">{featuredArticle.excerpt}</p>
                <Button className="w-fit">Đọc thêm<ArrowRight className="ml-2 w-4 h-4" /></Button>
              </CardContent>
            </div>
          </Card>
        )}

        {/* Articles Grid */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
          {listArticles.map((article) => (
            <Card key={article.id} className="glass-card border-border overflow-hidden group hover-lift">
              <div className="aspect-video overflow-hidden">
                <img src={article.image} alt={article.title} className="w-full h-full object-cover group-hover:scale-110 transition-transform duration-500" />
              </div>
              <CardContent className="p-6">
                <div className="flex items-center gap-3 text-xs text-muted-foreground mb-3">
                  <span className="px-2 py-1 rounded-full bg-primary/10 text-primary font-medium">
                    {categories.find((c) => c.id === article.category)?.name}
                  </span>
                  <div className="flex items-center gap-1"><Calendar className="w-3 h-3" /><span>{article.date}</span></div>
                </div>
                <h3 className="text-xl font-semibold mb-3 line-clamp-2">{article.title}</h3>
                <p className="text-sm text-muted-foreground mb-4 line-clamp-3">{article.excerpt}</p>
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

        {listArticles.length === 0 && (
          <div className="text-center py-12">
            <p className="text-lg text-muted-foreground">Chưa có bài viết nào trong danh mục này.</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default News;