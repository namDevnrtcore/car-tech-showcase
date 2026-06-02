import { FastifyRequest, FastifyReply } from "fastify"
import * as service from "./screen.service"

export const getAll = async (req: FastifyRequest, reply: FastifyReply) => {
    const screens = await service.getAllScreens()
    return reply.send(screens)
}

export const getById = async (
    req: FastifyRequest<{ Params: { id: string } }>,
    reply: FastifyReply
) => {
    const screen = await service.getScreenById(Number(req.params.id))
    if (!screen) return reply.status(404).send({ message: "Screen not found" })
    return reply.send(screen)
}

export const create = async (
    req: FastifyRequest<{ Body: { screenName: string; location?: string; note?: string; typeId?: number } }>,
    reply: FastifyReply
) => {
    const screen = await service.createScreen(req.body)
    return reply.status(201).send(screen)
}

export const update = async (
    req: FastifyRequest<{ Params: { id: string }; Body: { screenName?: string; location?: string; note?: string; typeId?: number; isActive?: boolean } }>,
    reply: FastifyReply
) => {
    const screen = await service.updateScreen(Number(req.params.id), req.body)
    if (!screen) return reply.status(404).send({ message: "Screen not found" })
    return reply.send(screen)
}

export const remove = async (
    req: FastifyRequest<{ Params: { id: string } }>,
    reply: FastifyReply
) => {
    await service.deleteScreen(Number(req.params.id))
    return reply.status(204).send()
}
