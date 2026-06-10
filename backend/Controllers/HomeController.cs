// ============================================
// 📁 Controllers/HomeController.cs - MVC Home Controller
// ============================================

using Microsoft.AspNetCore.Mvc;
using CarTechShowcase.Services;

namespace CarTechShowcase.Controllers;

public class HomeController : Controller
{
    private readonly HomeService _homeService;

    public HomeController(HomeService homeService)
    {
        _homeService = homeService;
    }

    public IActionResult Index()
    {
        ViewBag.HeroImage = _homeService.GetHeroImage();
        ViewBag.Features = _homeService.GetFeatures();
        ViewBag.Categories = _homeService.GetCategories();
        ViewBag.CompatibleCars = _homeService.GetCompatibleCars();
        ViewBag.HomeNews = _homeService.GetHomeNews();
        return View();
    }
}