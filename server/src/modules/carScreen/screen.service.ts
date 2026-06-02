import { pool, poolConnect, sql } from "../../config/db"

export const getAllScreens = async () => {
    await poolConnect
    const result = await pool.request()
        .query(`
            SELECT s.*, t.typeName, t.resolution, t.screenSize
            FROM carScreen s
            LEFT JOIN screenType t ON s.typeId = t.id
            WHERE s.isActive = 1
        `)
    return result.recordset
}

export const getScreenById = async (id: number) => {
    await poolConnect
    const result = await pool.request()
        .input("id", sql.Int, id)
        .query(`
            SELECT s.*, t.typeName, t.resolution, t.screenSize
            FROM carScreen s
            LEFT JOIN screenType t ON s.typeId = t.id
            WHERE s.id = @id
        `)
    return result.recordset[0]
}

export const createScreen = async (data: {
    screenName: string
    location?:  string
    note?:      string
    typeId?:    number
}) => {
    await poolConnect
    const result = await pool.request()
        .input("screenName", sql.NVarChar(200), data.screenName)
        .input("location",   sql.NVarChar(100), data.location ?? null)
        .input("note",       sql.NVarChar(500), data.note     ?? null)
        .input("typeId",     sql.Int,           data.typeId   ?? null)
        .query(`
            INSERT INTO carScreen (screenName, location, note, typeId)
            OUTPUT INSERTED.*
            VALUES (@screenName, @location, @note, @typeId)
        `)
    return result.recordset[0]
}

export const updateScreen = async (id: number, data: {
    screenName?: string
    location?:   string
    note?:       string
    typeId?:     number
    isActive?:   boolean
}) => {
    await poolConnect
    const result = await pool.request()
        .input("id",         sql.Int,           id)
        .input("screenName", sql.NVarChar(200), data.screenName ?? null)
        .input("location",   sql.NVarChar(100), data.location   ?? null)
        .input("note",       sql.NVarChar(500), data.note       ?? null)
        .input("typeId",     sql.Int,           data.typeId     ?? null)
        .input("isActive",   sql.Bit,           data.isActive   ?? null)
        .query(`
            UPDATE carScreen SET
                screenName = COALESCE(@screenName, screenName),
                location   = COALESCE(@location,   location),
                note       = COALESCE(@note,        note),
                typeId     = COALESCE(@typeId,      typeId),
                isActive   = COALESCE(@isActive,    isActive)
            OUTPUT INSERTED.*
            WHERE id = @id
        `)
    return result.recordset[0]
}

export const deleteScreen = async (id: number) => {
    await poolConnect
    await pool.request()
        .input("id", sql.Int, id)
        .query(`UPDATE carScreen SET isActive = 0 WHERE id = @id`)
}
