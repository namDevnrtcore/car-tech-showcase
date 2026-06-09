// ============================================
// 📁 Controllers/BannersController.cs
// ============================================

using Microsoft.AspNetCore.Mvc;
using CarTechShowcase.Services;
using CarTechShowcase.DTOs;

namespace CarTechShowcase.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BannersController : ControllerBase
{
    private readonly BannerService _service;
    public BannersController(BannerService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var banners = await _service.GetAllAsync();
        return Ok(ApiResponse<object>.Ok(banners, "Lấy danh sách banner thành công", banners.Count));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BannerCreateDto dto)
    {
        var banner = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), ApiResponse<object>.Created(banner, "Tạo banner thành công"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] BannerUpdateDto dto)
    {
        var banner = await _service.UpdateAsync(id, dto);
        if (banner == null) return NotFound(ApiResponse<object>.NotFound("Banner không tồn tại"));
        return Ok(ApiResponse<object>.Ok(banner, "Cập nhật banner thành công"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var result = await _service.RemoveAsync(id);
        if (!result) return NotFound(ApiResponse<object>.NotFound("Banner không tồn tại"));
        return NoContent();
    }
}