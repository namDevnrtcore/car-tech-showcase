import { FastifyRequest, FastifyReply } from "fastify"
import * as service from "./orders.service"

export const getAll = async (req: FastifyRequest, reply: FastifyReply) =>
    reply.send(await service.getAll())
export const getById = async (req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) =>
    reply.send(await service.getById(Number(req.params.id)))
export const create = async (req: FastifyRequest<{ Body: { productName?: string; price?: string; quantity?: number; totalAmount?: string; fullName?: string; phone?: string; img?: string } }>, reply: FastifyReply) =>
    reply.status(201).send(await service.create(req.body))
export const updateStatus = async (req: FastifyRequest<{ Params: { id: string }; Body: { status: string } }>, reply: FastifyReply) =>
    reply.send(await service.updateStatus(Number(req.params.id), req.body.status))
