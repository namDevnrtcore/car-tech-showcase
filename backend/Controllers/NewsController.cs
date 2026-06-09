using Microsoft.AspNetCore.Mvc;
using CarTechShowcase.Services;
using CarTechShowcase.DTOs;

namespace CarTechShowcase.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly NewsService _service;
    public NewsController(NewsService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var news = await _service.GetAllAsync();
        return Ok(ApiResponse<object>.Ok(news, "OK", news.Count));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var news = await _service.GetByIdAsync(id);
        if (news == null) return NotFound(ApiResponse<object>.NotFound("Not found"));
        return Ok(ApiResponse<object>.Ok(news, "OK"));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewsCreateDto dto)
    {
        var news = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = news.Id }, ApiResponse<object>.Created(news, "Created"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] NewsUpdateDto dto)
    {
        var news = await _service.UpdateAsync(id, dto);
        if (news == null) return NotFound(ApiResponse<object>.NotFound("Not found"));
        return Ok(ApiResponse<object>.Ok(news, "Updated"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var result = await _service.RemoveAsync(id);
        if (!result) return NotFound(ApiResponse<object>.NotFound("Not found"));
        return NoContent();
    }
}