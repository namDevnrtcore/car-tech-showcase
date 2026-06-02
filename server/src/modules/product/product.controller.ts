import { FastifyRequest, FastifyReply } from "fastify"
import * as service from "./product.service"

export const getAll = async (req: FastifyRequest, reply: FastifyReply) =>
    reply.send(await service.getAll())
export const getById = async (req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) =>
    reply.send(await service.getById(Number(req.params.id)))
export const create = async (req: FastifyRequest<{ Body: { productName: string; price?: number; category?: string; description?: string; img?: string; spec?: string } }>, reply: FastifyReply) =>
    reply.status(201).send(await service.create(req.body))
export const update = async (req: FastifyRequest<{ Params: { id: string }; Body: { productName?: string; price?: number; category?: string; description?: string; img?: string; spec?: string; isActive?: boolean } }>, reply: FastifyReply) =>
    reply.send(await service.update(Number(req.params.id), req.body))
export const remove = async (req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) => {
    await service.remove(Number(req.params.id))
    return reply.status(204).send()
}
