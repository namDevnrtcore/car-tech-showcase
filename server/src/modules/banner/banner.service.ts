import { pool, poolConnect, sql } from "../../config/db"

export const getAll = async () => {
    await poolConnect
    const result = await pool.request()
        .query("SELECT * FROM banner WHERE isActive = 1")
    return result.recordset
}
export const create = async (data: { banner1?: string; banner2?: string }) => {
    await poolConnect
    const result = await pool.request()
        .input("banner1", sql.NVarChar(500), data.banner1 ?? null)
        .input("banner2", sql.NVarChar(500), data.banner2 ?? null)
        .query("INSERT INTO banner (banner1, banner2) OUTPUT INSERTED.* VALUES (@banner1, @banner2)")
    return result.recordset[0]
}
export const update = async (id: number, data: { banner1?: string; banner2?: string }) => {
    await poolConnect
    const result = await pool.request()
        .input("id",      sql.Int,           id)
        .input("banner1", sql.NVarChar(500), data.banner1 ?? null)
        .input("banner2", sql.NVarChar(500), data.banner2 ?? null)
        .query("UPDATE banner SET banner1=COALESCE(@banner1,banner1), banner2=COALESCE(@banner2,banner2) OUTPUT INSERTED.* WHERE id=@id")
    return result.recordset[0]
}
export const remove = async (id: number) => {
    await poolConnect
    await pool.request().input("id", sql.Int, id)
        .query("UPDATE banner SET isActive=0 WHERE id=@id")
}
