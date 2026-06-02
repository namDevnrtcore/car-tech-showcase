import { FastifyInstance } from "fastify"
import * as controller from "./orders.controller"

export const ordersRoutes = async (app: FastifyInstance) => {
    app.get("/",             controller.getAll)
    app.get("/:id",          controller.getById)
    app.post("/",            controller.create)
    app.patch("/:id/status", controller.updateStatus)
}
