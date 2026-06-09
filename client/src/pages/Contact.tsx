// ============================================
// 📁 views/pages/Contact.tsx - Contact Page View
// ============================================

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { Card, CardContent } from "@/components/ui/card";
import { MapPin, Phone, Mail, Clock, Send } from "lucide-react";
import { useContactController } from "@/controllers/useContactController";

const iconMap: Record<string, any> = { MapPin, Phone, Mail, Clock };

const Contact = () => {
  const { formData, updateField, handleSubmit, contactInfo, mapUrl } = useContactController();

  return (
    <div className="min-h-screen py-24">
      <div className="container mx-auto px-4">
        {/* Header */}
        <div className="text-center mb-12">
          <h1 className="text-5xl font-bold mb-4">
            Liên hệ <span className="text-gradient">với chúng tôi</span>
          </h1>
          <p className="text-lg text-muted-foreground max-w-2xl mx-auto">
            Để lại thông tin hoặc ghé thăm showroom để được tư vấn trực tiếp
          </p>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-12 mb-12">
          {/* Contact Form */}
          <Card className="glass-card border-border">
            <CardContent className="p-8">
              <h2 className="text-2xl font-bold mb-6">Gửi tin nhắn cho chúng tôi</h2>
              <form onSubmit={handleSubmit} className="space-y-6">
                <div>
                  <label className="block text-sm font-medium mb-2">Họ và tên <span className="text-primary">*</span></label>
                  <Input required value={formData.name} onChange={(e) => updateField("name", e.target.value)} placeholder="Nguyễn Văn A" />
                </div>
                <div>
                  <label className="block text-sm font-medium mb-2">Số điện thoại <span className="text-primary">*</span></label>
                  <Input required type="tel" value={formData.phone} onChange={(e) => updateField("phone", e.target.value)} placeholder="0123456789" />
                </div>
                <div>
                  <label className="block text-sm font-medium mb-2">Email</label>
                  <Input type="email" value={formData.email} onChange={(e) => updateField("email", e.target.value)} placeholder="email@example.com" />
                </div>
                <div>
                  <label className="block text-sm font-medium mb-2">Nội dung <span className="text-primary">*</span></label>
                  <Textarea required value={formData.message} onChange={(e) => updateField("message", e.target.value)} placeholder="Cho chúng tôi biết bạn quan tâm đến sản phẩm nào..." rows={5} />
                </div>
                <Button type="submit" size="lg" className="w-full glow-effect">
                  <Send className="w-5 h-5 mr-2" />Gửi tin nhắn
                </Button>
              </form>
            </CardContent>
          </Card>

          {/* Contact Info */}
          <div>
            <div className="space-y-6 mb-8">
              {contactInfo.map((info, index) => {
                const IconComponent = iconMap[info.icon];
                return (
                  <Card key={index} className="glass-card border-border">
                    <CardContent className="p-6">
                      <div className="flex gap-4">
                        <div className="flex-shrink-0 w-12 h-12 rounded-lg bg-primary/10 flex items-center justify-center">
                          {IconComponent && <IconComponent className="w-6 h-6 text-primary" />}
                        </div>
                        <div>
                          <h3 className="font-semibold mb-2">{info.title}</h3>
                          {info.link ? (
                            <a href={info.link} className="text-muted-foreground hover:text-primary transition-colors">{info.content}</a>
                          ) : (
                            <p className="text-muted-foreground whitespace-pre-line">{info.content}</p>
                          )}
                        </div>
                      </div>
                    </CardContent>
                  </Card>
                );
              })}
            </div>

            {/* Quick Contact Buttons */}
            <div className="grid grid-cols-2 gap-4">
              <a href="tel:0123456789">
                <Button size="lg" variant="outline" className="w-full"><Phone className="w-5 h-5 mr-2" />Gọi ngay</Button>
              </a>
              <a href="https://zalo.me/0123456789" target="_blank" rel="noopener noreferrer">
                <Button size="lg" className="w-full">
                  <svg className="w-5 h-5 mr-2" viewBox="0 0 24 24" fill="currentColor">
                    <path d="M12 0C5.373 0 0 5.373 0 12s5.373 12 12 12 12-5.373 12-12S18.627 0 12 0zm6.197 14.736c-.267.267-.642.534-1.069.801-1.283.802-3.26 1.604-5.128 1.604-1.87 0-3.845-.802-5.128-1.604-.427-.267-.802-.534-1.07-.801-.267-.267-.267-.534 0-.802.268-.267.643-.534 1.07-.801 1.283-.802 3.258-1.604 5.128-1.604 1.868 0 3.845.802 5.128 1.604.427.267.802.534 1.069.801.267.268.267.535 0 .802z"/>
                  </svg>
                  Chat Zalo
                </Button>
              </a>
            </div>
          </div>
        </div>

        {/* Map */}
        <Card className="glass-card border-border overflow-hidden">
          <CardContent className="p-0">
            <div className="aspect-video w-full">
              <iframe src={mapUrl} width="100%" height="100%" style={{ border: 0 }} allowFullScreen loading="lazy" referrerPolicy="no-referrer-when-downgrade" title="CarScreen Pro Location" />
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  );
};

export default Contact;