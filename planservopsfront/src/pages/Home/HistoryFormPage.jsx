import React, { useEffect, useState } from 'react'
import Header from '../../components/common/Header'
import api from '../../api'

const EficienciaPage = () => {
    const [formularios, setFormularios] = useState([]);
    const [searchTerm, setSearchTerm] = useState("");
    const [page, setPage] = useState(1);
    const [total, setTotal] = useState(0);

    useEffect(() => {
        const fetchData = async () => {
            try {
                // Monta a query string para busca e paginação
                const params = {};
                if (searchTerm) params.nome = searchTerm;
                params.page = page;
                params.pageSize = 10; // ajuste conforme sua API

                const response = await api.get("/Formulario", { params });
                setFormularios(response.data.items || response.data); // ajuste conforme resposta da API
                setTotal(response.data.total || response.data.length || 0);
            } catch (error) {
                console.error("Erro ao buscar formulários:", error);
            }
        };

        fetchData();
    }, [searchTerm, page]);

    return (
        <div className="flex-1 overflow-auto relative z-10">
            <Header title="Eficiência" />
            <h1 className="text-2xl font-bold mb-4">Histórico de Formulários</h1>

            <input
                type="text"
                placeholder="Buscar por nome..."
                value={searchTerm}
                onChange={(e) => {
                    setPage(1);
                    setSearchTerm(e.target.value);
                }}
                className="border p-2 rounded mb-4 w-full max-w-md"
            />

            <table className="w-full border">
                <thead>
                    <tr className="bg-gray-700 text-white">
                        <th className="p-2 border">Nome</th>
                        <th className="p-2 border">Data de Envio</th>
                        <th className="p-2 border">Status</th>
                    </tr>
                </thead>
                <tbody>
                    {formularios.map((form) => (
                        <tr key={form.id}>
                            <td className="p-2 border">{form.nome}</td>
                            <td className="p-2 border">
                                {form.dataEnvio ? new Date(form.dataEnvio).toLocaleDateString() : ""}
                            </td>
                            <td className="p-2 border">{form.status}</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {/* Paginação simples */}
            <div className="mt-4 flex gap-2 justify-center">
                <button
                    onClick={() => setPage((p) => Math.max(p - 1, 1))}
                    disabled={page === 1}
                    className="px-4 py-2 bg-gray-700 rounded"
                >
                    Anterior
                </button>
                <span>Página {page}</span>
                <button
                    onClick={() => setPage((p) => p + 1)}
                    disabled={formularios.length < 10}
                    className="px-4 py-2 bg-gray-700 rounded"
                >
                    Próxima
                </button>
            </div>
        </div>
    );
}

export default EficienciaPage