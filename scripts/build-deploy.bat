@echo off
REM ============================================
REM 📁 build-deploy.bat - Build & Deploy Script (Windows)
REM ============================================

echo 🚀 Starting build & deploy for vinmap.vn...

REM ---------- Step 1: Build Client (React/Vite) ----------
echo.
echo 📦 Step 1: Building client (React)...
cd client
call npm install
call npm run build
if %ERRORLEVEL% NEQ 0 (
    echo ❌ Client build failed!
    exit /b 1
)
echo ✅ Client built successfully! Output: client/dist/ → backend/wwwroot/

REM ---------- Step 2: Build .NET Backend ----------
echo.
echo 🔧 Step 2: Building .NET backend...
cd ..\backend
call dotnet publish -c Release -o .\publish
if %ERRORLEVEL% NEQ 0 (
    echo ❌ Backend build failed!
    exit /b 1
)
echo ✅ Backend built successfully!

REM ---------- Step 3: Summary ----------
echo.
echo ============================================
echo ✅ BUILD COMPLETE!
echo ============================================
echo.
echo 📂 Backend output: backend\publish\
echo 📂 React build:    backend\wwwroot\
echo.
echo 🌐 Deploy to vinmap.vn:
echo    - Copy backend\publish\* to httpdocs\ on Plesk
echo    - OR use Fastify server (Node.js)
echo ============================================

cd ..