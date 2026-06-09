// ============================================
// 📁 services/banner.service.ts - Banner Business Logic
// ============================================

import BannerModel from "../models/banner.model"
import { IBannerCreate, IBannerUpdate } from "../types"

class BannerService {

    /** Lấy tất cả banner */
    async getAll() {
        return await BannerModel.findAll()
    }

    /** Tạo banner mới */
    async create(data: IBannerCreate) {
        return await BannerModel.create(data)
    }

    /** Cập nhật banner */
    async update(id: number, data: IBannerUpdate) {
        return await BannerModel.update(id, data)
    }

    /** Xóa banner */
    async remove(id: number) {
        await BannerModel.remove(id)
    }
}

export default new BannerService()