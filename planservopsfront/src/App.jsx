import { useState, useEffect, Children, use } from "react"
import { Route, Routes } from "react-router-dom"

import LoginPage from "./pages/LoginPage"
import OverviewPage from "./pages/Home/OverviewPage"
import UsersPage from "./pages/Home/UsersPage"

import Sidebar from "./components/Sidebar"
import SettingsPage from "./pages/Home/SettingsPage"
import OcorrenciasPage from "./pages/Home/OcorrenciasPage"
import ReclamacoesPage from "./pages/Home/ReclamacoesPage"
import ChecklistPage from "./pages/Home/ChecklistPage"
import AvaliacoesPage from "./pages/Home/AvaliacoesPage"
import EficienciaPage from "./pages/Home/EficienciaPage"


function App() {
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
        <Route path='/Home' element={<OverviewPage/>}/>
        <Route path='/Users' element={<UsersPage/>}/>
        <Route path='/Ocorrencias' element={<OcorrenciasPage/>}/> 
        <Route path='/Reclamacoes' element={<ReclamacoesPage/>}/> 
        <Route path='/Checklist' element={<ChecklistPage/>}/>
        <Route path='/Avaliacoes' element={<AvaliacoesPage/>}/>
        <Route path='/Eficiência' element={<EficienciaPage/>}/>
        <Route path='/Settings' element={<SettingsPage/>}/>
      </Routes>
    </div>
  )
}

export default App
