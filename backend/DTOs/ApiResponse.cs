// ============================================
// 📁 DTOs/ApiResponse.cs - Standard API Response
// ============================================

namespace CarTechShowcase.DTOs;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public int? Count { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "Thành công", int? count = null)
        => new() { Success = true, Message = message, Data = data, Count = count };

    public static ApiResponse<T> Created(T data, string message = "Tạo thành công")
        => new() { Success = true, Message = message, Data = data };

    public static ApiResponse<T> NotFound(string message = "Không tìm thấy")
        => new() { Success = false, Message = message };

    public static ApiResponse<T> Error(string message = "Lỗi server")
        => new() { Success = false, Message = message };
}