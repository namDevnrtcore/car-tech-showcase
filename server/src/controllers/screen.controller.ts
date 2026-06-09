// ============================================
// 📁 controllers/screen.controller.ts - Screen Controller
// ============================================

import { FastifyRequest, FastifyReply } from "fastify"
import screenService from "../services/screen.service"
import responseView from "../views/response.view"
import { IScreenCreate, IScreenUpdate } from "../types"

class ScreenController {

    /** GET /api/screens */
    async getAll(req: FastifyRequest, reply: FastifyReply) {
        try {
            const screens = await screenService.getAll()
            return reply.send(responseView.success(screens, "Lấy danh sách screen thành công", screens.length))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi lấy danh sách screen", error.message))
        }
    }

    /** GET /api/screens/:id */
    async getById(req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) {
        try {
            const screen = await screenService.getById(Number(req.params.id))
            if (!screen) return reply.status(404).send(responseView.notFound("Screen không tồn tại"))
            return reply.send(responseView.success(screen, "Lấy screen thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi lấy screen", error.message))
        }
    }

    /** POST /api/screens */
    async create(req: FastifyRequest<{ Body: IScreenCreate }>, reply: FastifyReply) {
        try {
            const screen = await screenService.create(req.body)
            return reply.status(201).send(responseView.created(screen, "Tạo screen thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi tạo screen", error.message))
        }
    }

    /** PUT /api/screens/:id */
    async update(req: FastifyRequest<{ Params: { id: string }; Body: IScreenUpdate }>, reply: FastifyReply) {
        try {
            const screen = await screenService.update(Number(req.params.id), req.body)
            if (!screen) return reply.status(404).send(responseView.notFound("Screen không tồn tại"))
            return reply.send(responseView.success(screen, "Cập nhật screen thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi cập nhật screen", error.message))
        }
    }

    /** DELETE /api/screens/:id */
    async remove(req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) {
        try {
            await screenService.remove(Number(req.params.id))
            return reply.status(204).send()
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi xóa screen", error.message))
        }
    }
}

export default new ScreenController()