import React from 'react'
import InfoBanner from '../../components/common/InfoBanner'

const SettingsPage = () => {
  return (
    <div className="p-6">
        <InfoBanner message="Esta página está em desenvolvimento. Algumas mudanças ainda irão ocorrer." />
        <h1 className="text-2xl font-bold">Bem-vindo à Página de Configurações</h1>
        {/* Conteúdo da página */}
    </div>
)
}

export default SettingsPage