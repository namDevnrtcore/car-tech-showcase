import { Link } from "react-router-dom";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Star, Shield, Headphones, ArrowRight, Check } from "lucide-react";
import heroImage from "@/assets/hero-car-screen.jpg";
import product1 from "@/assets/product-1.jpg";
import product2 from "@/assets/product-2.jpg";
import product3 from "@/assets/product-3.jpg";

const Home = () => {
  const features = [
    {
      icon: Shield,
      title: "Bảo hành 2 năm",
      description: "Chính hãng, uy tín",
    },
    {
      icon: Headphones,
      title: "Hỗ trợ 24/7",
      description: "Tư vấn nhiệt tình",
    },
    {
      icon: Check,
      title: "Lắp đặt miễn phí",
      description: "Tận nơi, chuyên nghiệp",
    },
  ];

  const products = [
    {
      id: 1,
      name: "GOTECH GT10 Pro",
      price: "8.500.000đ",
      image: product1,
      specs: "10 inch | Android 13 | 4GB RAM",
    },
    {
      id: 2,
      name: "GOTECH GT9 Max",
      price: "7.200.000đ",
      image: product2,
      specs: "9 inch | Android 13 | GPS",
    },
    {
      id: 3,
      name: "GOTECH GT12 Ultra",
      price: "12.500.000đ",
      image: product3,
      specs: "12 inch | Android 13 | 6GB RAM",
    },
  ];

  const testimonials = [
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
  ];

  return (
    <div className="min-h-screen">
      {/* Hero Section */}
      <section className="relative h-[90vh] flex items-center justify-center overflow-hidden">
        <div className="absolute inset-0">
          <img
            src={heroImage}
            alt="Car Screen Hero"
            className="w-full h-full object-cover opacity-40"
          />
          <div className="absolute inset-0 bg-gradient-to-t from-background via-background/50 to-transparent" />
        </div>
        
        <div className="container mx-auto px-4 relative z-10 text-center animate-fade-in">
          <h1 className="text-5xl md:text-7xl font-bold mb-6">
            Nâng cấp trải nghiệm lái xe
            <br />
            <span className="text-gradient">với màn hình thông minh</span>
          </h1>
          <p className="text-xl md:text-2xl text-muted-foreground mb-8 max-w-2xl mx-auto">
            Công nghệ Android hiện đại, âm thanh sống động, lắp đặt chuyên nghiệp cho mọi dòng xe
          </p>
          <div className="flex gap-4 justify-center flex-wrap">
            <Link to="/products">
              <Button size="lg" className="glow-effect text-lg px-8">
                Xem sản phẩm
                <ArrowRight className="ml-2 w-5 h-5" />
              </Button>
            </Link>
            <Link to="/contact">
              <Button size="lg" variant="outline" className="text-lg px-8">
                Liên hệ tư vấn
              </Button>
            </Link>
          </div>
        </div>
      </section>

      {/* Features */}
      <section className="py-16 container mx-auto px-4">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          {features.map((feature, index) => (
            <Card key={index} className="hover-lift glass-card border-border">
              <CardContent className="p-6 text-center">
                <div className="mx-auto w-16 h-16 rounded-full bg-primary/10 flex items-center justify-center mb-4">
                  <feature.icon className="w-8 h-8 text-primary" />
                </div>
                <h3 className="text-xl font-semibold mb-2">{feature.title}</h3>
                <p className="text-muted-foreground">{feature.description}</p>
              </CardContent>
            </Card>
          ))}
        </div>
      </section>

      {/* About Section */}
      <section className="py-16 bg-card/50">
        <div className="container mx-auto px-4">
          <div className="max-w-3xl mx-auto text-center">
            <h2 className="text-4xl font-bold mb-6">
              Chuyên gia <span className="text-gradient">màn hình ô tô</span>
            </h2>
            <p className="text-lg text-muted-foreground mb-8">
              CarScreen Pro là đơn vị hàng đầu chuyên cung cấp màn hình Android cho ô tô với hơn 5 năm kinh nghiệm. 
              Chúng tôi cam kết mang đến sản phẩm chính hãng, chất lượng cao cùng dịch vụ lắp đặt chuyên nghiệp, 
              hỗ trợ kỹ thuật tận tâm.
            </p>
            <div className="flex justify-center gap-8 text-center">
              <div>
                <div className="text-4xl font-bold text-primary mb-2">5000+</div>
                <div className="text-muted-foreground">Khách hàng</div>
              </div>
              <div>
                <div className="text-4xl font-bold text-primary mb-2">100+</div>
                <div className="text-muted-foreground">Dòng xe</div>
              </div>
              <div>
                <div className="text-4xl font-bold text-primary mb-2">2 năm</div>
                <div className="text-muted-foreground">Bảo hành</div>
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* Featured Products */}
      <section className="py-16 container mx-auto px-4">
        <div className="text-center mb-12">
          <h2 className="text-4xl font-bold mb-4">
            Sản phẩm <span className="text-gradient">nổi bật</span>
          </h2>
          <p className="text-lg text-muted-foreground">
            Những mẫu màn hình được yêu thích nhất
          </p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
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
                <div className="flex items-center justify-between">
                  <span className="text-2xl font-bold text-primary">{product.price}</span>
                  <Link to={`/product/${product.id}`}>
                    <Button>Xem chi tiết</Button>
                  </Link>
                </div>
              </CardContent>
            </Card>
          ))}
        </div>

        <div className="text-center mt-12">
          <Link to="/products">
            <Button size="lg" variant="outline">
              Xem tất cả sản phẩm
              <ArrowRight className="ml-2 w-5 h-5" />
            </Button>
          </Link>
        </div>
      </section>

      {/* Testimonials */}
      <section className="py-16 bg-card/50">
        <div className="container mx-auto px-4">
          <div className="text-center mb-12">
            <h2 className="text-4xl font-bold mb-4">
              Khách hàng <span className="text-gradient">nói gì</span>
            </h2>
            <p className="text-lg text-muted-foreground">
              Những phản hồi thực tế từ người dùng
            </p>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-2 gap-8 max-w-4xl mx-auto">
            {testimonials.map((testimonial, index) => (
              <Card key={index} className="glass-card border-border">
                <CardContent className="p-6">
                  <div className="flex gap-1 mb-4">
                    {[...Array(testimonial.rating)].map((_, i) => (
                      <Star key={i} className="w-5 h-5 fill-primary text-primary" />
                    ))}
                  </div>
                  <p className="text-muted-foreground mb-4">"{testimonial.comment}"</p>
                  <div>
                    <p className="font-semibold">{testimonial.name}</p>
                    <p className="text-sm text-muted-foreground">{testimonial.car}</p>
                  </div>
                </CardContent>
              </Card>
            ))}
          </div>
        </div>
      </section>
    </div>
  );
};

export default Home;
