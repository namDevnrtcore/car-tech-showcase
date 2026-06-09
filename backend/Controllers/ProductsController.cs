using Microsoft.AspNetCore.Mvc;
using CarTechShowcase.Services;
using CarTechShowcase.DTOs;

namespace CarTechShowcase.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;
    public ProductsController(ProductService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAllAsync();
        return Ok(ApiResponse<object>.Ok(products, "OK", products.Count));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product == null) return NotFound(ApiResponse<object>.NotFound("Not found"));
        return Ok(ApiResponse<object>.Ok(product, "OK"));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
    {
        var product = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, ApiResponse<object>.Created(product, "Created"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)
    {
        var product = await _service.UpdateAsync(id, dto);
        if (product == null) return NotFound(ApiResponse<object>.NotFound("Not found"));
        return Ok(ApiResponse<object>.Ok(product, "Updated"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var result = await _service.RemoveAsync(id);
        if (!result) return NotFound(ApiResponse<object>.NotFound("Not found"));
        return NoContent();
    }
}