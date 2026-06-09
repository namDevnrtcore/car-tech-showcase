// ============================================
// 📁 controllers/useContactController.ts - Contact Page Controller
// ============================================

import { useState } from "react"
import { toast } from "sonner"
import { getContactInfo, getMapUrl } from "@/services/contact.service"
import { ContactFormData } from "@/models/types"

/** Controller cho Contact page - quản lý form và submit logic */
export const useContactController = () => {
  const [formData, setFormData] = useState<ContactFormData>({
    name: "",
    phone: "",
    email: "",
    message: "",
  })

  const contactInfo = getContactInfo()
  const mapUrl = getMapUrl()

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    toast.success("Cảm ơn bạn đã liên hệ! Chúng tôi sẽ phản hồi sớm nhất.")
    setFormData({ name: "", phone: "", email: "", message: "" })
  }

  const updateField = (field: keyof ContactFormData, value: string) => {
    setFormData((prev) => ({ ...prev, [field]: value }))
  }

  return {
    formData,
    updateField,
    handleSubmit,
    contactInfo,
    mapUrl,
  }
}