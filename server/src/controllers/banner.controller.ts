// ============================================
// 📁 controllers/banner.controller.ts - Banner Controller
// ============================================

import { FastifyRequest, FastifyReply } from "fastify"
import bannerService from "../services/banner.service"
import responseView from "../views/response.view"
import { IBannerCreate, IBannerUpdate } from "../types"

class BannerController {

    /** GET /api/banners */
    async getAll(req: FastifyRequest, reply: FastifyReply) {
        try {
            const banners = await bannerService.getAll()
            return reply.send(responseView.success(banners, "Lấy danh sách banner thành công", banners.length))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi lấy danh sách banner", error.message))
        }
    }

    /** POST /api/banners */
    async create(req: FastifyRequest<{ Body: IBannerCreate }>, reply: FastifyReply) {
        try {
            const banner = await bannerService.create(req.body)
            return reply.status(201).send(responseView.created(banner, "Tạo banner thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi tạo banner", error.message))
        }
    }

    /** PUT /api/banners/:id */
    async update(req: FastifyRequest<{ Params: { id: string }; Body: IBannerUpdate }>, reply: FastifyReply) {
        try {
            const banner = await bannerService.update(Number(req.params.id), req.body)
            if (!banner) return reply.status(404).send(responseView.notFound("Banner không tồn tại"))
            return reply.send(responseView.success(banner, "Cập nhật banner thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi cập nhật banner", error.message))
        }
    }

    /** DELETE /api/banners/:id */
    async remove(req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) {
        try {
            await bannerService.remove(Number(req.params.id))
            return reply.status(204).send()
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi xóa banner", error.message))
        }
    }
}

export default new BannerController()