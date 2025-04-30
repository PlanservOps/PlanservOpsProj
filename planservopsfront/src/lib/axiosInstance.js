import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL, 
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Interceptors
axiosInstance.interceptors.request.use(
  (config) => {
    console.log('Request:', config);
    return config;
  },
  (error) => {
    console.error('Erro de request:', error);
    return Promise.reject(error);
  }
);

axiosInstance.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response) {
      const { status } = error.response;
      switch (status) {
        case 400:
          console.error('Erro 400: Bad Request');
          break;
        case 401:
          console.error('Erro 401: Unauthorized');
          break;
        case 403:
          console.error('Erro 403: Forbidden');
          break;
        case 404:
          console.error('Erro 404: Not Found');
          break;
        case 500:
          console.error('Erro 500: Internal Server Error');
          break;
        default:
          console.error(`Erro ${status}: ${error.message}`);
      }
    } else {
      console.error('Erro sem resposta:', error);
    }
    return Promise.reject(error);
  }
);

export default axiosInstance;
