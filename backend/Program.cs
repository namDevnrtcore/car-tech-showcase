// ============================================
// 📁 Program.cs - Application Entry Point (.NET Core MVC)
// ============================================

using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Data;
using CarTechShowcase.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------- Database ----------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---------- Services (Dependency Injection) ----------
builder.Services.AddScoped<HomeService>();
builder.Services.AddScoped<ProductDataService>();
builder.Services.AddScoped<BannerService>();
builder.Services.AddScoped<ScreenService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<NewsService>();

// ---------- Controllers (API + MVC) ----------
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });

// ---------- CORS (cho React dev server) ----------
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

// ---------- Seed Data ----------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // Tạo database/tables nếu chưa có
    SeedData.Initialize(db);
}

// ---------- Middleware Pipeline ----------

app.UseCors();
app.UseStaticFiles();   // Serve React build from wwwroot/

// ---------- API Routes ----------
app.MapControllers();

// ---------- MVC Routes ----------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ---------- SPA Fallback (only if client/dist exists) ----------
if (Directory.Exists(Path.Combine(app.Environment.WebRootPath)))
{
    var indexPath = Path.Combine(app.Environment.WebRootPath, "index.html");
    if (File.Exists(indexPath))
    {
        app.MapFallbackToFile("index.html");
    }
}

app.Run();
