// ============================================
// 📁 services/order.service.ts - Order Business Logic
// ============================================

import OrderModel from "../models/order.model"
import { IOrderCreate } from "../types"

class OrderService {

    /** Lấy tất cả orders */
    async getAll() {
        return await OrderModel.findAll()
    }

    /** Tìm order theo ID */
    async getById(id: number) {
        return await OrderModel.findById(id)
    }

    /** Tạo order mới */
    async create(data: IOrderCreate) {
        return await OrderModel.create(data)
    }

    /** Cập nhật trạng thái order */
    async updateStatus(id: number, status: string) {
        return await OrderModel.updateStatus(id, status)
    }
}

export default new OrderService()