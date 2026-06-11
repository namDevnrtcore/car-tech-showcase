// ============================================
// 📁 DTOs/ProductDto.cs - Product DTOs
// ============================================

namespace CarTechShowcase.DTOs;

public record ProductCreateDto(string ProductName, double? Price, string? Category, string? Description, string? Img, string? Spec);
public record ProductUpdateDto(string? ProductName, double? Price, string? Category, string? Description, string? Img, string? Spec, bool? IsActive);
