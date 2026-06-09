// ============================================
// 📁 routes/index.tsx - Route Configuration
// ============================================

import { Route, Routes } from "react-router-dom"
import Layout from "@/components/Layout"
import Home from "@/pages/Home"
import Products from "@/pages/Products"
import ProductDetail from "@/pages/ProductDetail"
import News from "@/pages/News"
import Contact from "@/pages/Contact"
import NotFound from "@/pages/NotFound"

/** App Routes Configuration */
const AppRoutes = () => (
  <Layout>
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/products" element={<Products />} />
      <Route path="/product/:id" element={<ProductDetail />} />
      <Route path="/news" element={<News />} />
      <Route path="/contact" element={<Contact />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  </Layout>
)

export default AppRoutes