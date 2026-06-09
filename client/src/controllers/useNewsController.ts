// ============================================
// 📁 controllers/useNewsController.ts - News Page Controller
// ============================================

import { useState, useMemo } from "react"
import { getArticles, getNewsCategories, filterArticles } from "@/services/news.service"

/** Controller cho News page - quản lý filter tin tức */
export const useNewsController = () => {
  const [selectedCategory, setSelectedCategory] = useState("all")

  const categories = useMemo(() => getNewsCategories(), [])
  const allArticles = useMemo(() => getArticles(), [])

  const filteredArticles = useMemo(
    () => filterArticles(allArticles, selectedCategory),
    [allArticles, selectedCategory]
  )

  return {
    categories,
    articles: filteredArticles,
    selectedCategory,
    setSelectedCategory,
    featuredArticle: filteredArticles[0],
    listArticles: selectedCategory === "all" ? filteredArticles.slice(1) : filteredArticles,
  }
}