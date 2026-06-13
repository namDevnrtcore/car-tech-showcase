using Microsoft.AspNetCore.Mvc;

namespace CarTechShowcase.Controllers.Admin;

[Route("Admin")]
public class AdminController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("AdminAuth") == "true")
            return Redirect("/Admin/Dashboard");
        return Redirect("/Admin/Login");
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        if (HttpContext.Session.GetString("AdminAuth") == "true")
            return Redirect("/Admin/Dashboard");
        ViewData["Title"] = "Đăng nhập Admin";
        return View("~/Views/Admin/Login.cshtml");
    }

    [HttpPost("Login")]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string username, string password)
    {
        if (username == "admin" && password == "Admin@123")
        {
            HttpContext.Session.SetString("AdminAuth", "true");
            HttpContext.Session.SetString("AdminUser", username);
            return Redirect("/Admin/Dashboard");
        }
        TempData["Error"] = "Sai tên đăng nhập hoặc mật khẩu!";
        ViewData["Title"] = "Đăng nhập Admin";
        return View("~/Views/Admin/Login.cshtml");
    }

    [HttpGet("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/Admin/Login");
    }
}
