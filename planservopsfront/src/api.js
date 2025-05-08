import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL;

console.log("🌐 API baseURL configurada:", baseURL); // útil para debug

// Cria uma instância do axios com a base URL da API
const api = axios.create({
  baseURL,
});

export default api;