import React, { useState } from "react";
import InfoBanner from "../../components/common/InfoBanner";
import Header from "../../components/common/Header";
import StatsCards from "../../components/common/StatsCards";
import { BellPlus, TriangleAlert, ShieldAlert, BarChart2 } from "lucide-react";
import { motion } from "framer-motion";

// Mock de ocorrências para exemplo
const ocorrenciasMock = [
    {
        id: 1,
        posto: "Posto A",
        responsavel: "João Silva",
        data: "2024-06-01",
        detalhes: "Portão ficou aberto após expediente.",
        status: "Nova",
        tipo: "Reclamações"
    },
    {
        id: 2,
        posto: "Posto B",
        responsavel: "Maria Souza",
        data: "2024-06-02",
        detalhes: "Falta de energia no local.",
        status: "Não Atendida",
        tipo: "Não Atendidas"
    },
    // ...mais ocorrências
];

const OcorrenciasPage = () => {
    const [showModal, setShowModal] = useState(false);
    const [ocorrencias, setOcorrencias] = useState(ocorrenciasMock);
    const [selectedStat, setSelectedStat] = useState(null);
    const [selectedOcorrencia, setSelectedOcorrencia] = useState(null);
    const [form, setForm] = useState({
        posto: "",
        responsavel: "",
        data: "",
        detalhes: "",
    });

    // Filtra ocorrências pelo tipo do statcard selecionado
    const ocorrenciasFiltradas = selectedStat
        ? ocorrencias
              .filter((o) => o.tipo === selectedStat)
              .sort((a, b) => new Date(a.data) - new Date(b.data))
        : [];

    const handleRegister = (e) => {
        e.preventDefault();
        setOcorrencias([
            ...ocorrencias,
            {
                id: ocorrencias.length + 1,
                posto: form.posto,
                responsavel: form.responsavel,
                data: form.data,
                detalhes: form.detalhes,
                status: "Nova",
                tipo: "Novas Ocorrências",
            },
        ]);
        setForm({ posto: "", responsavel: "", data: "", detalhes: "" });
        setShowModal(false);
    };

    return (
        <div className="flex-1 overflow-auto relative z-10">
            <Header title="Ocorrências" />
            <div className="p-6">
                <InfoBanner message="Esta página está em desenvolvimento. Algumas mudanças ainda irão ocorrer." />
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
                            value={ocorrencias.filter((o) => o.tipo === "Nova" || o.tipo === "Novas Ocorrências").length}
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
                            {selectedStat}
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
                                    >
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
};

export default OcorrenciasPage;