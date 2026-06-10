#!/bin/bash
# ============================================
# 📁 build-deploy.sh - Build & Deploy Script
# Chạy script này trên server hoặc local trước khi deploy
# ============================================

set -e

echo "🚀 Starting build & deploy for vinmap.vn..."

# ---------- Step 1: Build Client (React/Vite) ----------
echo ""
echo "📦 Step 1: Building client (React)..."
cd client
npm install
npm run build
echo "✅ Client built successfully! Output: client/dist/ → backend/wwwroot/"

# ---------- Step 2: Copy to backend/wwwroot ----------
echo ""
echo "📁 Step 2: Copying build to backend/wwwroot..."
# Vite config đã set outDir="../backend/wwwroot", nên file đã ở đúng chỗ
# Nếu dùng Fastify server, copy sang client/dist/
echo "✅ Files ready!"

# ---------- Step 3: Build .NET Backend ----------
echo ""
echo "🔧 Step 3: Building .NET backend..."
cd ../backend
dotnet publish -c Release -o ./publish
echo "✅ Backend built successfully!"

# ---------- Step 4: Summary ----------
echo ""
echo "============================================"
echo "✅ BUILD COMPLETE!"
echo "============================================"
echo ""
echo "📂 Backend output: backend/publish/"
echo "📂 React build:    backend/wwwroot/"
echo ""
echo "🌐 Deploy to vinmap.vn:"
echo "   - Copy backend/publish/* to httpdocs/ on Plesk"
echo "   - OR deploy to api.vinmap.vn for backend only"
echo ""
echo "🔧 OR use Fastify server (Node.js):"
echo "   - Copy client/dist/ and server/ to the server"
echo "   - Run: node server/dist/app.js"
echo "============================================"