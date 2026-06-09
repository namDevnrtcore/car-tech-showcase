// ============================================
// 📁 controllers/product.controller.ts - Product Controller
// ============================================

import { FastifyRequest, FastifyReply } from "fastify"
import productService from "../services/product.service"
import responseView from "../views/response.view"
import { IProductCreate, IProductUpdate } from "../types"

class ProductController {

    /** GET /api/products */
    async getAll(req: FastifyRequest, reply: FastifyReply) {
        try {
            const products = await productService.getAll()
            return reply.send(responseView.success(products, "Lấy danh sách sản phẩm thành công", products.length))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi lấy danh sách sản phẩm", error.message))
        }
    }

    /** GET /api/products/:id */
    async getById(req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) {
        try {
            const product = await productService.getById(Number(req.params.id))
            if (!product) return reply.status(404).send(responseView.notFound("Sản phẩm không tồn tại"))
            return reply.send(responseView.success(product, "Lấy sản phẩm thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi lấy sản phẩm", error.message))
        }
    }

    /** POST /api/products */
    async create(req: FastifyRequest<{ Body: IProductCreate }>, reply: FastifyReply) {
        try {
            const product = await productService.create(req.body)
            return reply.status(201).send(responseView.created(product, "Tạo sản phẩm thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi tạo sản phẩm", error.message))
        }
    }

    /** PUT /api/products/:id */
    async update(req: FastifyRequest<{ Params: { id: string }; Body: IProductUpdate }>, reply: FastifyReply) {
        try {
            const product = await productService.update(Number(req.params.id), req.body)
            if (!product) return reply.status(404).send(responseView.notFound("Sản phẩm không tồn tại"))
            return reply.send(responseView.success(product, "Cập nhật sản phẩm thành công"))
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi cập nhật sản phẩm", error.message))
        }
    }

    /** DELETE /api/products/:id */
    async remove(req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) {
        try {
            await productService.remove(Number(req.params.id))
            return reply.status(204).send()
        } catch (error: any) {
            return reply.status(500).send(responseView.error("Lỗi xóa sản phẩm", error.message))
        }
    }
}

export default new ProductController()