// ============================================
// 📁 models/banner.model.ts - Banner Data Access
// ============================================

import { pool, poolConnect, sql } from "../config/db"
import { IBanner, IBannerCreate, IBannerUpdate } from "../types"

class BannerModel {

    /** Lấy tất cả banner đang hoạt động */
    async findAll(): Promise<IBanner[]> {
        await poolConnect
        const result = await pool.request()
            .query("SELECT * FROM banner WHERE isActive = 1")
        return result.recordset
    }

    /** Tạo banner mới */
    async create(data: IBannerCreate): Promise<IBanner> {
        await poolConnect
        const result = await pool.request()
            .input("banner1", sql.NVarChar(500), data.banner1 ?? null)
            .input("banner2", sql.NVarChar(500), data.banner2 ?? null)
            .query("INSERT INTO banner (banner1, banner2) OUTPUT INSERTED.* VALUES (@banner1, @banner2)")
        return result.recordset[0]
    }

    /** Cập nhật banner theo ID */
    async update(id: number, data: IBannerUpdate): Promise<IBanner | null> {
        await poolConnect
        const result = await pool.request()
            .input("id",      sql.Int,           id)
            .input("banner1", sql.NVarChar(500), data.banner1 ?? null)
            .input("banner2", sql.NVarChar(500), data.banner2 ?? null)
            .query("UPDATE banner SET banner1=COALESCE(@banner1,banner1), banner2=COALESCE(@banner2,banner2) OUTPUT INSERTED.* WHERE id=@id")
        return result.recordset[0] || null
    }

    /** Soft delete banner theo ID */
    async remove(id: number): Promise<void> {
        await poolConnect
        await pool.request().input("id", sql.Int, id)
            .query("UPDATE banner SET isActive=0 WHERE id=@id")
    }
}

export default new BannerModel()