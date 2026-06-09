// ============================================
// 📁 services/screen.service.ts - Screen Business Logic
// ============================================

import ScreenModel from "../models/screen.model"
import { IScreenCreate, IScreenUpdate } from "../types"

class ScreenService {

    /** Lấy tất cả screen */
    async getAll() {
        return await ScreenModel.findAll()
    }

    /** Tìm screen theo ID */
    async getById(id: number) {
        return await ScreenModel.findById(id)
    }

    /** Tạo screen mới */
    async create(data: IScreenCreate) {
        return await ScreenModel.create(data)
    }

    /** Cập nhật screen */
    async update(id: number, data: IScreenUpdate) {
        return await ScreenModel.update(id, data)
    }

    /** Xóa screen */
    async remove(id: number) {
        await ScreenModel.remove(id)
    }
}

export default new ScreenService()