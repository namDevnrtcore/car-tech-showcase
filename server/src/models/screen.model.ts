// ============================================
// 📁 models/screen.model.ts - Screen Data Access
// ============================================

import { pool, poolConnect, sql } from "../config/db"
import { IScreen, IScreenCreate, IScreenUpdate } from "../types"

class ScreenModel {

    /** Lấy tất cả screen đang hoạt động */
    async findAll(): Promise<IScreen[]> {
        await poolConnect
        const result = await pool.request()
            .query("SELECT * FROM carScreen WHERE isActive = 1")
        return result.recordset
    }

    /** Tìm screen theo ID */
    async findById(id: number): Promise<IScreen | null> {
        await poolConnect
        const result = await pool.request()
            .input("id", sql.Int, id)
            .query("SELECT * FROM carScreen WHERE id=@id")
        return result.recordset[0] || null
    }

    /** Tạo screen mới */
    async create(data: IScreenCreate): Promise<IScreen> {
        await poolConnect
        const result = await pool.request()
            .input("screenName", sql.NVarChar(255), data.screenName)
            .input("location",   sql.NVarChar(500), data.location ?? null)
            .input("note",       sql.NVarChar(500), data.note     ?? null)
            .input("typeId",     sql.Int,           data.typeId   ?? null)
            .query(`INSERT INTO carScreen (screenName, location, note, typeId) 
                    OUTPUT INSERTED.* 
                    VALUES (@screenName, @location, @note, @typeId)`)
        return result.recordset[0]
    }

    /** Cập nhật screen theo ID */
    async update(id: number, data: IScreenUpdate): Promise<IScreen | null> {
        await poolConnect
        const result = await pool.request()
            .input("id",         sql.Int,           id)
            .input("screenName", sql.NVarChar(255), data.screenName ?? null)
            .input("location",   sql.NVarChar(500), data.location   ?? null)
            .input("note",       sql.NVarChar(500), data.note       ?? null)
            .input("typeId",     sql.Int,           data.typeId     ?? null)
            .input("isActive",   sql.Bit,           data.isActive   ?? null)
            .query(`UPDATE carScreen 
                    SET screenName=COALESCE(@screenName,screenName), 
                        location=COALESCE(@location,location), 
                        note=COALESCE(@note,note), 
                        typeId=COALESCE(@typeId,typeId), 
                        isActive=COALESCE(@isActive,isActive) 
                    OUTPUT INSERTED.* WHERE id=@id`)
        return result.recordset[0] || null
    }

    /** Soft delete screen theo ID */
    async remove(id: number): Promise<void> {
        await poolConnect
        await pool.request().input("id", sql.Int, id)
            .query("UPDATE carScreen SET isActive=0 WHERE id=@id")
    }
}

export default new ScreenModel()