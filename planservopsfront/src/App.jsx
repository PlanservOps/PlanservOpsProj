import { useState, useEffect, Children, use } from "react"
import { Route, Routes, useLocation } from "react-router-dom"
import { PrivateRoute } from "./components/PrivateRoute"

import LoginPage from "./pages/LoginPage"
import OverviewPage from "./pages/Home/OverviewPage"
import UsersPage from "./pages/Home/UsersPage"

import Sidebar from "./components/Sidebar"
import SettingsPage from "./pages/Home/SettingsPage"
import OcorrenciasPage from "./pages/Home/OcorrenciasPage"
import ReclamacoesPage from "./pages/Home/ReclamacoesPage"
import ChecklistPage from "./pages/Home/ChecklistPage"
import AvaliacoesFormPage from "./pages/Home/AvaliacoesFormPage"
import EficienciaPage from "./pages/Home/EficienciaPage"


function App() {
  const location = useLocation();
  const isLoginPage = location.pathname === '/';

  return (
    <div className='flex h-screen bg-gray-900 text-gray-100 '>

      {/* BG */}
      <div className='fixed inset-0 z-[-1]'>
        <div className='absolute inset-0 bg-gradient-to-br from-gray-900 via-gray-800 to-gray-900 opacity-0'/>
        {!isLoginPage && <div className='absolute inset-0 backdrop-blur-sm'/>}

      </div>

      {!isLoginPage && <Sidebar/>}

      <Routes>
        <Route path='/*' element={<LoginPage/>}/>
        <Route path='/Home' element={<PrivateRoute roleRequired={["Diretoria"]}><OverviewPage/></PrivateRoute>}/>
        <Route path='/Users' element={<PrivateRoute roleRequired={["Diretoria", "AdministradorInterno"]}><UsersPage/></PrivateRoute>}/>
        <Route path='/Ocorrencias' element={<PrivateRoute roleRequired={["Diretoria", "GerenteOperacional"]}><OcorrenciasPage/></PrivateRoute>}/> 
        <Route path='/Reclamacoes' element={<PrivateRoute roleRequired={["Diretoria", "GerenteOperacional"]}><ReclamacoesPage/></PrivateRoute>}/> 
        <Route path='/Checklist' element={<PrivateRoute roleRequired={["Diretoria", "Fiscal"]}><ChecklistPage/></PrivateRoute>}/>
        <Route path='/AvaliacoesForm' element={<PrivateRoute roleRequired={["Diretoria", "Fiscal"]}><AvaliacoesFormPage/></PrivateRoute>}/>
        <Route path='/Eficiência' element={<PrivateRoute roleRequired={["Diretoria"]}><EficienciaPage/></PrivateRoute>}/>
        <Route path='/Settings' element={<PrivateRoute roleRequired={["Diretoria"]}><SettingsPage/></PrivateRoute>}/>
      </Routes>
    </div>
  )
}

export default App
