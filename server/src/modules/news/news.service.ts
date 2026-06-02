import { pool, poolConnect, sql } from "../../config/db"

export const getAll = async () => {
    await poolConnect
    const result = await pool.request()
        .query("SELECT * FROM news WHERE isActive=1 ORDER BY createdAt DESC")
    return result.recordset
}
export const getById = async (id: number) => {
    await poolConnect
    const result = await pool.request()
        .input("id", sql.Int, id)
        .query("SELECT * FROM news WHERE id=@id")
    return result.recordset[0]
}
export const create = async (data: { title?: string; summary?: string; content?: string; img?: string }) => {
    await poolConnect
    const result = await pool.request()
        .input("title",   sql.NVarChar, data.title   ?? null)
        .input("summary", sql.NVarChar, data.summary ?? null)
        .input("content", sql.NVarChar, data.content ?? null)
        .input("img",     sql.NVarChar, data.img     ?? null)
        .query("INSERT INTO news (title,summary,content,img) OUTPUT INSERTED.* VALUES (@title,@summary,@content,@img)")
    return result.recordset[0]
}
export const update = async (id: number, data: { title?: string; summary?: string; content?: string; img?: string; isActive?: boolean }) => {
    await poolConnect
    const result = await pool.request()
        .input("id",       sql.Int,      id)
        .input("title",    sql.NVarChar, data.title    ?? null)
        .input("summary",  sql.NVarChar, data.summary  ?? null)
        .input("content",  sql.NVarChar, data.content  ?? null)
        .input("img",      sql.NVarChar, data.img      ?? null)
        .input("isActive", sql.Bit,      data.isActive ?? null)
        .query("UPDATE news SET title=COALESCE(@title,title), summary=COALESCE(@summary,summary), content=COALESCE(@content,content), img=COALESCE(@img,img), isActive=COALESCE(@isActive,isActive) OUTPUT INSERTED.* WHERE id=@id")
    return result.recordset[0]
}
export const remove = async (id: number) => {
    await poolConnect
    await pool.request().input("id", sql.Int, id)
        .query("UPDATE news SET isActive=0 WHERE id=@id")
}
