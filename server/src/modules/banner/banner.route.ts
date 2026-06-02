import { FastifyInstance } from "fastify"
import * as controller from "./banner.controller"

export const bannerRoutes = async (app: FastifyInstance) => {
    app.get("/",       controller.getAll)
    app.post("/",      controller.create)
    app.put("/:id",    controller.update)
    app.delete("/:id", controller.remove)
}
