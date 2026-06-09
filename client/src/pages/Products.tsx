// ============================================
// 📁 views/pages/Products.tsx - Products Page View
// ============================================

import { Link } from "react-router-dom";
import { Card, CardContent } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Search } from "lucide-react";
import { useProductsController } from "@/controllers/useProductsController";

const Products = () => {
  const {
    products,
    searchTerm, setSearchTerm,
    priceFilter, setPriceFilter,
    sizeFilter, setSizeFilter,
    formatPrice,
    hasResults,
  } = useProductsController();

  return (
    <div className="min-h-screen py-24">
      <div className="container mx-auto px-4">
        {/* Header */}
        <div className="text-center mb-12">
          <h1 className="text-5xl font-bold mb-4">
            Sản phẩm <span className="text-gradient">của chúng tôi</span>
          </h1>
          <p className="text-lg text-muted-foreground max-w-2xl mx-auto">
            Khám phá bộ sưu tập màn hình Android ô tô cao cấp với công nghệ hiện đại nhất
          </p>
        </div>

        {/* Filters */}
        <div className="glass-card p-6 mb-8 rounded-xl">
          <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
            <div className="md:col-span-2">
              <div className="relative">
                <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 text-muted-foreground w-5 h-5" />
                <Input
                  placeholder="Tìm kiếm sản phẩm..."
                  value={searchTerm}
                  onChange={(e) => setSearchTerm(e.target.value)}
                  className="pl-10"
                />
              </div>
            </div>
            <Select value={priceFilter} onValueChange={setPriceFilter}>
              <SelectTrigger>
                <SelectValue placeholder="Lọc theo giá" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="all">Tất cả mức giá</SelectItem>
                <SelectItem value="low">Dưới 7 triệu</SelectItem>
                <SelectItem value="mid">7-10 triệu</SelectItem>
                <SelectItem value="high">Trên 10 triệu</SelectItem>
              </SelectContent>
            </Select>
            <Select value={sizeFilter} onValueChange={setSizeFilter}>
              <SelectTrigger>
                <SelectValue placeholder="Kích thước" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="all">Tất cả kích thước</SelectItem>
                <SelectItem value="7 inch">7 inch</SelectItem>
                <SelectItem value="9 inch">9 inch</SelectItem>
                <SelectItem value="10 inch">10 inch</SelectItem>
                <SelectItem value="12 inch">12 inch</SelectItem>
              </SelectContent>
            </Select>
          </div>
        </div>

        {/* Products Grid */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
          {products.map((product) => (
            <Card key={product.id} className="hover-lift glass-card border-border overflow-hidden group">
              <div className="aspect-square overflow-hidden bg-white">
                <img
                  src={product.image}
                  alt={product.name}
                  className="w-full h-full object-cover group-hover:scale-110 transition-transform duration-500"
                />
              </div>
              <CardContent className="p-6">
                <h3 className="text-xl font-semibold mb-2">{product.name}</h3>
                <p className="text-sm text-muted-foreground mb-3">{product.specs}</p>
                <div className="flex flex-wrap gap-2 mb-4">
                  {product.features.map((feature, index) => (
                    <span
                      key={index}
                      className="px-2 py-1 text-xs rounded-full bg-primary/10 text-primary"
                    >
                      {feature}
                    </span>
                  ))}
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-2xl font-bold text-primary">
                    {formatPrice(product.price)}
                  </span>
                  <Link to={`/product/${product.id}`}>
                    <Button>Chi tiết</Button>
                  </Link>
                </div>
              </CardContent>
            </Card>
          ))}
        </div>

        {!hasResults && (
          <div className="text-center py-12">
            <p className="text-lg text-muted-foreground">
              Không tìm thấy sản phẩm phù hợp. Vui lòng thử lại với bộ lọc khác.
            </p>
          </div>
        )}
      </div>
    </div>
  );
};

export default Products;