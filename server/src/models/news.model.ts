// ============================================
// 📁 models/news.model.ts - News Data Access
// ============================================

import { pool, poolConnect, sql } from "../config/db"
import { INews, INewsCreate, INewsUpdate } from "../types"

class NewsModel {

    /** Lấy tất cả news đang hoạt động */
    async findAll(): Promise<INews[]> {
        await poolConnect
        const result = await pool.request()
            .query("SELECT * FROM news WHERE isActive=1 ORDER BY createdAt DESC")
        return result.recordset
    }

    /** Tìm news theo ID */
    async findById(id: number): Promise<INews | null> {
        await poolConnect
        const result = await pool.request()
            .input("id", sql.Int, id)
            .query("SELECT * FROM news WHERE id=@id")
        return result.recordset[0] || null
    }

    /** Tạo news mới */
    async create(data: INewsCreate): Promise<INews> {
        await poolConnect
        const result = await pool.request()
            .input("title",   sql.NVarChar, data.title   ?? null)
            .input("summary", sql.NVarChar, data.summary ?? null)
            .input("content", sql.NVarChar, data.content ?? null)
            .input("img",     sql.NVarChar, data.img     ?? null)
            .query(`INSERT INTO news (title, summary, content, img) 
                    OUTPUT INSERTED.* 
                    VALUES (@title, @summary, @content, @img)`)
        return result.recordset[0]
    }

    /** Cập nhật news theo ID */
    async update(id: number, data: INewsUpdate): Promise<INews | null> {
        await poolConnect
        const result = await pool.request()
            .input("id",       sql.Int,      id)
            .input("title",    sql.NVarChar, data.title    ?? null)
            .input("summary",  sql.NVarChar, data.summary  ?? null)
            .input("content",  sql.NVarChar, data.content  ?? null)
            .input("img",      sql.NVarChar, data.img      ?? null)
            .input("isActive", sql.Bit,      data.isActive ?? null)
            .query(`UPDATE news 
                    SET title=COALESCE(@title,title), 
                        summary=COALESCE(@summary,summary), 
                        content=COALESCE(@content,content), 
                        img=COALESCE(@img,img), 
                        isActive=COALESCE(@isActive,isActive) 
                    OUTPUT INSERTED.* WHERE id=@id`)
        return result.recordset[0] || null
    }

    /** Soft delete news theo ID */
    async remove(id: number): Promise<void> {
        await poolConnect
        await pool.request().input("id", sql.Int, id)
            .query("UPDATE news SET isActive=0 WHERE id=@id")
    }
}

export default new NewsModel()