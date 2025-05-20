import React, { useState, useEffect } from "react";
import { motion } from "framer-motion";
import Header from "../../components/common/Header";
import api from "../../api";

const AvaliacoesFormPage = () => {
    const [clientes, setClientes] = useState([]);
    const [formData, setFormData] = useState({
        range1: 1,
        range2: 1,
        range3: 1,
        selectedCliente: "",
        input1: "",
        input2: "",
        rating1: 1,
        rating2: 1,
        input3: "",
    });

    const [successMessage, setSuccessMessage] = useState("");

    useEffect(() => {
        const fetchClientes = async () => {
            try {
                const response = await api.get("/Clientes");
                setClientes(response.data);
            } catch (error) {
                console.error("Erro ao buscar clientes:", error);
            }
        };

        fetchClientes();
    }, []);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;

        if (type === "checkbox") {
            setFormData((prev) => ({
                ...prev,
                selectedClientes: checked
                    ? [...prev.selectedClientes, value]
                    : prev.selectedClientes.filter((cliente) => cliente !== value),
            }));
        } else {
            setFormData((prev) => ({
                ...prev,
                [name]: value,
            }));
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log("Dados do formulário:", formData);
        setSuccessMessage("Formulário enviado com sucesso!");
        setTimeout(() => {
            setSuccessMessage("");
        }, 3000);
    };

    return (
        <div className="min-h-screen bg-gray-900 flex flex-col">
            <Header title="Relatório Gerencial Operacional" />
                <div className="flex-1 flex justify-center items-start px-4 pt-8 pb-8">
                    <motion.div
                        className="bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700 max-w-4xl w-full sm:h-auto sm:max-h-screen overflow-y-auto"
                        initial={{ opacity: 0, y: 20 }}
                        animate={{ opacity: 1, y: 0 }}
                        transition={{ delay: 0.2 }}
                    >
                        {successMessage && (
                            <div className="mb-4 p-3 rounded bg-green-600 text-white text-center">
                                {successMessage}
                            </div>
                        )}

                        <form onSubmit={handleSubmit} className="space-y-6">
                            <div className="flex justify-between items-center mb-6">
                                <h1 className="text-xl font-semibold text-gray-100">
                                    Relatório Gerencial Operacional
                                </h1>
                            </div>

                            {/* Sessão com seleção numérica (1 a 15) */}
                            <div>
                                <label className="block text-sm font-medium text-gray-300">
                                    Quantidade de clientes atendidos no dia:
                                </label>
                                <input
                                    type="number"
                                    name="range1"
                                    min="1"
                                    max="15"
                                    value={formData.range1}
                                    onChange={handleChange}
                                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                />
                            </div>

                            {/* Sessão com seleção numérica (1 a 100) */}
                            <div>
                                <label className="block text-sm font-medium text-gray-300">
                                    Quantidade de problemas identificados no dia:
                                </label>
                                <input
                                    type="number"
                                    name="range2"
                                    min="1"
                                    max="100"
                                    value={formData.range2}
                                    onChange={handleChange}
                                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                />
                            </div>

                            {/* Sessão com seleção numérica (1 a 15) */}
                            <div>
                                <label className="block text-sm font-medium text-gray-300">
                                    Quantidade de gestores atendidos pessoalmente:
                                </label>
                                <input
                                    type="number"
                                    name="range3"
                                    min="1"
                                    max="15"
                                    value={formData.range3}
                                    onChange={handleChange}
                                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                />
                            </div>

                            <div>
                                <label className="block text-sm font-medium text-gray-300">
                                    Cliente/ Posto:
                                </label>
                                <select
                                    name="selectedCliente"
                                    value={formData.selectedCliente} // Atualiza para armazenar apenas um valor
                                    onChange={(e) => {
                                        const selectedValue = e.target.value; // Captura o valor selecionado
                                        setFormData((prev) => ({
                                            ...prev,
                                            selectedCliente: selectedValue, // Atualiza o estado com o valor único
                                        }));
                                    }}
                                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                >
                                    <option value="" disabled>
                                        Selecione um Cliente ou Posto
                                    </option>
                                    {Array.isArray(clientes) &&
                                        clientes.map((cliente) => (
                                            <option key={cliente.clienteId} value={cliente.clientePosto}>
                                                {cliente.clientePosto}
                                            </option>
                                        ))}
                                </select>
                            </div>

                            {/* Sessão com input de texto */}
                            <div>
                                <label className="block text-sm font-medium text-gray-300">
                                    Problemas identificados (escrever cliente - problema)
                                </label>
                                <input
                                    type="text"
                                    name="input1"
                                    value={formData.input1}
                                    onChange={handleChange}
                                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                />
                            </div>

                            {/* Sessão com outro input de texto */}
                            <div>
                                <label className="block text-sm font-medium text-gray-300">
                                    Soluções apontadas (escrever cliente - solução)
                                </label>
                                <input
                                    type="text"
                                    name="input2"
                                    value={formData.input2}
                                    onChange={handleChange}
                                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                />
                            </div>

                            {/* Sessão com rating (1 a 10) */}
                            <div>
                                <label className="block text-sm font-medium text-gray-300">
                                    Qual a nota do Supervisor Igo nas atividades realizadas hoje?
                                </label>
                                <input
                                    type="number"
                                    name="rating1"
                                    min="1"
                                    max="10"
                                    value={formData.rating1}
                                    onChange={handleChange}
                                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                />
                            </div>

                            {/* Sessão com outro rating (1 a 10) */}
                            <div>
                                <label className="block text-sm font-medium text-gray-300">
                                    Qual a nota do Supervisor Robson nas atividades realizadas hoje?
                                </label>
                                <input
                                    type="number"
                                    name="rating2"
                                    min="1"
                                    max="10"
                                    value={formData.rating2}
                                    onChange={handleChange}
                                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                />
                            </div>

                            {/* Sessão com outro input de texto */}
                            <div>
                                <label className="block text-sm font-medium text-gray-300">
                                    Observações Gerais
                                </label>
                                <input
                                    type="text"
                                    name="input3"
                                    value={formData.input3}
                                    onChange={handleChange}
                                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                />
                            </div>

                            {/* Botão de envio */}
                            <div>
                                <button
                                    type="submit"
                                    className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors w-full sm:w-auto"
                                >
                                    Enviar
                                </button>
                            </div>
                        </form>
                    </motion.div>
                </div>    
        </div>
    );
};

export default AvaliacoesFormPage;