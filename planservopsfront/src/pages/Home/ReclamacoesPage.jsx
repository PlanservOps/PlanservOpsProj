import React, { useEffect, useState } from "react";
import { motion } from "framer-motion";
import Header from "../../components/common/Header";
import api from "../../api";

const ReclamacoesPage = () => {
    const [reclamacoes, setReclamacoes] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchReclamacoes = async () => {
            try {
                // Supondo que o endpoint /Formulario retorna todos os formulários enviados
                const { data } = await api.get("/Formulario");
                // Filtra apenas os que têm problemas identificados preenchidos
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

    return (
        <div className="flex-1 overflow-auto relative z-10">
            <Header title="Reclamações" />
            <div className="flex-1 flex flex-col items-center px-4 pt-8 pb-8">
                <motion.div
                    className="bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700 max-w-4xl w-full"
                    initial={{ opacity: 0, y: 20 }}
                    animate={{ opacity: 1, y: 0 }}
                    transition={{ delay: 0.2 }}
                >
                    <h2 className="text-2xl font-semibold text-gray-100 mb-6 text-center">
                        Reclamações Recebidas
                    </h2>
                    {loading ? (
                        <div className="text-gray-300 text-center">Carregando...</div>
                    ) : reclamacoes.length === 0 ? (
                        <div className="text-gray-400 text-center">Nenhuma reclamação encontrada.</div>
                    ) : (
                        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                            {reclamacoes.map((rec, idx) => (
                                <motion.div
                                    key={rec.id || idx}
                                    className="bg-gray-900 rounded-lg shadow p-5 border border-gray-700 flex flex-col"
                                    whileHover={{ scale: 1.03 }}
                                >
                                    <div className="mb-2">
                                        <span className="text-sm text-gray-400">Cliente/Posto:</span>
                                        <div className="text-lg text-blue-300 font-semibold">
                                            {rec.selectedCliente || "Não informado"}
                                        </div>
                                    </div>
                                    <div className="mb-2">
                                        <span className="text-sm text-gray-400">Problema identificado:</span>
                                        <div className="text-gray-200">{rec.input1}</div>
                                    </div>
                                    <div className="mb-2">
                                        <span className="text-sm text-gray-400">Data:</span>
                                        <div className="text-gray-400">
                                            {rec.createdAt
                                                ? new Date(rec.createdAt).toLocaleString("pt-BR")
                                                : "Data não disponível"}
                                        </div>
                                    </div>
                                    {/* Adicione mais campos se desejar */}
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