import React, { useEffect, useState } from "react";
import Header from "../../components/common/Header";
import api from "../../api";

const HistoryFormPage = () => {
  const [formularios, setFormularios] = useState([]);
  const [clientePosto, setClientePosto] = useState("");
  const [clientePostoInput, setClientePostoInput] = useState("");
  const [dataEnvio, setDataEnvio] = useState("");
  const [dataEnvioInput, setDataEnvioInput] = useState("");
  const [page, setPage] = useState(1);
  const [total, setTotal] = useState(0);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const params = {};
        if (clientePosto) params.clientePosto = clientePosto;
        if (dataEnvio) params.dataEnvio = dataEnvio;
        params.page = page;
        params.pageSize = 10;

        const response = await api.get("/FormularioOperacional", { params });
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
      <Header title="Histórico de Formulários" />
      <h1 className="text-2xl font-bold mb-4">Histórico de Formulários</h1>

      <div className="flex gap-4 mb-4 flex-wrap">
        <input
          type="text"
          placeholder="Buscar por cliente..."
          value={clientePostoInput}
          onChange={(e) => setClientePostoInput(e.target.value)}
          onBlur={() => {
            setPage(1);
            setClientePosto(clientePostoInput);
          }}
          onKeyDown={(e) => {
            if (e.key === "Enter") {
              setPage(1);
              setClientePosto(clientePostoInput);
            }
          }}
          className="border p-2 rounded max-w-xs"
        />
        <input
          type="date"
          placeholder="Buscar por data de envio"
          value={dataEnvioInput}
          onChange={(e) => setDataEnvioInput(e.target.value)}
          onBlur={() => {
            setPage(1);
            setDataEnvio(dataEnvioInput);
          }}
          onKeyDown={(e) => {
            if (e.key === "Enter") {
              setPage(1);
              setDataEnvio(dataEnvioInput);
            }
          }}
          className="border p-2 rounded max-w-xs"
        />
      </div>

      <div className="bg-white text-gray-900 dark:bg-gray-800 dark:text-gray-100 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-2 sm:p-6 border border-gray-200 dark:border-gray-700">
        <div className="overflow-x-auto">
          <table className="min-w-full divide-y divide-gray-200 dark:divide-gray-700 text-xs sm:text-sm">
            <thead>
              <tr>
                <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider border-b border-gray-200 dark:border-gray-700">
                  Cliente
                </th>
                <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider border-b border-gray-200 dark:border-gray-700">
                  Data de Envio
                </th>
                <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider border-b border-gray-200 dark:border-gray-700">
                  Problemas Identificados
                </th>
                <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider border-b border-gray-200 dark:border-gray-700">
                  Soluções Apresentadas
                </th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-200 dark:divide-gray-700">
              {formularios.map((form) => (
                <tr
                  key={
                    form.id || form.Id || form.formularioid || form.formularioId
                  }
                  className="hover:bg-gray-100 dark:hover:bg-gray-700 transition-colors cursor-pointer"
                >
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    {form.clientePosto || "-"}
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    {form.dataEnvio
                      ? new Date(form.dataEnvio).toLocaleDateString()
                      : form.dataenvio
                      ? new Date(form.dataenvio).toLocaleDateString()
                      : ""}
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    {form.problemasIdentificados || form.problemasidentificados}
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    {form.solucoesApresentadas || form.solucoesapresentadas}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      <div className="mt-4 flex gap-2 justify-center">
        <button
          onClick={() => setPage((p) => Math.max(p - 1, 1))}
          disabled={page === 1}
          className="px-4 py-2 bg-gray-700 text-white rounded hover:bg-gray-800 disabled:opacity-50"
        >
          Anterior
        </button>
        <span>Página {page}</span>
        <button
          onClick={() => setPage((p) => p + 1)}
          disabled={formularios.length < 10}
          className="px-4 py-2 bg-gray-700 text-white rounded hover:bg-gray-800 disabled:opacity-50"
        >
          Próxima
        </button>
      </div>
    </div>
  );
};

export default HistoryFormPage;
