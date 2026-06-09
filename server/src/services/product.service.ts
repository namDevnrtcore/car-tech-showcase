// ============================================
// 📁 services/product.service.ts - Product Business Logic
// ============================================

import ProductModel from "../models/product.model"
import { IProductCreate, IProductUpdate } from "../types"

class ProductService {

    /** Lấy tất cả product */
    async getAll() {
        return await ProductModel.findAll()
    }

    /** Tìm product theo ID */
    async getById(id: number) {
        return await ProductModel.findById(id)
    }

    /** Tạo product mới */
    async create(data: IProductCreate) {
        return await ProductModel.create(data)
    }

    /** Cập nhật product */
    async update(id: number, data: IProductUpdate) {
        return await ProductModel.update(id, data)
    }

    /** Xóa product */
    async remove(id: number) {
        await ProductModel.remove(id)
    }
}

export default new ProductService()