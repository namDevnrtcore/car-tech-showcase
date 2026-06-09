// ============================================
// 📁 services/news.service.ts - News Business Logic
// ============================================

import NewsModel from "../models/news.model"
import { INewsCreate, INewsUpdate } from "../types"

class NewsService {

    /** Lấy tất cả news */
    async getAll() {
        return await NewsModel.findAll()
    }

    /** Tìm news theo ID */
    async getById(id: number) {
        return await NewsModel.findById(id)
    }

    /** Tạo news mới */
    async create(data: INewsCreate) {
        return await NewsModel.create(data)
    }

    /** Cập nhật news */
    async update(id: number, data: INewsUpdate) {
        return await NewsModel.update(id, data)
    }

    /** Xóa news */
    async remove(id: number) {
        await NewsModel.remove(id)
    }
}

export default new NewsService()