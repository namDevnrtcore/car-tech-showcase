// ============================================
// 📁 controllers/useChatbotController.ts - Chatbot Controller
// ============================================

import { useState } from "react"
import { getBotResponse } from "@/services/chatbot.service"
import { ChatMessage } from "@/models/types"

/** Controller cho Chatbot - quản lý tin nhắn và tương tác */
export const useChatbotController = () => {
  const [isOpen, setIsOpen] = useState(false)
  const [messages, setMessages] = useState<ChatMessage[]>([
    {
      id: 1,
      text: "Xin chào! Tôi có thể giúp gì cho bạn về màn hình ô tô?",
      sender: "bot",
      timestamp: new Date(),
    },
  ])
  const [inputValue, setInputValue] = useState("")

  const toggleChat = () => setIsOpen(!isOpen)

  const handleSend = () => {
    if (!inputValue.trim()) return

    const userMessage: ChatMessage = {
      id: messages.length + 1,
      text: inputValue,
      sender: "user",
      timestamp: new Date(),
    }

    setMessages((prev) => [...prev, userMessage])
    const currentInput = inputValue
    setInputValue("")

    setTimeout(() => {
      const botMessage: ChatMessage = {
        id: messages.length + 2,
        text: getBotResponse(currentInput),
        sender: "bot",
        timestamp: new Date(),
      }
      setMessages((prev) => [...prev, botMessage])
    }, 1000)
  }

  const handleKeyPress = (e: React.KeyboardEvent) => {
    if (e.key === "Enter") handleSend()
  }

  return {
    isOpen,
    toggleChat,
    messages,
    inputValue,
    setInputValue,
    handleSend,
    handleKeyPress,
  }
}