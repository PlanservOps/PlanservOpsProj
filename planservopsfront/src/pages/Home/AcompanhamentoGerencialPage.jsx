import React, { useState } from "react";
import Header from "../../components/common/Header";
import HistoryTable from "../../components/tables/HistoryTable";
import AcompanhamentoGerencial from "../../components/acompanhamentoGerencialComponent/AcompanhamentoGerencial";

const FormularioOperacionalPage = () => {
  const [showForm, setShowForm] = useState(false);
  const [formKey, setFormKey] = useState(0);

  const openForm = () => {
    setFormKey(Date.now()); // força remount do formulário
    setShowForm(true);
  };

  const closeForm = () => {
    setShowForm(false);
  };

  return (
    <div className="flex-1 overflow-auto relative z-10">
      <Header title="Acompanhamento Gerencial" />
      <HistoryTable />
      <div className="mt-4">
        <button
          type="button"
          className="bg-orange-500 text-white px-4 py-2 rounded hover:bg-orange-600"
          onClick={openForm}
        >
          Acompanhamento Gerencial
        </button>
      </div>

      {showForm && (
        // Modal overlay
        <div
          className="fixed inset-0 z-50 flex items-center justify-center bg-opacity-50 p-4"
          role="dialog"
          aria-modal="true"
        >
          <div className="bg-white dark:bg-gray-800 rounded-lg shadow-lg w-full max-w-3xl p-4 relative">
            <button
              type="button"
              onClick={closeForm}
              className="absolute top-3 right-3 bg-gray-200 dark:bg-gray-700 p-1 rounded hover:bg-gray-300 dark:hover:bg-gray-600"
              aria-label="Fechar formulário"
            >
              Fechar
            </button>

            {/* Monta o formulário; key força reset quando reaberto */}
            <AcompanhamentoGerencial key={formKey} />
          </div>
        </div>
      )}
    </div>
  );
};

export default FormularioOperacionalPage;
