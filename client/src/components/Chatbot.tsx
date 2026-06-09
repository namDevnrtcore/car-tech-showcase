// ============================================
// 📁 views/components/Chatbot.tsx - Chatbot View
// ============================================

import { MessageCircle, X, Send } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { useChatbotController } from "@/controllers/useChatbotController";

const Chatbot = () => {
  const { isOpen, toggleChat, messages, inputValue, setInputValue, handleSend, handleKeyPress } = useChatbotController();

  return (
    <>
      {/* Chat Button */}
      <Button
        onClick={toggleChat}
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
              <div key={message.id} className={`flex ${message.sender === "user" ? "justify-end" : "justify-start"}`}>
                <div className={`max-w-[80%] px-4 py-2 rounded-2xl ${
                  message.sender === "user" ? "bg-primary text-white" : "bg-secondary text-foreground"
                }`}>
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
              onKeyPress={handleKeyPress}
              placeholder="Nhập tin nhắn..."
              className="flex-1"
            />
            <Button onClick={handleSend} size="icon"><Send className="w-4 h-4" /></Button>
          </div>
        </div>
      )}
    </>
  );
};

export default Chatbot;