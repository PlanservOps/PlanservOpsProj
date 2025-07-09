import { useState, useEffect, Children, use } from "react";
import { Route, Routes, useLocation } from "react-router-dom";
import { PrivateRoute } from "./components/PrivateRoute";

import LoginPage from "./pages/LoginPage";
import OverviewPage from "./pages/Home/OverviewPage";
import UsersPage from "./pages/Home/UsersPage";

import Sidebar from "./components/Sidebar";
import SettingsPage from "./pages/Home/SettingsPage";
import OcorrenciasPage from "./pages/Home/OcorrenciasPage";
import ReclamacoesPage from "./pages/Home/ReclamacoesPage";
import ChecklistPage from "./pages/Home/ChecklistPage";
import AvaliacoesFormPage from "./pages/Home/AvaliacoesFormPage";
import HistoryFormPage from "./pages/Home/HistoryFormPage";

function App() {
  const location = useLocation();
  const isLoginPage = location.pathname === "/";

  return (
    <div className="flex h-screen bg-white text-gray-900 dark:bg-gray-900 dark:text-gray-100 transition-colors">
      {/* BG */}
      <div className="fixed inset-0 z-[-1]">
        <div className="absolute inset-0 bg-gradient-to-br from-white via-gray-100 to-gray-200 dark:from-gray-900 dark:via-gray-800 dark:to-gray-900 opacity-100 dark:opacity-100" />
        {!isLoginPage && <div className="absolute inset-0 backdrop-blur-sm" />}
      </div>

      {!isLoginPage && <Sidebar />}

      <Routes>
        <Route path="/*" element={<LoginPage />} />
        <Route
          path="/Home"
          element={
            <PrivateRoute roleRequired={["Diretoria"]}>
              <OverviewPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/Users"
          element={
            <PrivateRoute roleRequired={["Diretoria", "AdministradorInterno"]}>
              <UsersPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/Ocorrencias"
          element={
            <PrivateRoute roleRequired={["Diretoria", "GerenteOperacional"]}>
              <OcorrenciasPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/Reclamacoes"
          element={
            <PrivateRoute roleRequired={["Diretoria", "GerenteOperacional"]}>
              <ReclamacoesPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/Checklist"
          element={
            <PrivateRoute roleRequired={["Diretoria", "Fiscal"]}>
              <ChecklistPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/AvaliacoesForm"
          element={
            <PrivateRoute roleRequired={["Diretoria", "GerenteOperacional"]}>
              <AvaliacoesFormPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/HistoryForm"
          element={
            <PrivateRoute roleRequired={["Diretoria", "GerenteOperacional"]}>
              <HistoryFormPage />
            </PrivateRoute>
          }
        />
        {/* <Route path='/Eficiencia' element={<PrivateRoute roleRequired={["Diretoria", "Fiscal"]}><EficienciaPage/></PrivateRoute>}/> */}
        <Route
          path="/Settings"
          element={
            <PrivateRoute roleRequired={["Diretoria", "AdministradorInterno"]}>
              <SettingsPage />
            </PrivateRoute>
          }
        />
      </Routes>
    </div>
  );
}

export default App;
