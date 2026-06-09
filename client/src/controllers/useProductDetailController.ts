// ============================================
// 📁 controllers/useProductDetailController.ts - Product Detail Controller
// ============================================

import { useState } from "react"
import { useParams } from "react-router-dom"
import { getProductDetail, getRelatedProducts, formatPrice } from "@/services/product.service"

/** Controller cho ProductDetail page - quản lý state chi tiết sản phẩm */
export const useProductDetailController = () => {
  const { id } = useParams()
  const [selectedImage, setSelectedImage] = useState(0)

  const product = getProductDetail(id)
  const relatedProducts = getRelatedProducts()

  return {
    id,
    product,
    relatedProducts,
    selectedImage,
    setSelectedImage,
    formatPrice,
  }
}