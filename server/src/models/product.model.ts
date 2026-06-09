// ============================================
// 📁 models/product.model.ts - Product Data Access
// ============================================

import { pool, poolConnect, sql } from "../config/db"
import { IProduct, IProductCreate, IProductUpdate } from "../types"

class ProductModel {

    /** Lấy tất cả product đang hoạt động */
    async findAll(): Promise<IProduct[]> {
        await poolConnect
        const result = await pool.request()
            .query("SELECT * FROM product WHERE isActive = 1")
        return result.recordset
    }

    /** Tìm product theo ID */
    async findById(id: number): Promise<IProduct | null> {
        await poolConnect
        const result = await pool.request()
            .input("id", sql.Int, id)
            .query("SELECT * FROM product WHERE id=@id")
        return result.recordset[0] || null
    }

    /** Tạo product mới */
    async create(data: IProductCreate): Promise<IProduct> {
        await poolConnect
        const result = await pool.request()
            .input("productName", sql.NVarChar(255), data.productName)
            .input("price",       sql.Decimal(18,2), data.price      ?? null)
            .input("category",    sql.NVarChar(100), data.category   ?? null)
            .input("description", sql.NVarChar(sql.MAX), data.description ?? null)
            .input("img",         sql.NVarChar(700), data.img        ?? null)
            .input("spec",        sql.NVarChar(sql.MAX), data.spec    ?? null)
            .query(`INSERT INTO product (productName, price, category, description, img, spec) 
                    OUTPUT INSERTED.* 
                    VALUES (@productName, @price, @category, @description, @img, @spec)`)
        return result.recordset[0]
    }

    /** Cập nhật product theo ID */
    async update(id: number, data: IProductUpdate): Promise<IProduct | null> {
        await poolConnect
        const result = await pool.request()
            .input("id",          sql.Int,              id)
            .input("productName", sql.NVarChar(255),    data.productName ?? null)
            .input("price",       sql.Decimal(18,2),    data.price       ?? null)
            .input("category",    sql.NVarChar(100),    data.category    ?? null)
            .input("description", sql.NVarChar(sql.MAX), data.description ?? null)
            .input("img",         sql.NVarChar(700),    data.img         ?? null)
            .input("spec",        sql.NVarChar(sql.MAX), data.spec       ?? null)
            .input("isActive",    sql.Bit,              data.isActive    ?? null)
            .query(`UPDATE product 
                    SET productName=COALESCE(@productName,productName), 
                        price=COALESCE(@price,price), 
                        category=COALESCE(@category,category), 
                        description=COALESCE(@description,description), 
                        img=COALESCE(@img,img), 
                        spec=COALESCE(@spec,spec), 
                        isActive=COALESCE(@isActive,isActive) 
                    OUTPUT INSERTED.* WHERE id=@id`)
        return result.recordset[0] || null
    }

    /** Soft delete product theo ID */
    async remove(id: number): Promise<void> {
        await poolConnect
        await pool.request().input("id", sql.Int, id)
            .query("UPDATE product SET isActive=0 WHERE id=@id")
    }
}

export default new ProductModel()