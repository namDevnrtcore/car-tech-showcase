using Microsoft.AspNetCore.Mvc;
using CarTechShowcase.Services;

namespace CarTechShowcase.Controllers;

public class HomeController : Controller
{
    private readonly HomeService _homeService;
    public HomeController(HomeService homeService) => _homeService = homeService;

    public async Task<IActionResult> Index()
    {
        ViewBag.HeroImage      = _homeService.GetHeroImage();
        ViewBag.Features       = _homeService.GetFeatures();
        ViewBag.CompatibleCars = _homeService.GetCompatibleCars();
        ViewBag.Categories     = await _homeService.GetCategoriesAsync();
        ViewBag.HomeNews       = await _homeService.GetHomeNewsAsync();
        return View();
    }
}
