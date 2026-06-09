// ============================================
// 📁 models/types.ts - Frontend TypeScript Types
// ============================================

// ---------- Product ----------
export interface Product {
  id: number
  name: string
  price: number
  image?: string
  size: string
  specs: string
  features: string[]
}

// ---------- Product Detail ----------
export interface ProductDetail extends Product {
  status: string
  rating: number
  reviews: number
  images: string[]
  description: string
  detailedSpecs: {
    size: string
    os: string
    ram: string
    rom: string
    connectivity: string
    warranty: string
  }
  productFeatures: {
    title: string
    description: string
  }[]
}

// ---------- Category ----------
export interface Category {
  id: number
  name: string
  description: string
  specs: string
  icon: string
  products: CategoryProduct[]
}

export interface CategoryProduct {
  id: number
  name: string
  price: string
  specs: string
  image: string
}

// ---------- News / Article ----------
export interface Article {
  id: number
  title: string
  excerpt: string
  image: string
  category: string
  date: string
  author: string
  readTime: string
}

// ---------- Testimonial ----------
export interface Testimonial {
  name: string
  car: string
  comment: string
  rating: number
}

// ---------- Compatible Car ----------
export interface CompatibleCar {
  name: string
  img: string
  models: string
}

// ---------- Feature ----------
export interface Feature {
  icon: any
  title: string
  description: string
}

// ---------- Contact Form ----------
export interface ContactFormData {
  name: string
  phone: string
  email: string
  message: string
}

// ---------- Chat Message ----------
export interface ChatMessage {
  id: number
  text: string
  sender: "user" | "bot"
  timestamp: Date
}

// ---------- Navigation ----------
export interface NavItem {
  path: string
  label: string
}

// ---------- Contact Info ----------
export interface ContactInfo {
  icon: any
  title: string
  content: string
  link?: string
}