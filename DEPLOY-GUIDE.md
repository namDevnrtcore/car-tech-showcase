# 🚀 Hướng Dẫn Triển Khai - vinmap.vn

## Tổng Quan Kiến Trúc

```
vinmap.vn (httpdocs/)
├── index.html          ← React SPA (build từ Vite)
├── assets/             ← CSS, JS, images (React build)
├── api/                ← .NET API Controllers (hoặc Fastify)
└── ...                 
```

**Cả Frontend (React) và Backend (API) cùng chạy trên domain `vinmap.vn`**

---

## Chọn Server Chạy API

Bạn có **2 lựa chọn** cho backend:

### Lựa Chọn 1: .NET Backend (Recommended)
- Dùng `backend/` folder
- `dotnet publish -c Release -o ./publish`
- Copy toàn bộ `backend/publish/` vào `httpdocs/`
- React build đã nằm trong `backend/wwwroot/`

### Lựa Chọn 2: Fastify Server (Node.js)
- Dùng `server/` folder
- Build client trước: `cd client && npm run build`
- Copy `client/dist/` và `server/` lên server
- Chạy: `node server/dist/app.js`

---

## Bước Build (Local Machine)

### Cách 1: Dùng Script

**Windows:**
```cmd
scripts\build-deploy.bat
```

**Linux/Mac:**
```bash
bash scripts/build-deploy.sh
```

### Cách 2: Build Thủ Công

```bash
# 1. Build React Client
cd client
npm install
npm run build
# → Output: backend/wwwroot/

# 2. Build .NET Backend (nếu dùng .NET)
cd ../backend
dotnet publish -c Release -o ./publish
# → Output: backend/publish/ (bao gồm wwwroot/ đã có React build)
```

---

## Deploy Lên Plesk (vinmap.vn)

### Cách 1: Dùng .NET Backend (Khuyên dùng)

1. **Upload files**: Upload toàn bộ nội dung `backend/publish/` vào thư mục `httpdocs/` trên Plesk
   
   Cấu trúc `httpdocs/` sau khi upload:
   ```
   httpdocs/
   ├── wwwroot/          ← React build (index.html, assets/)
   │   ├── index.html
   │   └── assets/
   ├── appsettings.json  ← Config .NET
   ├── web.config        ← IIS config (tự động có trong publish)
   └── *.dll             ← .NET assemblies
   ```

   ⚠️ **Lưu ý quan trọng**: Với .NET trên Windows/Plesk, cấu trúc có thể hơi khác. 
   Plesk thường dùng IIS, nên cần cấu hình lại.

### Cách 2: Dùng Fastify Server (Node.js) - Đơn Giản Hơn

1. **Upload files** lên VPS:
   ```
   /home/vinmap.vn/
   ├── client/dist/      ← React build (output từ vite build)
   ├── server/           ← Fastify server
   │   ├── dist/         ← Compiled JS (npm run build)
   │   ├── .env          ← Config
   │   └── package.json
   └── start.sh          ← Script khởi động
   ```

2. **Cài đặt dependencies** trên server:
   ```bash
   cd /home/vinmap.vn/server
   npm install --production
   cd ../client
   npm install
   npm run build
   ```

3. **Chạy server**:
   ```bash
   cd /home/vinmap.vn/server
   PORT=3001 node dist/app.js
   ```

4. **Cấu hình Nginx/Plesk** để forward traffic:
   ```nginx
   server {
       listen 80;
       server_name vinmap.vn www.vinmap.vn;
       
       # Proxy Node.js
       location / {
           proxy_pass http://127.0.0.1:3001;
           proxy_http_version 1.1;
           proxy_set_header Upgrade $http_upgrade;
           proxy_set_header Connection 'upgrade';
           proxy_set_header Host $host;
           proxy_set_header X-Real-IP $remote_addr;
           proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
           proxy_cache_bypass $http_upgrade;
       }
   }
   ```

5. **Dùng PM2** để manage process:
   ```bash
   npm install -g pm2
   pm2 start dist/app.js --name vinmap
   pm2 save
   pm2 startup
   ```

---

## Cấu Hình DNS & Subdomain

```
vinmap.vn          →指向 httpdocs/ (React + API)
api.vinmap.vn      →指向 api/ (nếu tách API riêng)
admin.vinmap.vn    →指向 admin/ (React Admin Panel)
```

---

## Cấu Hình CORS (Nếu Cần)

Nếu FE và API cùng domain, **không cần CORS**. Nhưng nếu tách subdomain:

### Fastify Server (`server/src/app.ts`):
```typescript
app.register(cors, {
    origin: ["https://vinmap.vn", "https://www.vinmap.vn"],
    credentials: true
})
```

### .NET Backend (`backend/Program.cs`):
```csharp
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://vinmap.vn", "https://www.vinmap.vn")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
```

---

## Kiểm Tra Sau Deploy

1. **Truy cập** `https://vinmap.vn` → Hiển thị React app ✅
2. **API test** `https://vinmap.vn/api/products` → Trả về JSON ✅
3. **SPA Routing** → Vào `https://vinmap.vn/products` vẫn hoạt động ✅
4. **Health check** `https://vinmap.vn/health` (Fastify) ✅

---

## Troubleshooting

| Vấn đề | Giải pháp |
|--------|-----------|
| White screen | Kiểm tra `base: "/"` trong `vite.config.ts` |
| 404 khi refresh trang | Đảm bảo SPA fallback đã cấu hình đúng |
| API 404 | Kiểm tra route prefix `/api/` |
| CORS error | Đảm bảo CORS config đúng origin |
| Static files 404 | Kiểm tra đường dẫn `wwwroot/` hoặc `client/dist/` |

---

## Files Đã Chỉnh Sửa

| File | Thay Đổi |
|------|----------|
| `client/vite.config.ts` | Thêm `base: "/"`, `build.outDir` |
| `backend/Program.cs` | Thêm comments, giữ nguyên logic |
| `server/src/app.ts` | Thêm `@fastify/static`, SPA fallback |
| `server/package.json` | Thêm `@fastify/static` dependency |
| `package.json` | Thêm scripts: dev, build, deploy |
| `scripts/build-deploy.sh` | Script build Linux |
| `scripts/build-deploy.bat` | Script build Windows |