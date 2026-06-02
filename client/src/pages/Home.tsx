import { Link } from "react-router-dom";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Star, Shield, Headphones, ArrowRight, Check } from "lucide-react";
import heroImage from "@/assets/hero-car-screen.jpg";
import product1 from "@/assets/product-1.jpg";
import product2 from "@/assets/product-2.jpg";
import product3 from "@/assets/product-3.jpg";
import toyotaLogo   from "@/assets/logocars/toyota.png"
import hondaLogo    from "@/assets/logocars/honda.png"
import mazdaLogo    from "@/assets/logocars/mazda.png"
import hyundaiLogo  from "@/assets/logocars/hyundai.webp"
import kiaLogo      from "@/assets/logocars/kia.png"
import mercedesLogo from "@/assets/logocars/mercedes.png"

const Home = () => {
  const features = [
    { icon: Shield, title: "Bảo hành 2 năm", description: "Chính hãng, uy tín" },
    { icon: Headphones, title: "Hỗ trợ 24/7", description: "Tư vấn nhiệt tình" },
    { icon: Check, title: "Lắp đặt miễn phí", description: "Tận nơi, chuyên nghiệp" },
  ];

  const categories = [
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
  ];

  const products = [
    { id: 1, name: "GOTECH GT10 Pro", price: "8.500.000đ", image: product1, specs: "10 inch | Android 13 | 4GB RAM" },
    { id: 2, name: "GOTECH GT9 Max", price: "7.200.000đ", image: product2, specs: "9 inch | Android 13 | GPS" },
    { id: 3, name: "GOTECH GT12 Ultra", price: "12.500.000đ", image: product3, specs: "12 inch | Android 13 | 6GB RAM" },
  ];

  const testimonials = [
    {
      name: "Anh Tuấn", car: "Toyota Camry",
      comment: "Màn hình rất mượt, âm thanh chất lượng. Lắp đặt nhanh chóng, chuyên nghiệp!",
      rating: 5,
    },
    {
      name: "Chị Hương", car: "Honda CR-V",
      comment: "Giao diện đẹp, dễ sử dụng. Giá cả hợp lý, đội ngũ tư vấn nhiệt tình.",
      rating: 5,
    },
  ];

  return (
    <div className="min-h-screen">
      {/* Hero Section */}
      <section className="relative h-[90vh] flex items-center justify-center overflow-hidden">
        <div className="absolute inset-0">
          <img src={heroImage} alt="Car Screen Hero" className="w-full h-full object-cover opacity-40" />
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
                Xem sản phẩm <ArrowRight className="ml-2 w-5 h-5" />
              </Button>
            </Link>
            <Link to="/contact">
              <Button size="lg" variant="outline" className="text-lg px-8">Liên hệ tư vấn</Button>
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

  

      {/* Categories + Products */}
      <section className="py-16 bg-card/50">
        <div className="container mx-auto px-4">
          <div className="text-center mb-12">
            <h2 className="text-4xl font-bold mb-4">
              Danh mục <span className="text-gradient">sản phẩm</span>
            </h2>
           
          </div>

          <div className="space-y-16">
            {categories.map((category) => (
              <div key={category.id}>
                {/* Category Header */}
                <div className="flex items-center gap-4 mb-8">
                  <span className="text-4xl">{category.icon}</span>
                  <div>
                    <h3 className="text-2xl font-bold">{category.name}</h3>
                    
                  </div>
                  <div className="ml-auto">
                    <Link to="/products">
                      <Button variant="outline">
                        Xem tất cả <ArrowRight className="ml-2 w-4 h-4" />
                      </Button>
                    </Link>
                  </div>
                </div>

                {/* Category Products */}
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                  {category.products.map((product) => (
                    <Card key={product.id} className="hover-lift glass-card border-border overflow-hidden group">
                      <div className="aspect-video overflow-hidden bg-white">
                        <img
                          src={product.image}
                          alt={product.name}
                          className="w-full h-full object-cover group-hover:scale-110 transition-transform duration-500"
                        />
                      </div>
                      <CardContent className="p-5">
                        <h4 className="text-lg font-semibold mb-1">{product.name}</h4>
                        <p className="text-sm text-muted-foreground mb-3">{product.specs}</p>
                        <div className="flex items-center justify-between">
                          <span className="text-xl font-bold text-primary">{product.price}</span>
                          <Link to={`/product/${product.id}`}>
                            <Button size="sm">Xem chi tiết</Button>
                          </Link>
                        </div>
                      </CardContent>
                    </Card>
                  ))}
                </div>

                {/* Divider */}
                <div className="border-b border-border mt-10" />
              </div>
            ))}
          </div>
        </div>
      </section>
{/* Latest News */}
<section className="py-16 bg-card/50">
  <div className="container mx-auto px-4">
    <div className="text-center mb-12">
      <h2 className="text-4xl font-bold mb-4">
        Tin tức <span className="text-gradient">mới nhất</span>
      </h2>
      <p className="text-lg text-muted-foreground">Cập nhật công nghệ và xu hướng xe hơi</p>
    </div>

    <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
      {[
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
      ].map((news) => (
        <Card key={news.id} className="hover-lift glass-card border-border overflow-hidden group cursor-pointer">
          <div className="aspect-video overflow-hidden">
            <img
              src={news.image}
              alt={news.title}
              className="w-full h-full object-cover group-hover:scale-110 transition-transform duration-500"
            />
          </div>
          <CardContent className="p-6">
            <div className="flex items-center gap-2 mb-3">
              <span className="text-xs bg-primary/10 text-primary px-2 py-1 rounded-full font-medium">
                {news.tag}
              </span>
              <span className="text-xs text-muted-foreground">{news.date}</span>
            </div>
            <h3 className="font-semibold text-lg mb-2 line-clamp-2 group-hover:text-primary transition-colors">
              {news.title}
            </h3>
            <p className="text-sm text-muted-foreground line-clamp-3">{news.excerpt}</p>
            <div className="mt-4">
              <Link to={`/news/${news.id}`}>
                <Button variant="ghost" size="sm" className="p-0 h-auto text-primary">
                  Đọc thêm <ArrowRight className="ml-1 w-4 h-4" />
                </Button>
              </Link>
            </div>
          </CardContent>
        </Card>
      ))}
    </div>

    <div className="text-center mt-10">
      <Link to="/news">
        <Button size="lg" variant="outline">
          Xem tất cả tin tức <ArrowRight className="ml-2 w-5 h-5" />
        </Button>
      </Link>
    </div>
  </div>
</section>

{/* Compatible Cars */}
<section className="py-16">
  <div className="container mx-auto px-4">
    <div className="text-center mb-12">
      <h2 className="text-4xl font-bold mb-4">
        Xe <span className="text-gradient">tương thích</span>
      </h2>
      <p className="text-lg text-muted-foreground">
        Sản phẩm của chúng tôi hỗ trợ hầu hết các dòng xe phổ biến tại Việt Nam
      </p>
    </div>

    <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-6 gap-4">
      {[
        { name: "Toyota",   img: toyotaLogo,   models: "Camry, Vios, Fortuner..." },
        { name: "Honda",    img: hondaLogo,    models: "CR-V, City, Civic..." },
        { name: "Mazda",    img: mazdaLogo,    models: "CX-5, Mazda3, CX-8..." },
        { name: "Hyundai",  img: hyundaiLogo,  models: "Tucson, i10, Santa Fe..." },
        { name: "Kia",      img: kiaLogo,      models: "Seltos, Morning, Sorento..." },
        { name: "Mercedes", img: mercedesLogo, models: "C-Class, E-Class, GLC..." },
      ].map((car, index) => (
        <Card key={index} className="hover-lift glass-card border-border cursor-pointer group">
          <CardContent className="p-6 text-center">
            <img
              src={car.img}
              alt={car.name}
              className="w-20 h-20 mx-auto mb-3 object-contain"
            />
            <h4 className="font-semibold group-hover:text-primary transition-colors">
              {car.name}
            </h4>
            <p className="text-xs text-muted-foreground mt-1 line-clamp-1">{car.models}</p>
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