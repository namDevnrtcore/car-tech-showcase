import { useState } from "react";
import { useParams, Link } from "react-router-dom";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Badge } from "@/components/ui/badge";
import { Star, Check, Phone, MessageCircle, ArrowLeft, Shield, Truck, Headphones } from "lucide-react";
import product1 from "@/assets/product-1.jpg";
import product2 from "@/assets/product-2.jpg";
import product3 from "@/assets/product-3.jpg";

const ProductDetail = () => {
  const { id } = useParams();
  const [selectedImage, setSelectedImage] = useState(0);

  // Mock product data - in real app, fetch from API
  const product = {
    id: id,
    name: "GOTECH GT10 Pro",
    price: 8500000,
    status: "Còn hàng",
    rating: 4.8,
    reviews: 127,
    images: [product1, product2, product3],
    description: "Màn hình Android GOTECH GT10 Pro là giải pháp hoàn hảo để nâng cấp hệ thống giải trí trên xe của bạn với công nghệ hiện đại nhất.",
    specs: {
      size: "10 inch IPS",
      os: "Android 13",
      ram: "4GB",
      rom: "64GB",
      connectivity: "Bluetooth 5.0, WiFi, USB, CarPlay không dây",
      warranty: "2 năm chính hãng",
    },
    features: [
      {
        title: "Màn hình IPS Full HD",
        description: "Độ phân giải cao, góc nhìn rộng, hiển thị sắc nét trong mọi điều kiện ánh sáng",
      },
      {
        title: "Android 13 mới nhất",
        description: "Hệ điều hành mượt mà, ổn định với khả năng tùy biến cao",
      },
      {
        title: "Kết nối đa dạng",
        description: "Hỗ trợ CarPlay không dây, Android Auto, Bluetooth, WiFi",
      },
      {
        title: "GPS tích hợp",
        description: "Định vị chính xác, dẫn đường thông minh với bản đồ offline",
      },
      {
        title: "Camera 360 độ",
        description: "Hỗ trợ camera lùi, camera 360 độ giúp quan sát toàn cảnh",
      },
      {
        title: "Âm thanh DSP",
        description: "Xử lý âm thanh DSP 32 kênh, mang đến trải nghiệm nghe nhạc đỉnh cao",
      },
    ],
  };

  const relatedProducts = [
    {
      id: 2,
      name: "GOTECH GT9 Max",
      price: 7200000,
      image: product2,
    },
    {
      id: 3,
      name: "GOTECH GT12 Ultra",
      price: 12500000,
      image: product3,
    },
  ];

  const formatPrice = (price: number) => {
    return new Intl.NumberFormat("vi-VN", {
      style: "currency",
      currency: "VND",
    }).format(price);
  };

  return (
    <div className="min-h-screen py-24">
      <div className="container mx-auto px-4">
        {/* Breadcrumb */}
        <div className="flex items-center gap-2 text-sm text-muted-foreground mb-8">
          <Link to="/" className="hover:text-primary transition-colors">
            Trang chủ
          </Link>
          <span>/</span>
          <Link to="/products" className="hover:text-primary transition-colors">
            Sản phẩm
          </Link>
          <span>/</span>
          <span className="text-foreground">{product.name}</span>
        </div>

        <Link to="/products" className="inline-flex items-center gap-2 text-sm text-muted-foreground hover:text-primary transition-colors mb-6">
          <ArrowLeft className="w-4 h-4" />
          Quay lại danh sách sản phẩm
        </Link>

        {/* Main Product Section */}
        <div className="grid grid-cols-1 lg:grid-cols-2 gap-12 mb-16">
          {/* Images */}
          <div>
            <div className="aspect-square rounded-2xl overflow-hidden bg-white mb-4">
              <img
                src={product.images[selectedImage]}
                alt={product.name}
                className="w-full h-full object-cover"
              />
            </div>
            <div className="grid grid-cols-3 gap-4">
              {product.images.map((image, index) => (
                <button
                  key={index}
                  onClick={() => setSelectedImage(index)}
                  className={`aspect-square rounded-lg overflow-hidden bg-white border-2 transition-all ${
                    selectedImage === index ? "border-primary scale-105" : "border-transparent"
                  }`}
                >
                  <img src={image} alt={`Preview ${index + 1}`} className="w-full h-full object-cover" />
                </button>
              ))}
            </div>
          </div>

          {/* Product Info */}
          <div>
            <h1 className="text-4xl font-bold mb-4">{product.name}</h1>
            
            <div className="flex items-center gap-4 mb-6">
              <div className="flex items-center gap-1">
                {[...Array(5)].map((_, i) => (
                  <Star
                    key={i}
                    className={`w-5 h-5 ${
                      i < Math.floor(product.rating)
                        ? "fill-primary text-primary"
                        : "text-muted-foreground"
                    }`}
                  />
                ))}
                <span className="ml-2 text-sm text-muted-foreground">
                  {product.rating} ({product.reviews} đánh giá)
                </span>
              </div>
              <Badge variant={product.status === "Còn hàng" ? "default" : "secondary"}>
                {product.status}
              </Badge>
            </div>

            <div className="mb-6">
              <div className="text-4xl font-bold text-primary mb-2">
                {formatPrice(product.price)}
              </div>
              <p className="text-muted-foreground">{product.description}</p>
            </div>

            {/* Quick Specs */}
            <div className="glass-card p-4 mb-6 rounded-xl">
              <h3 className="font-semibold mb-3">Thông số nhanh</h3>
              <div className="grid grid-cols-2 gap-3 text-sm">
                <div>
                  <span className="text-muted-foreground">Kích thước:</span>
                  <span className="ml-2 font-medium">{product.specs.size}</span>
                </div>
                <div>
                  <span className="text-muted-foreground">Hệ điều hành:</span>
                  <span className="ml-2 font-medium">{product.specs.os}</span>
                </div>
                <div>
                  <span className="text-muted-foreground">RAM:</span>
                  <span className="ml-2 font-medium">{product.specs.ram}</span>
                </div>
                <div>
                  <span className="text-muted-foreground">ROM:</span>
                  <span className="ml-2 font-medium">{product.specs.rom}</span>
                </div>
              </div>
            </div>

            {/* CTA Buttons */}
            <div className="flex flex-col gap-3 mb-6">
              <Link to="/contact">
                <Button size="lg" className="w-full glow-effect">
                  <Phone className="w-5 h-5 mr-2" />
                  Liên hệ đặt hàng
                </Button>
              </Link>
              <Button size="lg" variant="outline" className="w-full">
                <MessageCircle className="w-5 h-5 mr-2" />
                Tư vấn qua Zalo
              </Button>
              <a href="tel:0123456789">
                <Button size="lg" variant="secondary" className="w-full">
                  <Phone className="w-5 h-5 mr-2" />
                  Gọi ngay: 0123-456-789
                </Button>
              </a>
            </div>

            {/* Guarantees */}
            <div className="grid grid-cols-3 gap-4">
              <div className="text-center p-3 glass-card rounded-lg">
                <Shield className="w-6 h-6 text-primary mx-auto mb-2" />
                <p className="text-xs text-muted-foreground">Bảo hành 2 năm</p>
              </div>
              <div className="text-center p-3 glass-card rounded-lg">
                <Truck className="w-6 h-6 text-primary mx-auto mb-2" />
                <p className="text-xs text-muted-foreground">Lắp đặt miễn phí</p>
              </div>
              <div className="text-center p-3 glass-card rounded-lg">
                <Headphones className="w-6 h-6 text-primary mx-auto mb-2" />
                <p className="text-xs text-muted-foreground">Hỗ trợ 24/7</p>
              </div>
            </div>
          </div>
        </div>

        {/* Detailed Information Tabs */}
        <Tabs defaultValue="features" className="mb-16">
          <TabsList className="grid w-full grid-cols-3 mb-8">
            <TabsTrigger value="features">Tính năng nổi bật</TabsTrigger>
            <TabsTrigger value="specs">Thông số kỹ thuật</TabsTrigger>
            <TabsTrigger value="reviews">Đánh giá</TabsTrigger>
          </TabsList>

          <TabsContent value="features" className="space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
              {product.features.map((feature, index) => (
                <Card key={index} className="glass-card border-border">
                  <CardContent className="p-6">
                    <div className="flex gap-4">
                      <div className="flex-shrink-0 w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center">
                        <Check className="w-6 h-6 text-primary" />
                      </div>
                      <div>
                        <h3 className="font-semibold mb-2">{feature.title}</h3>
                        <p className="text-sm text-muted-foreground">{feature.description}</p>
                      </div>
                    </div>
                  </CardContent>
                </Card>
              ))}
            </div>
          </TabsContent>

          <TabsContent value="specs">
            <Card className="glass-card border-border">
              <CardContent className="p-6">
                <div className="space-y-4">
                  {Object.entries(product.specs).map(([key, value]) => (
                    <div key={key} className="flex justify-between py-3 border-b border-border last:border-0">
                      <span className="font-medium capitalize">{key.replace(/([A-Z])/g, " $1").trim()}:</span>
                      <span className="text-muted-foreground">{value}</span>
                    </div>
                  ))}
                </div>
              </CardContent>
            </Card>
          </TabsContent>

          <TabsContent value="reviews">
            <div className="space-y-6">
              <Card className="glass-card border-border">
                <CardContent className="p-6">
                  <div className="flex items-center gap-4 mb-4">
                    <div className="flex gap-1">
                      {[...Array(5)].map((_, i) => (
                        <Star key={i} className="w-5 h-5 fill-primary text-primary" />
                      ))}
                    </div>
                    <span className="font-semibold">Anh Tuấn - Toyota Camry</span>
                  </div>
                  <p className="text-muted-foreground">
                    Màn hình rất mượt, giao diện đẹp. Âm thanh chất lượng tốt. 
                    Đội ngũ lắp đặt chuyên nghiệp, tư vấn nhiệt tình. Rất hài lòng với sản phẩm!
                  </p>
                </CardContent>
              </Card>

              <Card className="glass-card border-border">
                <CardContent className="p-6">
                  <div className="flex items-center gap-4 mb-4">
                    <div className="flex gap-1">
                      {[...Array(5)].map((_, i) => (
                        <Star key={i} className="w-5 h-5 fill-primary text-primary" />
                      ))}
                    </div>
                    <span className="font-semibold">Chị Hương - Honda CR-V</span>
                  </div>
                  <p className="text-muted-foreground">
                    Sản phẩm chất lượng, giá cả hợp lý. Kết nối CarPlay rất tiện lợi. 
                    Camera lùi hiển thị rõ nét. Đã giới thiệu cho nhiều người bạn!
                  </p>
                </CardContent>
              </Card>
            </div>
          </TabsContent>
        </Tabs>

        {/* Related Products */}
        <div>
          <h2 className="text-3xl font-bold mb-8">
            Sản phẩm <span className="text-gradient">liên quan</span>
          </h2>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
            {relatedProducts.map((relatedProduct) => (
              <Card key={relatedProduct.id} className="hover-lift glass-card border-border overflow-hidden group">
                <div className="aspect-square overflow-hidden bg-white">
                  <img
                    src={relatedProduct.image}
                    alt={relatedProduct.name}
                    className="w-full h-full object-cover group-hover:scale-110 transition-transform duration-500"
                  />
                </div>
                <CardContent className="p-4">
                  <h3 className="font-semibold mb-2">{relatedProduct.name}</h3>
                  <div className="flex items-center justify-between">
                    <span className="text-lg font-bold text-primary">
                      {formatPrice(relatedProduct.price)}
                    </span>
                    <Link to={`/product/${relatedProduct.id}`}>
                      <Button size="sm">Xem</Button>
                    </Link>
                  </div>
                </CardContent>
              </Card>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProductDetail;
