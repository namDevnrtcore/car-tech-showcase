import Fastify  from "fastify"
import cors     from "@fastify/cors"
import helmet   from "@fastify/helmet"
import dotenv   from "dotenv"
import { screenRoutes }  from "./modules/carScreen/screen.route"
import { bannerRoutes }  from "./modules/banner/banner.route"
import { productRoutes } from "./modules/product/product.route"
import { ordersRoutes }  from "./modules/orders/orders.route"
import { newsRoutes }    from "./modules/news/news.route"

dotenv.config()

const app = Fastify({ logger: true })

app.register(cors,   { origin: "*" })
app.register(helmet, { contentSecurityPolicy: false })

app.register(screenRoutes,  { prefix: "/api/screens" })
app.register(bannerRoutes,  { prefix: "/api/banners" })
app.register(productRoutes, { prefix: "/api/products" })
app.register(ordersRoutes,  { prefix: "/api/orders" })
app.register(newsRoutes,    { prefix: "/api/news" })

app.get("/health", async () => ({ status: "ok" }))

app.listen({ 
    port: Number(process.env.PORT) || 3001,
    host: "0.0.0.0"
}, (err) => {
    if (err) { app.log.error(err); process.exit(1) }
})
