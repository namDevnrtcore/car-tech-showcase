// ============================================
// 📁 app.ts - Application Entry Point (MVC)
// ============================================

import Fastify from "fastify"
import cors from "@fastify/cors"
import helmet from "@fastify/helmet"
import dotenv from "dotenv"
import path from "path"
import fs from "fs"
import { registerRoutes } from "./routes"

dotenv.config()

const app = Fastify({ logger: true })

// ---------- Plugins ----------
app.register(cors,   { origin: "*" })
app.register(helmet, { contentSecurityPolicy: false })

// ---------- Static Files (serve React build) ----------
const clientDistPath = path.resolve(__dirname, "../../client/dist")
if (fs.existsSync(clientDistPath)) {
    // eslint-disable-next-line @typescript-eslint/no-require-imports
    const fastifyStatic = require("@fastify/static")
    app.register(fastifyStatic, {
        root: clientDistPath,
        prefix: "/",
        wildcard: false,
    })
}

// ---------- Routes ----------
registerRoutes(app)

// ---------- SPA Fallback ----------
app.setNotFoundHandler((request, reply) => {
    // API routes return 404
    if (request.url.startsWith("/api")) {
        reply.code(404).send({ error: "Not found" })
        return
    }
    // All other routes serve index.html (SPA routing)
    const indexPath = path.join(clientDistPath, "index.html")
    if (fs.existsSync(indexPath)) {
        const html = fs.readFileSync(indexPath, "utf-8")
        reply.type("text/html").send(html)
    } else {
        reply.code(404).send({ error: "Not found" })
    }
})

// ---------- Start Server ----------
app.listen({
    port: Number(process.env.PORT) || 3001,
    host: "0.0.0.0"
}, (err) => {
    if (err) { app.log.error(err); process.exit(1) }
})
