import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
import { BrowserRouter } from 'react-router-dom'
import { ThemeProvider } from './context/ThemeContext.jsx'

console.log("🔧 VITE_API_URL em produção:", import.meta.env.VITE_API_URL);


createRoot(document.getElementById('root')).render(
  <StrictMode>
    <BrowserRouter>
    <ThemeProvider>
      <App />
    </ThemeProvider>
    </BrowserRouter>
  </StrictMode>
)
