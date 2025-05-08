import { defineConfig, loadEnv } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig(({ mode }) => {
  // Carrega as variáveis de ambiente do arquivo correspondente (ex: .env.production)
  const env = loadEnv(mode, process.cwd(), '');

  return {
    define: {
      'import.meta.env.VITE_API_URL': JSON.stringify(env.VITE_API_URL),
    },
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
    // server: {
    //   proxy: {
    //     '/api': {
    //       //target: 'https://planservopsprojapi-production.up.railway.app',
    //       target: env.VITE_API_URL,
    //       changeOrigin: true,
    //       secure: false,
    //     },
    //   },
    // },
  };
});
