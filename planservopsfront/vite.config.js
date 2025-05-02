import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  base: './', 
  plugins: [react()],
  build: {
    minify: 'esbuild',
    sourcemap: false,
    outDir: 'dist',
    chunkSizeWarningLimit: 1000,
  },
  optimizeDeps: {
    include: ['react', 'react-dom', 'react-router-dom'],
  },
  server: {
    proxy: {
      '/api': {
        target: 'https://planservopsprojapi-production.up.railway.app',
        changeOrigin: true,
        secure: false,
      },
    },
  }
})
