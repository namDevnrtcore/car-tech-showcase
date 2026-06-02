import { pool, poolConnect, sql } from "../../config/db"

export const getAll = async () => {
    await poolConnect
    const result = await pool.request()
        .query("SELECT * FROM product WHERE isActive = 1")
    return result.recordset
}
export const getById = async (id: number) => {
    await poolConnect
    const result = await pool.request()
        .input("id", sql.Int, id)
        .query("SELECT p.*, pi.link as imageLink FROM product p LEFT JOIN productImage pi ON p.id = pi.productId WHERE p.id = @id")
    return result.recordset
}
export const create = async (data: { productName: string; price?: number; category?: string; description?: string; img?: string; spec?: string }) => {
    await poolConnect
    const result = await pool.request()
        .input("productName", sql.NVarChar(200), data.productName)
        .input("price",       sql.Float,         data.price       ?? null)
        .input("category",    sql.NVarChar(200), data.category    ?? null)
        .input("description", sql.NVarChar,      data.description ?? null)
        .input("img",         sql.NVarChar(300), data.img         ?? null)
        .input("spec",        sql.NVarChar,      data.spec        ?? null)
        .query("INSERT INTO product (productName,price,category,description,img,spec) OUTPUT INSERTED.* VALUES (@productName,@price,@category,@description,@img,@spec)")
    return result.recordset[0]
}
export const update = async (id: number, data: { productName?: string; price?: number; category?: string; description?: string; img?: string; spec?: string; isActive?: boolean }) => {
    await poolConnect
    const result = await pool.request()
        .input("id",          sql.Int,           id)
        .input("productName", sql.NVarChar(200), data.productName ?? null)
        .input("price",       sql.Float,         data.price       ?? null)
        .input("category",    sql.NVarChar(200), data.category    ?? null)
        .input("description", sql.NVarChar,      data.description ?? null)
        .input("img",         sql.NVarChar(300), data.img         ?? null)
        .input("spec",        sql.NVarChar,      data.spec        ?? null)
        .input("isActive",    sql.Bit,           data.isActive    ?? null)
        .query("UPDATE product SET productName=COALESCE(@productName,productName), price=COALESCE(@price,price), category=COALESCE(@category,category), description=COALESCE(@description,description), img=COALESCE(@img,img), spec=COALESCE(@spec,spec), isActive=COALESCE(@isActive,isActive) OUTPUT INSERTED.* WHERE id=@id")
    return result.recordset[0]
}
export const remove = async (id: number) => {
    await poolConnect
    await pool.request().input("id", sql.Int, id)
        .query("UPDATE product SET isActive=0 WHERE id=@id")
}
