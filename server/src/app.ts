// ============================================
// 📁 app.ts - Application Entry Point (MVC)
// ============================================

import Fastify from "fastify"
import cors from "@fastify/cors"
import helmet from "@fastify/helmet"
import dotenv from "dotenv"
import { registerRoutes } from "./routes"

dotenv.config()

const app = Fastify({ logger: true })

// ---------- Plugins ----------
app.register(cors,   { origin: "*" })
app.register(helmet, { contentSecurityPolicy: false })

// ---------- Routes ----------
registerRoutes(app)

// ---------- Start Server ----------
app.listen({
    port: Number(process.env.PORT) || 3001,
    host: "0.0.0.0"
}, (err) => {
    if (err) { app.log.error(err); process.exit(1) }
})