import React, { useEffect, useState } from "react";
import { motion } from "framer-motion";
import Header from "../../components/common/Header";
import api from "../../api";

// MOCK DE RECLAMAÇÕES (remova ou comente quando não precisar mais)
const MOCK_RECLAMACOES = [
  {
    id: 1,
    selectedCliente: "Condomínio Alpha",
    input1: "Portão eletrônico com falha frequente.",
    createdAt: "2025-07-10T09:00:00Z",
  },
  {
    id: 2,
    selectedCliente: "Residencial Beta",
    input1: "Limpeza das áreas comuns insatisfatória.",
    createdAt: "2025-07-12T14:30:00Z",
  },
  {
    id: 3,
    selectedCliente: "Edifício Gama",
    input1: "Barulho excessivo durante a noite.",
    createdAt: "2025-07-15T20:15:00Z",
  },
];

const ReclamacoesPage = () => {
  const [reclamacoes, setReclamacoes] = useState(MOCK_RECLAMACOES); // Use o mock inicialmente
  const [loading, setLoading] = useState(false); // Não carrega do backend enquanto mock ativo

  // Descomente este bloco para usar a API real
  /*
  useEffect(() => {
    setLoading(true);
    const fetchReclamacoes = async () => {
      try {
        const { data } = await api.get("/Formulario");
        const reclamacoesFiltradas = data.filter(
          (item) => item.input1 && item.input1.trim() !== ""
        );
        setReclamacoes(reclamacoesFiltradas);
      } catch (error) {
        console.error("Erro ao buscar reclamações:", error);
      } finally {
        setLoading(false);
      }
    };
    fetchReclamacoes();
  }, []);
  */

  return (
    <div className="flex-1 overflow-auto relative z-10 bg-white text-gray-900 dark:bg-gray-900 dark:text-gray-100 transition-colors">
      <Header title="Reclamações" />
      <div className="flex-1 flex flex-col items-center px-4 pt-8 pb-8">
        <motion.div
          className="bg-white dark:bg-gray-800 bg-opacity-70 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-200 dark:border-gray-700 max-w-4xl w-full"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.2 }}
        >
          <h2 className="text-2xl font-semibold mb-6 text-center">
            Reclamações Recebidas
          </h2>
          {loading ? (
            <div className="text-gray-500 text-center">Carregando...</div>
          ) : reclamacoes.length === 0 ? (
            <div className="text-gray-400 text-center">Nenhuma reclamação encontrada.</div>
          ) : (
            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
              {reclamacoes.map((rec, idx) => (
                <motion.div
                  key={rec.id || idx}
                  className="bg-gray-100 dark:bg-gray-900 rounded-lg shadow p-5 border border-gray-200 dark:border-gray-700 flex flex-col"
                  whileHover={{ scale: 1.03 }}
                >
                  <div className="mb-2">
                    <span className="text-sm text-gray-500 dark:text-gray-400">Cliente/Posto:</span>
                    <div className="text-lg text-blue-700 dark:text-blue-300 font-semibold">
                      {rec.selectedCliente || rec.clientePosto || "Não informado"}
                    </div>
                  </div>
                  <div className="mb-2">
                    <span className="text-sm text-gray-500 dark:text-gray-400">Problema identificado:</span>
                    <div className="text-gray-800 dark:text-gray-200">{rec.input1}</div>
                  </div>
                  <div className="mb-2">
                    <span className="text-sm text-gray-500 dark:text-gray-400">Data:</span>
                    <div className="text-gray-600 dark:text-gray-400">
                      {rec.createdAt
                        ? new Date(rec.createdAt).toLocaleDateString("pt-BR")
                        : "Data não disponível"}
                    </div>
                  </div>
                </motion.div>
              ))}
            </div>
          )}
        </motion.div>
      </div>
    </div>
  );
};

export default ReclamacoesPage;