// ============================================
// 📁 DTOs/OrderDto.cs - Order DTOs
// ============================================

namespace CarTechShowcase.DTOs;

public record OrderCreateDto(string? ProductName, string? Price, int? Quantity, string? TotalAmount, string? FullName, string? Phone, string? Img);
public record OrderStatusUpdateDto(string Status);