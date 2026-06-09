// ============================================
// 📁 DTOs/NewsDto.cs - News DTOs
// ============================================

namespace CarTechShowcase.DTOs;

public record NewsCreateDto(string? Title, string? Summary, string? Content, string? Img);
public record NewsUpdateDto(string? Title, string? Summary, string? Content, string? Img, bool? IsActive);