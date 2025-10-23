import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { BellPlus } from "lucide-react";
import Header from "../../components/common/Header";
import HistoryTable from "../../components/tables/HistoryTable";
import CleaningChecklist from "../../components/checklistComponent/Checklist";
import api from "../../api";

const ChecklistPage = () => {
  const [showForm, setShowForm] = useState(false);
  const [formKey, setFormKey] = useState(0);

  const [ocorrenciasCount, setOcorrenciasCount] = useState(0);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchOcorrenciasCount = async () => {
      try {
        // usa a mesma URL que você utiliza no OcorrenciasPage
        const response = await api.get(
          `${import.meta.env.VITE_API_URL}/ocorrencias`
        );
        const lista = response.data || [];
        const count = Array.isArray(lista)
          ? lista.filter(
              (o) => (o.ocorrenciaStatus || "").toLowerCase() === "pendente"
            ).length
          : 0;
        setOcorrenciasCount(count);
      } catch (err) {
        console.error("Erro ao buscar ocorrências:", err);
        setOcorrenciasCount(0);
      }
    };

    fetchOcorrenciasCount();
  }, []);

  const openForm = () => {
    setFormKey(Date.now()); // força remount do formulário
    setShowForm(true);
  };

  useEffect(() => {
    if (showForm) {
      const prev = document.body.style.overflow;
      document.body.style.overflow = "hidden";
      return () => {
        document.body.style.overflow = prev || "";
      };
    }
    return undefined;
  }, [showForm]);

  const closeForm = () => {
    setShowForm(false);
  };

  return (
    <div className="flex-1 overflow-auto relative z-10">
      <Header title="Supervisão de Limpeza" />
      <button
        type="button"
        onClick={() => navigate("/Ocorrencias")}
        className="relative ml-4 flex items-center gap-2 bg-transparent hover:bg-gray-700/10 rounded px-3 py-2"
        title="Ver ocorrências"
      >
        <BellPlus className="text-white" size={20} />
        {ocorrenciasCount > 0 && (
          <span className="absolute -top-1 -right-1 inline-flex items-center justify-center px-2 py-1 text-xs font-bold leading-none text-white bg-red-600 rounded-full">
            {ocorrenciasCount}
          </span>
        )}
      </button>
      <HistoryTable />
      <div className="mt-4">
        <button
          type="button"
          className="bg-orange-500 text-white px-4 py-2 rounded hover:bg-orange-600"
          onClick={openForm}
        >
          Formulário de Supervisão
        </button>
      </div>

      {showForm && (
        // Modal overlay
        <div
          className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-60 p-4"
          role="dialog"
          aria-modal="true"
          onClick={closeForm}
        >
          <div
            className="bg-white dark:bg-gray-800 rounded-lg shadow-lg w-full max-w-4xl mx-4 sm:mx-auto p-4 sm:p-6 relative"
            style={{ maxHeight: "calc(100vh - 4rem)", overflowY: "auto" }}
            onClick={(e) => e.stopPropagation()}
          >
            <button
              type="button"
              onClick={closeForm}
              className="absolute top-3 right-3 bg-gray-200 dark:bg-gray-700 p-1 rounded hover:bg-gray-300 dark:hover:bg-gray-600"
              aria-label="Fechar formulário"
            >
              Fechar
            </button>
            {/* Monta o formulário; key força reset quando reaberto */}
            <CleaningChecklist key={formKey} />
          </div>
        </div>
      )}
    </div>
  );
};

export default ChecklistPage;
