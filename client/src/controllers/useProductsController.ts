// ============================================
// 📁 controllers/useProductsController.ts - Products Page Controller
// ============================================

import { useState, useMemo } from "react"
import { getProducts, filterProducts, formatPrice } from "@/services/product.service"

/** Controller cho Products page - quản lý state và filter logic */
export const useProductsController = () => {
  const [searchTerm, setSearchTerm] = useState("")
  const [priceFilter, setPriceFilter] = useState("all")
  const [sizeFilter, setSizeFilter] = useState("all")

  const allProducts = useMemo(() => getProducts(), [])

  const filteredProducts = useMemo(
    () => filterProducts(allProducts, searchTerm, priceFilter, sizeFilter),
    [allProducts, searchTerm, priceFilter, sizeFilter]
  )

  return {
    products: filteredProducts,
    searchTerm,
    setSearchTerm,
    priceFilter,
    setPriceFilter,
    sizeFilter,
    setSizeFilter,
    formatPrice,
    hasResults: filteredProducts.length > 0,
  }
}