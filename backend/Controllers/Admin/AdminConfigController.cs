using Microsoft.AspNetCore.Mvc;
using CarTechShowcase.Models;
using CarTechShowcase.Services;

namespace CarTechShowcase.Controllers.Admin;

[Route("Admin/Config")]
public class AdminConfigController : AdminBaseController
{
    private readonly SiteConfigService _configService;
    public AdminConfigController(SiteConfigService configService) => _configService = configService;

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Cấu hình website";
        var config = await _configService.GetAsync();
        return View("~/Views/Admin/Config/Index.cshtml", config);
    }

    [HttpPost("")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(SiteConfig model)
    {
        ModelState.Remove("Id");
        await _configService.SaveAsync(model);
        TempData["Success"] = "Đã lưu cấu hình thành công!";
        return Redirect("/Admin/Config");
    }
}
