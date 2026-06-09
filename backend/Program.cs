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
builder.Services.AddScoped<BannerService>();
builder.Services.AddScoped<ScreenService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<NewsService>();

// ---------- Controllers + JSON ----------
builder.Services.AddControllers()
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

// ---------- Middleware Pipeline ----------

app.UseCors();
app.UseStaticFiles();
app.MapControllers();

// ---------- SPA Fallback (React routing) ----------
app.MapFallbackToFile("index.html");

app.Run();