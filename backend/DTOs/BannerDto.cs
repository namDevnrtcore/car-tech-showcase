// ============================================
// 📁 DTOs/BannerDto.cs - Banner DTOs
// ============================================

namespace CarTechShowcase.DTOs;

public record BannerCreateDto(string? Banner1, string? Banner2);
public record BannerUpdateDto(string? Banner1, string? Banner2);