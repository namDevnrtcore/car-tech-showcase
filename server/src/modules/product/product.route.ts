import { FastifyInstance } from "fastify"
import * as controller from "./product.controller"

export const productRoutes = async (app: FastifyInstance) => {
    app.get("/",       controller.getAll)
    app.get("/:id",    controller.getById)
    app.post("/",      controller.create)
    app.put("/:id",    controller.update)
    app.delete("/:id", controller.remove)
}
