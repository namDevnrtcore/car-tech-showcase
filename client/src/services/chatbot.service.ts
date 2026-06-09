// ============================================
// 📁 services/chatbot.service.ts - Chatbot Logic Service
// ============================================

/** Trả lời tự động từ bot */
export const getBotResponse = (input: string): string => {
  const lowerInput = input.toLowerCase()

  if (lowerInput.includes("giá") || lowerInput.includes("bao nhiêu")) {
    return "Giá màn hình ô tô của chúng tôi dao động từ 3.000.000đ đến 15.000.000đ tùy theo kích thước và tính năng. Bạn muốn xem sản phẩm nào cụ thể không?"
  } else if (lowerInput.includes("bảo hành")) {
    return "Tất cả sản phẩm đều được bảo hành 2 năm chính hãng. Chúng tôi cũng có chế độ đổi trả trong 7 ngày nếu có lỗi từ nhà sản xuất."
  } else if (lowerInput.includes("lắp đặt") || lowerInput.includes("cài đặt")) {
    return "Chúng tôi cung cấp dịch vụ lắp đặt tận nơi miễn phí trong khu vực nội thành. Thời gian lắp đặt khoảng 1-2 giờ tùy dòng xe."
  } else if (lowerInput.includes("liên hệ") || lowerInput.includes("số điện thoại")) {
    return "Bạn có thể liên hệ với chúng tôi qua hotline: 0123-456-789 hoặc email: info@carscreen.vn. Chúng tôi làm việc từ 8h-20h hàng ngày!"
  } else {
    return "Cảm ơn bạn đã liên hệ! Để được tư vấn chi tiết, vui lòng gọi hotline 0123-456-789 hoặc để lại thông tin, nhân viên sẽ liên hệ lại ngay."
  }
}