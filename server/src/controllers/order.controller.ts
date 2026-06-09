// ============================================
// 📁 controllers/order.controller.ts - Order Controller
// ============================================

import { FastifyRequest, FastifyReply } from "fastify"
import orderService from "../services/order.service"
import responseView from "../views/response.view"
import { IOrderCreate } from "../types"

class OrderController {

    /** GET /api/orders */
    async getAll(req: FastifyRequest, reply: FastifyReply) {
        try {
            const orders = await orderService.getAll()
            return reply.send(responseView.success(orders, "Lấy danh sách đơn hàng thành công", orders.length))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi lấy danh sách đơn hàng", error.message))
        }
    }

    /** GET /api/orders/:id */
    async getById(req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) {
        try {
            const order = await orderService.getById(Number(req.params.id))
            if (!order) return reply.status(404).send(responseView.notFound("Đơn hàng không tồn tại"))
            return reply.send(responseView.success(order, "Lấy đơn hàng thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi lấy đơn hàng", error.message))
        }
    }

    /** POST /api/orders */
    async create(req: FastifyRequest<{ Body: IOrderCreate }>, reply: FastifyReply) {
        try {
            const order = await orderService.create(req.body)
            return reply.status(201).send(responseView.created(order, "Tạo đơn hàng thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi tạo đơn hàng", error.message))
        }
    }

    /** PATCH /api/orders/:id/status */
    async updateStatus(req: FastifyRequest<{ Params: { id: string }; Body: { status: string } }>, reply: FastifyReply) {
        try {
            const order = await orderService.updateStatus(Number(req.params.id), req.body.status)
            if (!order) return reply.status(404).send(responseView.notFound("Đơn hàng không tồn tại"))
            return reply.send(responseView.success(order, "Cập nhật trạng thái thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi cập nhật trạng thái", error.message))
        }
    }
}

export default new OrderController()