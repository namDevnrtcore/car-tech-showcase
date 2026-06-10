// ============================================
// 📁 Controllers/Mvc/PagesController.cs - MVC Pages Controller
// Handles Products, News, Contact views
// ============================================

using Microsoft.AspNetCore.Mvc;
using CarTechShowcase.Services;

namespace CarTechShowcase.Controllers.Mvc;

[Route("Products")]
public class ProductsMvcController : Controller
{
    private readonly HomeService _homeService;
    private readonly ProductDataService _productDataService;
    public ProductsMvcController(HomeService homeService, ProductDataService productDataService)
    {
        _homeService = homeService;
        _productDataService = productDataService;
    }

    [HttpGet("")]
    public IActionResult Index(string? search, string? price, string? size)
    {
        ViewBag.SearchTerm = search ?? "";
        ViewBag.PriceFilter = price ?? "all";
        ViewBag.SizeFilter = size ?? "all";
        ViewBag.Products = _homeService.GetProducts();
        ViewBag.HasResults = true;
        return View("~/Views/Products/Index.cshtml");
    }

    [HttpGet("Detail/{id}")]
    public IActionResult Detail(int id)
    {
        ViewBag.Product = _productDataService.GetProductDetail(id);
        ViewBag.RelatedProducts = _productDataService.GetRelatedProducts();
        ViewBag.FormatPriceFunc = true;
        return View("~/Views/Products/Detail.cshtml");
    }
}

[Route("News")]
public class NewsMvcController : Controller
{
    private readonly HomeService _homeService;
    public NewsMvcController(HomeService homeService) => _homeService = homeService;

    [HttpGet("")]
    public IActionResult Index(string? category)
    {
        var articles = (object[])_homeService.GetArticles();
        var cats = (object[])_homeService.GetNewsCategories();

        // Filter articles by category if specified
        if (!string.IsNullOrEmpty(category) && category != "all")
        {
            var filtered = new List<object>();
            foreach (dynamic a in articles)
            {
                if ((string)a.Category == category) filtered.Add(a);
            }
            articles = filtered.ToArray();
        }

        ViewBag.Categories = cats;
        ViewBag.SelectedCategory = category ?? "all";
        ViewBag.FeaturedArticle = articles.Length > 0 ? articles[0] : null;
        ViewBag.Articles = articles;
        ViewBag.HasArticles = articles.Length > 0;
        return View("~/Views/News/Index.cshtml");
    }
}

[Route("Contact")]
public class ContactMvcController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("~/Views/Contact/Index.cshtml");
    }

    [HttpPost("Send")]
    [ValidateAntiForgeryToken]
    public IActionResult Send(string name, string phone, string? email, string message)
    {
        // TODO: Save to database or send email
        TempData["Success"] = "Cảm ơn bạn đã liên hệ! Chúng tôi sẽ phản hồi trong thời gian sớm nhất.";
        return RedirectToAction("Index");
    }
}