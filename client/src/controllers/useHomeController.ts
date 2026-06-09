// ============================================
// 📁 controllers/useHomeController.ts - Home Page Controller
// ============================================

import { Shield, Headphones, Check } from "lucide-react"
import { getFeatures, getTestimonials, getCompatibleCars, getHomeNews, getHeroImage } from "@/services/home.service"
import { getCategories } from "@/services/product.service"
import { Feature } from "@/models/types"

/** Map icon string to actual Lucide icon component */
const iconMap: Record<string, any> = {
  Shield,
  Headphones,
  Check,
}

/** Controller cho Home page - xử lý logic và data preparation */
export const useHomeController = () => {
  const heroImage = getHeroImage()
  const categories = getCategories()
  const testimonials = getTestimonials()
  const compatibleCars = getCompatibleCars()
  const homeNews = getHomeNews()

  // Map icon strings to actual components
  const features: Feature[] = getFeatures().map((f) => ({
    ...f,
    icon: iconMap[f.icon] || Shield,
  }))

  return {
    heroImage,
    features,
    categories,
    testimonials,
    compatibleCars,
    homeNews,
  }
}