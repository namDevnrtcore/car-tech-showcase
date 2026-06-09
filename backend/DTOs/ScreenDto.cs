// ============================================
// 📁 DTOs/ScreenDto.cs - Screen DTOs
// ============================================

namespace CarTechShowcase.DTOs;

public record ScreenCreateDto(string ScreenName, string? Location, string? Note, int? TypeId);
public record ScreenUpdateDto(string? ScreenName, string? Location, string? Note, int? TypeId, bool? IsActive);