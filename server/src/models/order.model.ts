// ============================================
// 📁 models/order.model.ts - Order Data Access
// ============================================

import { pool, poolConnect, sql } from "../config/db"
import { IOrder, IOrderCreate } from "../types"

class OrderModel {

    /** Lấy tất cả orders */
    async findAll(): Promise<IOrder[]> {
        await poolConnect
        const result = await pool.request()
            .query("SELECT * FROM orders ORDER BY createdAt DESC")
        return result.recordset
    }

    /** Tìm order theo ID */
    async findById(id: number): Promise<IOrder | null> {
        await poolConnect
        const result = await pool.request()
            .input("id", sql.Int, id)
            .query("SELECT * FROM orders WHERE id=@id")
        return result.recordset[0] || null
    }

    /** Tạo order mới */
    async create(data: IOrderCreate): Promise<IOrder> {
        await poolConnect
        const result = await pool.request()
            .input("productName", sql.NVarChar(500), data.productName ?? null)
            .input("price",       sql.NVarChar(500), data.price       ?? null)
            .input("quantity",    sql.Int,           data.quantity    ?? null)
            .input("totalAmount", sql.NVarChar(50),  data.totalAmount ?? null)
            .input("fullName",    sql.NVarChar(100), data.fullName    ?? null)
            .input("phone",       sql.NVarChar(50),  data.phone       ?? null)
            .input("img",         sql.NVarChar(700), data.img         ?? null)
            .query(`INSERT INTO orders (productName, price, quantity, totalAmount, fullName, phone, img) 
                    OUTPUT INSERTED.* 
                    VALUES (@productName, @price, @quantity, @totalAmount, @fullName, @phone, @img)`)
        return result.recordset[0]
    }

    /** Cập nhật trạng thái order */
    async updateStatus(id: number, status: string): Promise<IOrder | null> {
        await poolConnect
        const result = await pool.request()
            .input("id",     sql.Int,          id)
            .input("status", sql.NVarChar(50), status)
            .query("UPDATE orders SET status=@status OUTPUT INSERTED.* WHERE id=@id")
        return result.recordset[0] || null
    }
}

export default new OrderModel()