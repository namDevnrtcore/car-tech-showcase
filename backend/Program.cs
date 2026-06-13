// ============================================
// 📁 Program.cs - Application Entry Point (.NET Core MVC)
// ============================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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

// ---------- Session (Admin auth) ----------
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = ".VinMap.Admin";
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

    bool needsReset = false;
    try
    {
        var b = db.Banners.FirstOrDefault();
        // Reset nếu chưa có data, URL cũ (https://), hoặc chưa có danh mục "Camera Nghị Định 10" (mới)
        needsReset = b == null
            || (b.Banner1 != null && !b.Banner1.StartsWith("/images/"))
            || !db.Products.Any(p => p.Category == "Camera Nghị Định 10");
    }
    catch { needsReset = true; }

    if (needsReset)
    {
        // Drop FK constraints trước (tránh lỗi referenced table)
        db.Database.ExecuteSqlRaw(@"
            DECLARE @dropFKs NVARCHAR(MAX) = ''
            SELECT @dropFKs += 'ALTER TABLE [' + OBJECT_NAME(fk.parent_object_id) + '] DROP CONSTRAINT [' + fk.name + '];'
            FROM sys.foreign_keys fk
            WHERE OBJECT_NAME(fk.referenced_object_id) IN ('orders','news','product','carScreen','banner')
               OR OBJECT_NAME(fk.parent_object_id) IN ('orders','news','product','carScreen','banner')
            IF @dropFKs != '' EXEC(@dropFKs)
        ");
        // Drop từng bảng (không cần quyền ALTER DATABASE)
        db.Database.ExecuteSqlRaw("IF OBJECT_ID('orders', 'U') IS NOT NULL DROP TABLE [orders]");
        db.Database.ExecuteSqlRaw("IF OBJECT_ID('news', 'U') IS NOT NULL DROP TABLE [news]");
        db.Database.ExecuteSqlRaw("IF OBJECT_ID('product', 'U') IS NOT NULL DROP TABLE [product]");
        db.Database.ExecuteSqlRaw("IF OBJECT_ID('carScreen', 'U') IS NOT NULL DROP TABLE [carScreen]");
        db.Database.ExecuteSqlRaw("IF OBJECT_ID('banner', 'U') IS NOT NULL DROP TABLE [banner]");
        // Tạo lại các bảng (không tạo database, chỉ tạo tables)
        var creator = db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        creator!.CreateTables();
        db.ChangeTracker.Clear(); // Xóa cache entity cũ trước khi seed
        SeedData.Initialize(db);
        Console.WriteLine("✅ Database reset và seed hoàn tất!");
    }
    else
    {
        Console.WriteLine("✅ Database đã sẵn sàng, load dữ liệu từ DB.");
    }
}

// ---------- Middleware Pipeline ----------

app.UseCors();
app.UseSession();
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
