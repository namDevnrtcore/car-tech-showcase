import { FastifyRequest, FastifyReply } from "fastify"
import * as service from "./news.service"

export const getAll = async (req: FastifyRequest, reply: FastifyReply) =>
    reply.send(await service.getAll())
export const getById = async (req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) =>
    reply.send(await service.getById(Number(req.params.id)))
export const create = async (req: FastifyRequest<{ Body: { title?: string; summary?: string; content?: string; img?: string } }>, reply: FastifyReply) =>
    reply.status(201).send(await service.create(req.body))
export const update = async (req: FastifyRequest<{ Params: { id: string }; Body: { title?: string; summary?: string; content?: string; img?: string; isActive?: boolean } }>, reply: FastifyReply) =>
    reply.send(await service.update(Number(req.params.id), req.body))
export const remove = async (req: FastifyRequest<{ Params: { id: string } }>, reply: FastifyReply) => {
    await service.remove(Number(req.params.id))
    return reply.status(204).send()
}
