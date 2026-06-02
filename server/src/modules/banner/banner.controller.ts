import { FastifyRequest, FastifyReply } from "fastify"
import * as service from "./banner.service"

export const getAll = async (req: FastifyRequest, reply: FastifyReply) =>
    reply.send(await service.getAll())

export const create = async (
    req: FastifyRequest<{ Body: { banner1?: string; banner2?: string } }>,
    reply: FastifyReply
) => reply.status(201).send(await service.create(req.body))

export const update = async (
    req: FastifyRequest<{ Params: { id: string }; Body: { banner1?: string; banner2?: string } }>,
    reply: FastifyReply
) => reply.send(await service.update(Number(req.params.id), req.body))

export const remove = async (
    req: FastifyRequest<{ Params: { id: string } }>,
    reply: FastifyReply
) => {
    await service.remove(Number(req.params.id))
    return reply.status(204).send()
}
