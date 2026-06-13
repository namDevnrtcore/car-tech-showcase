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
    public async Task<IActionResult> Index(string? search, string? price, string? size)
    {
        ViewBag.SearchTerm  = search ?? "";
        ViewBag.PriceFilter = price ?? "all";
        ViewBag.SizeFilter  = size ?? "all";
        ViewBag.Products    = await _homeService.GetProductsAsync();
        ViewBag.HasResults  = true;
        return View("~/Views/Products/Index.cshtml");
    }

    [HttpGet("Detail/{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        ViewBag.Product        = await _productDataService.GetProductDetailAsync(id);
        ViewBag.RelatedProducts = await _productDataService.GetRelatedProductsAsync(id);
        return View("~/Views/Products/Detail.cshtml");
    }
}

[Route("News")]
public class NewsMvcController : Controller
{
    private readonly HomeService _homeService;
    public NewsMvcController(HomeService homeService) => _homeService = homeService;

    [HttpGet("")]
    public async Task<IActionResult> Index(string? category)
    {
        var articles = await _homeService.GetArticlesAsync();
        var cats     = _homeService.GetNewsCategories();

        if (!string.IsNullOrEmpty(category) && category != "all")
        {
            articles = articles
                .Where(a => (string)((dynamic)a).Category == category)
                .ToArray();
        }

        ViewBag.Categories       = cats;
        ViewBag.SelectedCategory = category ?? "all";
        ViewBag.FeaturedArticle  = articles.Length > 0 ? articles[0] : null;
        ViewBag.Articles         = articles;
        ViewBag.HasArticles      = articles.Length > 0;
        return View("~/Views/News/Index.cshtml");
    }
}

[Route("Contact")]
public class ContactMvcController : Controller
{
    [HttpGet("")]
    public IActionResult Index() => View("~/Views/Contact/Index.cshtml");

    [HttpPost("Send")]
    [ValidateAntiForgeryToken]
    public IActionResult Send(string name, string phone, string? email, string message)
    {
        TempData["Success"] = "Cảm ơn bạn đã liên hệ! Chúng tôi sẽ phản hồi trong thời gian sớm nhất.";
        return RedirectToAction("Index");
    }
}
