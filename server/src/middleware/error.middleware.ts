// ============================================
// 📁 middleware/error.middleware.ts - Error Handler
// ============================================

import { FastifyRequest, FastifyReply } from "fastify"
import responseView from "../views/response.view"

/** Global error handler cho Fastify */
export const errorHandler = async (
    error: Error,
    req: FastifyRequest,
    reply: FastifyReply
) => {
    req.log.error(error)

    const statusCode = (error as any).statusCode || 500
    const message = error.message || "Internal Server Error"

    return reply.status(statusCode).send(responseView.error(message))
}

/** Validation middleware cơ bản */
export const validateRequired = (fields: string[]) => {
    return async (req: FastifyRequest, reply: FastifyReply) => {
        const body = req.body as Record<string, unknown>
        if (!body) {
            return reply.status(400).send(responseView.error("Body is required"))
        }
        for (const field of fields) {
            if (!body[field]) {
                return reply.status(400).send(responseView.error(`Missing required field: ${field}`))
            }
        }
    }
}