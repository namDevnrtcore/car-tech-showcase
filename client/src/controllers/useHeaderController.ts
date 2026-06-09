// ============================================
// 📁 controllers/useHeaderController.ts - Header Controller
// ============================================

import { useState } from "react"
import { useLocation } from "react-router-dom"
import { NavItem } from "@/models/types"

/** Controller cho Header - quản lý menu state và navigation */
export const useHeaderController = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false)
  const location = useLocation()

  const navItems: NavItem[] = [
    { path: "/", label: "Trang chủ" },
    { path: "/products", label: "Sản phẩm" },
    { path: "/news", label: "Tin tức" },
    { path: "/contact", label: "Liên hệ" },
  ]

  const isActive = (path: string) => location.pathname === path

  const toggleMenu = () => setIsMenuOpen(!isMenuOpen)
  const closeMenu = () => setIsMenuOpen(false)

  return {
    isMenuOpen,
    toggleMenu,
    closeMenu,
    navItems,
    isActive,
  }
}