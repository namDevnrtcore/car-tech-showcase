import { useState } from "react";
import { MessageCircle, X, Send } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";

interface Message {
  id: number;
  text: string;
  sender: "user" | "bot";
  timestamp: Date;
}

const Chatbot = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [messages, setMessages] = useState<Message[]>([
    {
      id: 1,
      text: "Xin chào! Tôi có thể giúp gì cho bạn về màn hình ô tô?",
      sender: "bot",
      timestamp: new Date(),
    },
  ]);
  const [inputValue, setInputValue] = useState("");

  const handleSend = () => {
    if (!inputValue.trim()) return;

    const userMessage: Message = {
      id: messages.length + 1,
      text: inputValue,
      sender: "user",
      timestamp: new Date(),
    };

    setMessages([...messages, userMessage]);
    setInputValue("");

    // Simulate bot response
    setTimeout(() => {
      const botResponse: Message = {
        id: messages.length + 2,
        text: getBotResponse(inputValue),
        sender: "bot",
        timestamp: new Date(),
      };
      setMessages((prev) => [...prev, botResponse]);
    }, 1000);
  };

  const getBotResponse = (input: string): string => {
    const lowerInput = input.toLowerCase();
    
    if (lowerInput.includes("giá") || lowerInput.includes("bao nhiêu")) {
      return "Giá màn hình ô tô của chúng tôi dao động từ 3.000.000đ đến 15.000.000đ tùy theo kích thước và tính năng. Bạn muốn xem sản phẩm nào cụ thể không?";
    } else if (lowerInput.includes("bảo hành")) {
      return "Tất cả sản phẩm đều được bảo hành 2 năm chính hãng. Chúng tôi cũng có chế độ đổi trả trong 7 ngày nếu có lỗi từ nhà sản xuất.";
    } else if (lowerInput.includes("lắp đặt") || lowerInput.includes("cài đặt")) {
      return "Chúng tôi cung cấp dịch vụ lắp đặt tận nơi miễn phí trong khu vực nội thành. Thời gian lắp đặt khoảng 1-2 giờ tùy dòng xe.";
    } else if (lowerInput.includes("liên hệ") || lowerInput.includes("số điện thoại")) {
      return "Bạn có thể liên hệ với chúng tôi qua hotline: 0123-456-789 hoặc email: info@carscreen.vn. Chúng tôi làm việc từ 8h-20h hàng ngày!";
    } else {
      return "Cảm ơn bạn đã liên hệ! Để được tư vấn chi tiết, vui lòng gọi hotline 0123-456-789 hoặc để lại thông tin, nhân viên sẽ liên hệ lại ngay.";
    }
  };

  return (
    <>
      {/* Chat Button */}
      <Button
        onClick={() => setIsOpen(!isOpen)}
        className="fixed bottom-6 right-6 h-14 w-14 rounded-full shadow-lg glow-effect z-50 animate-pulse-glow"
        size="icon"
      >
        {isOpen ? <X className="w-6 h-6" /> : <MessageCircle className="w-6 h-6" />}
      </Button>

      {/* Chat Window */}
      {isOpen && (
        <div className="fixed bottom-24 right-6 w-96 h-[500px] glass-card rounded-2xl shadow-2xl z-50 flex flex-col animate-slide-in-right">
          {/* Header */}
          <div className="bg-primary text-white p-4 rounded-t-2xl">
            <h3 className="font-semibold">Hỗ trợ trực tuyến</h3>
            <p className="text-sm opacity-90">Chúng tôi luôn sẵn sàng hỗ trợ bạn</p>
          </div>

          {/* Messages */}
          <div className="flex-1 overflow-y-auto p-4 space-y-4">
            {messages.map((message) => (
              <div
                key={message.id}
                className={`flex ${message.sender === "user" ? "justify-end" : "justify-start"}`}
              >
                <div
                  className={`max-w-[80%] px-4 py-2 rounded-2xl ${
                    message.sender === "user"
                      ? "bg-primary text-white"
                      : "bg-secondary text-foreground"
                  }`}
                >
                  <p className="text-sm">{message.text}</p>
                </div>
              </div>
            ))}
          </div>

          {/* Input */}
          <div className="p-4 border-t flex gap-2">
            <Input
              value={inputValue}
              onChange={(e) => setInputValue(e.target.value)}
              onKeyPress={(e) => e.key === "Enter" && handleSend()}
              placeholder="Nhập tin nhắn..."
              className="flex-1"
            />
            <Button onClick={handleSend} size="icon">
              <Send className="w-4 h-4" />
            </Button>
          </div>
        </div>
      )}
    </>
  );
};

export default Chatbot;
