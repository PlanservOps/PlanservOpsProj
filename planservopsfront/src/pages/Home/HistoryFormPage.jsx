import React, { useEffect, useState } from 'react'
import Header from '../../components/common/Header'
import api from '../../api'

const EficienciaPage = () => {
    const [formularios, setFormularios] = useState([]);
    const [clientePosto, setClientePosto] = useState("");
    const [dataEnvio, setDataEnvio] = useState("");
    const [page, setPage] = useState(1);
    const [total, setTotal] = useState(0);

    useEffect(() => {
        const fetchData = async () => {
            try {
                // Monta a query string para busca e paginação
                const params = {};
                if (clientePosto) params.clientePosto = clientePosto; // ajuste conforme sua API
                if (dataEnvio) params.dataEnvio = dataEnvio; // ajuste conforme sua API
                params.page = page;
                params.pageSize = 10;

                const response = await api.get("/Formulario", { params });
                setFormularios(response.data.items || response.data);
                setTotal(response.data.total || response.data.length || 0);
            } catch (error) {
                console.error("Erro ao buscar formulários:", error);
            }
        };

        fetchData();
    }, [clientePosto, dataEnvio, page]);

    return (
        <div className="flex-1 overflow-auto relative z-10">
            <Header title="Eficiência" />
            <h1 className="text-2xl font-bold mb-4">Histórico de Formulários</h1>

            <div className="flex gap-4 mb-4 flex-wrap">
                <input
                    type="text"
                    placeholder="Buscar por cliente..."
                    value={clientePosto}
                    onChange={(e) => {
                        setPage(1);
                        setClientePosto(e.target.value);
                    }}
                    className="border p-2 rounded max-w-xs"
                />
                <input
                    type="date"
                    placeholder="Buscar por data de envio"
                    value={dataEnvio}
                    onChange={(e) => {
                        setPage(1);
                        setDataEnvio(e.target.value);
                    }}
                    className="border p-2 rounded max-w-xs"
                />
            </div>

            <table className="w-full border">
                <thead>
                    <tr className="bg-gray-700 text-white">
                        <th className="p-2 border">Cliente</th>
                        <th className="p-2 border">Data de Envio</th>
                        <th className="p-2 border">Problemas Identificados</th>
                        <th className="p-2 border">Soluções Apresentadas</th>
                    </tr>
                </thead>
                <tbody>
                    {formularios.map((form) => (
                        <tr key={form.id || form.Id || form.formularioid || form.formularioId}>
                            <td className="p-2 border">
                                {form.clientePosto || form.clientePosto || "-"}
                            </td>
                            <td className="p-2 border">
                                {form.dataEnvio
                                    ? new Date(form.dataEnvio).toLocaleDateString()
                                    : form.dataenvio
                                    ? new Date(form.dataenvio).toLocaleDateString()
                                    : ""}
                            </td>
                            <td className="p-2 border">{form.problemasIdentificados || form.problemasidentificados}</td>
                            <td className="p-2 border">{form.solucoesApresentadas || form.solucoesapresentadas}</td>
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