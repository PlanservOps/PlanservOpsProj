import React, { useEffect, useState } from "react";
import { motion } from "framer-motion";
import Header from "../../components/common/Header";
import api from "../../api";

const ReclamacoesPage = () => {
  const [reclamacoes, setReclamacoes] = useState([]); // Use o mock inicialmente
  const [loading, setLoading] = useState(false); // Não carrega do backend enquanto mock ativo
  const [showModal, setShowModal] = useState(false);
  const [novoCliente, setNovoCliente] = useState("");
  const [novoProblema, setNovoProblema] = useState("");
  const [novaData, setNovaData] = useState("");
  const [clientes, setClientes] = useState([]);

  const [successMessage, setSuccessMessage] = useState("");

  function getStatusLabel(status) {
    switch (status) {
      case 0:
        return "Pendente";
      case 1:
        return "Resolvido";
      case 2:
        return "Cancelado";
      default:
        return "Desconhecido";
    }
  }

  const handleAddReclamacao = async () => {
    if (!novoCliente || !novoProblema || !novaData) return;

    const novaReclamacao = {
      clientePosto: novoCliente,
      reclamacaoDescricao: novoProblema,
      reclamacaoData: novaData,
    };

    try {
      const { data } = await api.post("/Reclamacoes", novaReclamacao);
      setReclamacoes([...reclamacoes, data]); // Adiciona a nova reclamação à lista
      setShowModal(false);
      setNovoCliente("");
      setNovoProblema("");
      setNovaData("");
    } catch (error) {
      alert("Erro ao registrar reclamação!");
      console.error(error);
    }
  };

  useEffect(() => {
    const fetchClientes = async () => {
      try {
        const response = await api.get("/Clientes");
        setClientes(response.data);
      } catch (error) {
        console.error("Erro ao buscar clientes:", error);
        setClientes([]);
      }
    };
    fetchClientes();
  }, []);

  useEffect(() => {
    setLoading(true);
    const fetchReclamacoes = async () => {
      try {
        const { data } = await api.get("/Reclamacoes");
        setReclamacoes(data);
      } catch (error) {
        console.error("Erro ao buscar reclamações:", error);
      } finally {
        setLoading(false);
      }
    };
    fetchReclamacoes();
  }, []);

  return (
    <div className="flex-1 overflow-auto relative z-10 bg-white text-gray-900 dark:bg-gray-900 dark:text-gray-100 transition-colors">
      <Header title="Reclamações" />
      <div className="flex-1 flex flex-col items-center px-4 pt-8 pb-8">
        <div className="w-full max-w-4xl flex justify-end mb-4">
          <button
            className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors"
            onClick={() => setShowModal(true)}
          >
            Registrar Nova Reclamação
          </button>
        </div>
        {showModal && (
          <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-40">
            <motion.div
              initial={{ scale: 0.95, opacity: 0 }}
              animate={{ scale: 1, opacity: 1 }}
              className="bg-white dark:bg-gray-800 rounded-lg p-6 shadow-lg w-full max-w-md"
            >
              <h3 className="text-lg font-semibold mb-4 text-gray-900 dark:text-gray-100">
                Nova Reclamação
              </h3>
              <div className="mb-2">
                <label className="block text-sm mb-1 text-gray-700 dark:text-gray-300">
                  Cliente/Posto
                </label>
                <select
                  value={novoCliente}
                  onChange={(e) => setNovoCliente(e.target.value)}
                  className="w-full px-3 py-2 rounded border border-gray-300 dark:border-gray-600 bg-white dark:bg-gray-900 text-gray-900 dark:text-gray-100"
                  required
                >
                  <option value="">Selecione o cliente</option>
                  {clientes.map((cliente) => (
                    <option
                      key={cliente.clienteId}
                      value={cliente.clientePosto}
                    >
                      {cliente.clientePosto}
                    </option>
                  ))}
                </select>
              </div>
              <div className="mb-2">
                <label className="block text-sm mb-1 text-gray-700 dark:text-gray-300">
                  Problema identificado
                </label>
                <textarea
                  value={novoProblema}
                  onChange={(e) => setNovoProblema(e.target.value)}
                  className="w-full px-3 py-2 rounded border border-gray-300 dark:border-gray-600 bg-white dark:bg-gray-900 text-gray-900 dark:text-gray-100"
                  placeholder="Descreva o problema"
                />
              </div>
              <div className="mb-4">
                <label className="block text-sm mb-1 text-gray-700 dark:text-gray-300">
                  Data
                </label>
                <input
                  type="date"
                  value={novaData}
                  onChange={(e) => setNovaData(e.target.value)}
                  className="w-full px-3 py-2 rounded border border-gray-300 dark:border-gray-600 bg-white dark:bg-gray-900 text-gray-900 dark:text-gray-100"
                />
              </div>
              <div className="flex justify-end gap-2">
                <button
                  className="bg-gray-600 text-white px-4 py-2 rounded hover:bg-gray-700"
                  onClick={() => setShowModal(false)}
                  type="button"
                >
                  Cancelar
                </button>
                <button
                  className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors"
                  onClick={handleAddReclamacao}
                  type="button"
                >
                  Adicionar
                </button>
              </div>
            </motion.div>
          </div>
        )}
         {successMessage && (
                <div className="mb-4 px-4 py-2 bg-green-100 text-green-800 rounded text-center">
                  {successMessage}
                </div>
              )}
        <motion.div
          className="bg-white dark:bg-gray-800 bg-opacity-80 dark:bg-opacity-90 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-200 dark:border-gray-700 max-w-4xl w-full transition-colors"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.2 }}
        >
          <h2 className="text-2xl font-semibold mb-6 text-center text-gray-900 dark:text-gray-100">
            Reclamações Recebidas
          </h2>
          {loading ? (
            <div className="text-gray-500 dark:text-gray-400 text-center">
              Carregando...
            </div>
          ) : reclamacoes.length === 0 ? (
            <div className="text-gray-400 dark:text-gray-500 text-center">
              Nenhuma reclamação encontrada.
            </div>
          ) : (
            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
              {reclamacoes.map((data, idx) => (
                <motion.div
                  key={data.reclamacaoid || idx}
                  className="bg-gray-100 dark:bg-gray-900 rounded-lg shadow p-5 border border-gray-200 dark:border-gray-700 flex flex-col transition-colors"
                  whileHover={{ scale: 1.03 }}
                >
                  <div className="mb-2">
                    <span className="text-sm text-gray-500 dark:text-gray-400">
                      Cliente/Posto:
                    </span>
                    <div className="text-lg text-blue-700 dark:text-blue-300 font-semibold">
                      {data.selectedCliente ||
                        data.clientePosto ||
                        "Não informado"}
                    </div>
                  </div>
                  <div className="mb-2">
                    <span className="text-sm text-gray-500 dark:text-gray-400">
                      Problema identificado:
                    </span>
                    <div className="text-gray-800 dark:text-gray-200">
                      {data.reclamacaoDescricao}
                    </div>
                  </div>
                  <div className="mb-2">
                    <span className="text-sm text-gray-500 dark:text-gray-400">
                      Status:
                    </span>
                    <div className="flex items-center gap-2">
                      <span className="text-gray-800 dark:text-gray-200">
                        {getStatusLabel(data.status)}
                      </span>
                      <select
                        value={data.status}
                        onChange={async (e) => {
                          const novoStatus = Number(e.target.value);
                          try {
                            await api.put(`/Reclamacoes/${data.reclamacaoid}`, {
                              ...data,
                              status: novoStatus,
                            });
                            setReclamacoes((prev) =>
                              prev.map((rec) =>
                                rec.reclamacaoid === data.reclamacaoid
                                  ? { ...rec, status: novoStatus }
                                  : rec
                              )
                            );
                            setSuccessMessage("Status atualizado com sucesso!");
                            setTimeout(() => setSuccessMessage(""), 3000);
                          } catch (error) {
                            alert("Erro ao atualizar status!");
                          }
                        }}
                        className="ml-2 px-2 py-1 rounded border border-gray-300 dark:border-gray-600 bg-white dark:bg-gray-900 text-gray-900 dark:text-gray-100 text-sm"
                      >
                        <option value={0}>Pendente</option>
                        <option value={1}>Resolvido</option>
                        <option value={2}>Cancelado</option>
                      </select>
                    </div>
                  </div>
                  <div className="mb-2">
                    <span className="text-sm text-gray-500 dark:text-gray-400">
                      Data:
                    </span>
                    <div className="text-gray-600 dark:text-gray-400">
                      {data.reclamacaoDescricao
                        ? new Date(data.reclamacaoData).toLocaleDateString(
                            "pt-BR"
                          )
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
