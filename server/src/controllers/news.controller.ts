// ============================================
// 📁 controllers/news.controller.ts - News Controller
// ============================================

import { FastifyRequest, FastifyReply } from "fastify"
import newsService from "../services/news.service"
import responseView from "../views/response.view"
import { INewsCreate, INewsUpdate } from "../types"

class NewsController {

    /** GET /api/news */
    async getAll(req: FastifyRequest, reply: FastifyReply) {
        try {
            const news = await newsService.getAll()
            return reply.send(responseView.success(news, "Lấy danh sách tin tức thành công", news.length))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi lấy danh sách tin tức", error.message))
        }
    }

    /** GET /api/news/:id */
    async getById(req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) {
        try {
            const news = await newsService.getById(Number(req.params.id))
            if (!news) return reply.status(404).send(responseView.notFound("Tin tức không tồn tại"))
            return reply.send(responseView.success(news, "Lấy tin tức thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi lấy tin tức", error.message))
        }
    }

    /** POST /api/news */
    async create(req: FastifyRequest<{ Body: INewsCreate }>, reply: FastifyReply) {
        try {
            const news = await newsService.create(req.body)
            return reply.status(201).send(responseView.created(news, "Tạo tin tức thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi tạo tin tức", error.message))
        }
    }

    /** PUT /api/news/:id */
    async update(req: FastifyRequest<{ Params: { id: string }; Body: INewsUpdate }>, reply: FastifyReply) {
        try {
            const news = await newsService.update(Number(req.params.id), req.body)
            if (!news) return reply.status(404).send(responseView.notFound("Tin tức không tồn tại"))
            return reply.send(responseView.success(news, "Cập nhật tin tức thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi cập nhật tin tức", error.message))
        }
    }

    /** DELETE /api/news/:id */
    async remove(req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) {
        try {
            await newsService.remove(Number(req.params.id))
            return reply.status(204).send()
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi xóa tin tức", error.message))
        }
    }
}

export default new NewsController()