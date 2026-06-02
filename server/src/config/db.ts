const sql = require("mssql")
import dotenv from "dotenv"
dotenv.config()

const config = {
    server:   process.env.DB_SERVER!,
    port:     Number(process.env.DB_PORT) || 1433,
    database: process.env.DB_NAME!,
    user:     process.env.DB_USER!,
    password: process.env.DB_PASSWORD!,
    options: {
        encrypt:                false,
        trustServerCertificate: true,
        connectTimeout:         30000,
    },
    pool: {
        max:               10,
        min:               0,
        idleTimeoutMillis: 30000,
    }
}

const pool = new sql.ConnectionPool(config)
const poolConnect: Promise<void> = pool.connect()
poolConnect.catch((err: Error) => console.error("DB connection failed:", err))

export { pool, poolConnect, sql }
