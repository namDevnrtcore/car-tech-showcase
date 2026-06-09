using Microsoft.AspNetCore.Mvc;
using CarTechShowcase.Services;
using CarTechShowcase.DTOs;

namespace CarTechShowcase.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _service;
    public OrdersController(OrderService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _service.GetAllAsync();
        return Ok(ApiResponse<object>.Ok(orders, "OK", orders.Count));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _service.GetByIdAsync(id);
        if (order == null) return NotFound(ApiResponse<object>.NotFound("Not found"));
        return Ok(ApiResponse<object>.Ok(order, "OK"));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderCreateDto dto)
    {
        var order = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = order.Id }, ApiResponse<object>.Created(order, "Created"));
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] OrderStatusUpdateDto dto)
    {
        var order = await _service.UpdateStatusAsync(id, dto.Status);
        if (order == null) return NotFound(ApiResponse<object>.NotFound("Not found"));
        return Ok(ApiResponse<object>.Ok(order, "Updated"));
    }
}