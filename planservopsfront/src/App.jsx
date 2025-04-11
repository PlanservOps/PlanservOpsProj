import { useState, useEffect, Children, use } from "react"
import { Route, Routes } from "react-router-dom"

import LoginPage from "./pages/LoginPage"
import OverviewPage from "./pages/Home/OverviewPage"
import UsersPage from "./pages/Home/UsersPage"

import Sidebar from "./components/Sidebar"
import SettingsPage from "./pages/Home/SettingsPage"


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
        <Route path='/Settings' element={<SettingsPage/>}/>
      </Routes>
    </div>
  )
}

export default App
