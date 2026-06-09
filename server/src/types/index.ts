// ============================================
// 📁 types/index.ts - TypeScript Interfaces
// ============================================

// ---------- Banner ----------
export interface IBanner {
    id: number
    banner1?: string
    banner2?: string
    isActive?: boolean
}

export interface IBannerCreate {
    banner1?: string
    banner2?: string
}

export interface IBannerUpdate {
    banner1?: string
    banner2?: string
    isActive?: boolean
}

// ---------- Screen ----------
export interface IScreen {
    id: number
    screenName: string
    location?: string
    note?: string
    typeId?: number
    isActive?: boolean
}

export interface IScreenCreate {
    screenName: string
    location?: string
    note?: string
    typeId?: number
}

export interface IScreenUpdate {
    screenName?: string
    location?: string
    note?: string
    typeId?: number
    isActive?: boolean
}

// ---------- Product ----------
export interface IProduct {
    id: number
    productName: string
    price?: number
    category?: string
    description?: string
    img?: string
    spec?: string
    isActive?: boolean
}

export interface IProductCreate {
    productName: string
    price?: number
    category?: string
    description?: string
    img?: string
    spec?: string
}

export interface IProductUpdate {
    productName?: string
    price?: number
    category?: string
    description?: string
    img?: string
    spec?: string
    isActive?: boolean
}

// ---------- Orders ----------
export interface IOrder {
    id: number
    productName?: string
    price?: string
    quantity?: number
    totalAmount?: string
    fullName?: string
    phone?: string
    img?: string
    status?: string
    createdAt?: Date
}

export interface IOrderCreate {
    productName?: string
    price?: string
    quantity?: number
    totalAmount?: string
    fullName?: string
    phone?: string
    img?: string
}

export interface IOrderStatusUpdate {
    status: string
}

// ---------- News ----------
export interface INews {
    id: number
    title?: string
    summary?: string
    content?: string
    img?: string
    isActive?: boolean
    createdAt?: Date
}

export interface INewsCreate {
    title?: string
    summary?: string
    content?: string
    img?: string
}

export interface INewsUpdate {
    title?: string
    summary?: string
    content?: string
    img?: string
    isActive?: boolean
}