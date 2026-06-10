import { defineConfig } from "vite";
import react from "@vitejs/plugin-react-swc";
import path from "path";
import { componentTagger } from "lovable-tagger";

export default defineConfig(({ mode }) => ({
  // base: "/" ensures all asset paths are relative to domain root
  // Works for both vinmap.vn and any subdirectory
  base: "/",
  server: {
    host: "::",
    port: 8080,
    proxy: {
      '/api': {
        target: 'http://localhost:5193',
        changeOrigin: true,
      }
    }
  },
  build: {
    // Output goes to backend/wwwroot so .NET can serve it
    outDir: "../backend/wwwroot",
    emptyOutDir: true,
  },
  plugins: [react(), mode === "development" && componentTagger()].filter(Boolean),
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },
}));
