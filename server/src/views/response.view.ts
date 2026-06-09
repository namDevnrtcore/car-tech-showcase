// ============================================
// 📁 views/response.view.ts - Standard Response
// ============================================

export interface ApiResponse<T = unknown> {
    success: boolean
    message: string
    data?: T
    count?: number
}

class ResponseView {

    /** Trả về response thành công */
    success<T>(data: T, message = "Thành công", count?: number): ApiResponse<T> {
        const response: ApiResponse<T> = {
            success: true,
            message,
            data,
        }
        if (count !== undefined) {
            response.count = count
        }
        return response
    }

    /** Trả về response tạo mới thành công */
    created<T>(data: T, message = "Tạo thành công"): ApiResponse<T> {
        return { success: true, message, data }
    }

    /** Trả về response không tìm thấy */
    notFound(message = "Không tìm thấy"): ApiResponse {
        return { success: false, message }
    }

    /** Trả về response lỗi server */
    error(message = "Lỗi server", error?: string): ApiResponse {
        return { success: false, message: error ? `${message}: ${error}` : message }
    }
}

export default new ResponseView()