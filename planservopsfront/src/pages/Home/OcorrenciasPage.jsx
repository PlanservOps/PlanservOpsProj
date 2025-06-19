import React, { useEffect, useState } from "react";
import Header from "../../components/common/Header";
import StatsCards from "../../components/common/StatsCards";
import { BellPlus, TriangleAlert, ShieldAlert, BarChart2 } from "lucide-react";
import { motion } from "framer-motion";
import api from "../../api";

function OcorrenciasPage() {
  const [ocorrencias, setOcorrencias] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

    const statusEnum = [
    { value: 0, label: "Pendente" },
    { value: 1, label: "Prioridade Alta" },
    { value: 2, label: "Não Atendido" },
    { value: 3, label: "Resolvido" }
    ];

  const [showModal, setShowModal] = useState(false);
  const [selectedStat, setSelectedStat] = useState(null);
  const [selectedOcorrencia, setSelectedOcorrencia] = useState(null);
  const [form, setForm] = useState({
    posto: "",
    responsavel: "",
    data: "",
    detalhes: "",
    status: "",
  });

  useEffect(() => {
    async function fetchOcorrencias() {
      try {
        setLoading(true);
        const response = await api.get(`${import.meta.env.VITE_API_URL}/ocorrencias`);
        setOcorrencias(response.data);
      } catch (err) {
        setError("Erro ao buscar ocorrências");
      } finally {
        setLoading(false);
      }
    }
    fetchOcorrencias();
  }, []);

  const [statusList, setStatusList] = useState([]);

  // Filtra ocorrências pelo tipo do statcard selecionado
  const ocorrenciasFiltradas =
  selectedStat === "novas"
    ? ocorrencias.filter(isNovaOcorrencia)
    : selectedStat === "naoatendida"
    ? ocorrencias.filter(isNaoAtendida)
    : selectedStat === "resolvida"
    ? ocorrencias.filter(isResolvida)
    : [];

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
        await api.post(`${import.meta.env.VITE_API_URL}/ocorrencias`, {
        ClientePosto: form.posto,
        ClienteResponsavel: form.responsavel,
        ocorrenciadata: form.data,
        OcorrenciaDescricao: form.detalhes,
        ocorrenciaStatus: form.ocorrenciaStatus,
        });
        setShowModal(false);
        setForm({ posto: "", responsavel: "", data: "", detalhes: "", status: "" });
        // Atualize a lista de ocorrências após o cadastro
        const response = await api.get(`${import.meta.env.VITE_API_URL}/ocorrencias`);
        setOcorrencias(response.data);
    } catch (err) {
        if (err.response) {
            console.log("Detalhe do erro:", err.response.data);
        }
        alert("Erro ao registrar ocorrência");
    }
  };

  return (
    <div className="flex-1 overflow-auto relative z-10">
      <Header title="Ocorrências" />
      <div className="p-6">
        <div className="flex justify-between items-center mb-6">
          <h1 className="text-2xl font-bold text-gray-100">Ocorrências</h1>
          <button
            className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors"
            onClick={() => setShowModal(true)}
          >
            Registrar Ocorrência
          </button>
        </div>

        {/* StatsCards */}
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-4 gap-4 mb-8">
          <div
            className="cursor-pointer"
            onClick={() => {
              setSelectedStat("Nova");
              setSelectedOcorrencia(null);
            }}
          >
            <StatsCards
              name="Novas Ocorrências"
              icon={BellPlus}
              value={ocorrencias.length}
              color="#8B5CF6"
            />
          </div>
          <div
            className="cursor-pointer"
            onClick={() => {
              setSelectedStat("Não Atendida");
              setSelectedOcorrencia(null);
            }}
          >
            <StatsCards
              name="Não Atendidas"
              icon={TriangleAlert}
              value={ocorrencias.filter((o) => o.tipo === "Não Atendida").length}
              color="#EC4899"
            />
          </div>
          <div
            className="cursor-pointer"
            onClick={() => {
              setSelectedStat("Atendida");
              setSelectedOcorrencia(null);
            }}
          >
            <StatsCards
              name="Índice de Atendimento"
              icon={BarChart2}
              value={
                ocorrencias.length > 0
                  ? (
                      (ocorrencias.filter((o) => o.tipo === "Atendida").length /
                        ocorrencias.length) *
                      100
                    ).toFixed(1) + "%"
                  : "0%"
              }
              color="#10B981"
            />
          </div>
          <div
            className="cursor-pointer"
            onClick={() => {
              setSelectedStat("Reclamações");
              setSelectedOcorrencia(null);
            }}
          >
            <StatsCards
              name="Reclamações"
              icon={ShieldAlert}
              value={ocorrencias.filter((o) => o.tipo === "Reclamações").length}
              color="#FF0000"
            />
          </div>
        </div>

        {/* Lista de ocorrências filtradas */}
        {selectedStat && !selectedOcorrencia && (
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ delay: 0.1 }}
            className="mb-8"
          >
            <h2 className="text-xl font-semibold text-gray-200 mb-4">
              {selectedStat === "novas"
                ? "Novas Ocorrências"
                : selectedStat === "naoatendida"
                ? "Não Atendidas"
                : selectedStat === "resolvida"
                ? "Resolvidas"
                : ""}
            </h2>
            {ocorrenciasFiltradas.length === 0 ? (
              <div className="text-gray-400">Nenhuma ocorrência encontrada.</div>
            ) : (
              <ul className="divide-y divide-gray-700 rounded-lg bg-gray-800">
                {ocorrenciasFiltradas.map((o) => (
                  <li
                    key={o.id}
                    className="p-4 hover:bg-gray-700 cursor-pointer"
                    onClick={() => setSelectedOcorrencia(o)}
                  >{o.ClientePosto} - {o.OcorrenciaDescricao}
                    <div className="flex justify-between">
                      <span className="font-medium text-blue-300">{o.posto}</span>
                      <span className="text-gray-400">{new Date(o.data).toLocaleDateString()}</span>
                    </div>
                    <div className="text-gray-200">{o.responsavel}</div>
                  </li>
                ))}
              </ul>
            )}
            <button
              className="mt-4 text-blue-400 hover:underline"
              onClick={() => setSelectedStat(null)}
            >
              Voltar
            </button>
          </motion.div>
        )}

        {/* Detalhe da ocorrência */}
        {selectedOcorrencia && (
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ delay: 0.1 }}
            className="mb-8 bg-gray-800 rounded-lg p-6 shadow"
          >
            <h2 className="text-xl font-semibold text-gray-200 mb-4">
              Detalhes da Ocorrência
            </h2>
            <div className="mb-2">
              <span className="text-gray-400">Posto: </span>
              <span className="text-white">{selectedOcorrencia.posto}</span>
            </div>
            <div className="mb-2">
              <span className="text-gray-400">Responsável: </span>
              <span className="text-white">{selectedOcorrencia.responsavel}</span>
            </div>
            <div className="mb-2">
              <span className="text-gray-400">Data: </span>
              <span className="text-white">
                {new Date(selectedOcorrencia.data).toLocaleDateString()}
              </span>
            </div>
            <div className="mb-2">
              <span className="text-gray-400">Detalhes: </span>
              <span className="text-white">{selectedOcorrencia.detalhes}</span>
            </div>
            <button
              className="mt-4 text-blue-400 hover:underline"
              onClick={() => setSelectedOcorrencia(null)}
            >
              Voltar para lista
            </button>
          </motion.div>
        )}

        {/* Modal de registro de ocorrência */}
        {showModal && (
          <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
            <motion.div
              initial={{ scale: 0.9, opacity: 0 }}
              animate={{ scale: 1, opacity: 1 }}
              className="bg-gray-800 p-8 rounded-lg shadow-lg w-full max-w-md"
            >
              <h2 className="text-xl font-semibold text-white mb-4">Registrar Ocorrência</h2>
              <form
                onSubmit={handleRegister}
                className="space-y-4"
              >
                <div>
                  <label className="block text-sm font-medium text-gray-300">Posto</label>
                  <input
                    type="text"
                    required
                    value={form.posto}
                    onChange={e => setForm({ ...form, posto: e.target.value })}
                    className="w-full px-4 py-2 rounded-lg bg-gray-700 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">Nome Responsável</label>
                  <input
                    type="text"
                    required
                    value={form.responsavel}
                    onChange={e => setForm({ ...form, responsavel: e.target.value })}
                    className="w-full px-4 py-2 rounded-lg bg-gray-700 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">Data do Registro</label>
                  <input
                    type="date"
                    required
                    value={form.data}
                    onChange={e => setForm({ ...form, data: e.target.value })}
                    className="w-full px-4 py-2 rounded-lg bg-gray-700 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">Detalhes</label>
                  <textarea
                    required
                    value={form.detalhes}
                    onChange={e => setForm({ ...form, detalhes: e.target.value })}
                    className="w-full px-4 py-2 rounded-lg bg-gray-700 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-300">Status</label>
                    <select
                        required
                        value={form.ocorrenciaStatus}
                        onChange={e => setForm({ ...form, ocorrenciaStatus: Number(e.target.value) })}
                        className="w-full px-4 py-2 rounded-lg bg-gray-700 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                        >
                        <option value="">Selecione o status</option>
                        {statusEnum.map(opt => (
                            <option key={opt.value} value={opt.value}>{opt.label}</option>
                        ))}
                    </select>
                </div>
                <div className="flex justify-end gap-2">
                  <button
                    type="button"
                    className="bg-gray-600 text-white px-4 py-2 rounded-lg hover:bg-gray-700"
                    onClick={() => setShowModal(false)}
                  >
                    Cancelar
                  </button>
                  <button
                    type="submit"
                    className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700"
                  >
                    Registrar
                  </button>
                </div>
              </form>
            </motion.div>
          </div>
        )}
      </div>
    </div>
  );
}

export default OcorrenciasPage;