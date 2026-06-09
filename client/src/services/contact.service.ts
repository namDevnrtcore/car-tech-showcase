// ============================================
// 📁 services/contact.service.ts - Contact Data Service
// ============================================

import { ContactInfo } from "@/models/types"

/** Thông tin liên hệ */
export const getContactInfo = (): ContactInfo[] => [
  {
    icon: "MapPin",
    title: "Địa chỉ showroom",
    content: "123 Đường ABC, Quận 1, TP. Hồ Chí Minh",
  },
  {
    icon: "Phone",
    title: "Số điện thoại",
    content: "0123-456-789",
    link: "tel:0123456789",
  },
  {
    icon: "Mail",
    title: "Email",
    content: "info@carscreen.vn",
    link: "mailto:info@carscreen.vn",
  },
  {
    icon: "Clock",
    title: "Giờ làm việc",
    content: "Thứ 2 - Thứ 7: 8:00 - 20:00\nChủ nhật: 9:00 - 18:00",
  },
]

/** Map embed URL */
export const getMapUrl = (): string =>
  "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.325485983894!2d106.69741731533395!3d10.782397192318234!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f4b3330bcc9%3A0x6d7d3bb29a636012!2zUXXhuq1uIDEsIFRow6BuaCBwaOG7kSBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1643000000000!5m2!1svi!2s"