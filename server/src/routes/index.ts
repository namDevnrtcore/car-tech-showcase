// ============================================
// 📁 routes/index.ts - Route Registry
// ============================================

import { FastifyInstance } from "fastify"
import bannerController from "../controllers/banner.controller"
import screenController from "../controllers/screen.controller"
import productController from "../controllers/product.controller"
import orderController from "../controllers/order.controller"
import newsController from "../controllers/news.controller"

/** Đăng ký tất cả routes cho ứng dụng */
export const registerRoutes = async (app: FastifyInstance) => {

    // ---------- Banner Routes ----------
    app.get("/api/banners",        bannerController.getAll.bind(bannerController))
    app.post("/api/banners",       bannerController.create.bind(bannerController))
    app.put("/api/banners/:id",    bannerController.update.bind(bannerController))
    app.delete("/api/banners/:id", bannerController.remove.bind(bannerController))

    // ---------- Screen Routes ----------
    app.get("/api/screens",        screenController.getAll.bind(screenController))
    app.get("/api/screens/:id",    screenController.getById.bind(screenController))
    app.post("/api/screens",       screenController.create.bind(screenController))
    app.put("/api/screens/:id",    screenController.update.bind(screenController))
    app.delete("/api/screens/:id", screenController.remove.bind(screenController))

    // ---------- Product Routes ----------
    app.get("/api/products",       productController.getAll.bind(productController))
    app.get("/api/products/:id",   productController.getById.bind(productController))
    app.post("/api/products",      productController.create.bind(productController))
    app.put("/api/products/:id",   productController.update.bind(productController))
    app.delete("/api/products/:id", productController.remove.bind(productController))

    // ---------- Order Routes ----------
    app.get("/api/orders",             orderController.getAll.bind(orderController))
    app.get("/api/orders/:id",         orderController.getById.bind(orderController))
    app.post("/api/orders",            orderController.create.bind(orderController))
    app.patch("/api/orders/:id/status", orderController.updateStatus.bind(orderController))

    // ---------- News Routes ----------
    app.get("/api/news",         newsController.getAll.bind(newsController))
    app.get("/api/news/:id",     newsController.getById.bind(newsController))
    app.post("/api/news",        newsController.create.bind(newsController))
    app.put("/api/news/:id",     newsController.update.bind(newsController))
    app.delete("/api/news/:id",  newsController.remove.bind(newsController))

    // ---------- Health Check ----------
    app.get("/health", async () => ({ status: "ok" }))
}