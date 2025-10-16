import React, { useEffect, useState } from "react";
import { Search } from "lucide-react";
import api from "../../api";

const HistoryFormPage = () => {
  const [formularios, setFormularios] = useState([]);
  const [filteredFormularios, setFilteredFormularios] = useState([]);
  const [dataEnvio, setDataEnvio] = useState("");
  const [searchTerm, setSearchTerm] = useState("");
  const [page, setPage] = useState(1);
  const [total, setTotal] = useState(0);

  const handleSearch = (e) => {
    setSearchTerm(e.target.value);
    setPage(1);
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await api.get("/FormularioOperacional");
        const lista = response.data.items || response.data;
        // Ordena do mais novo para o mais velho
        const sorted = [...lista].sort((a, b) => {
          const dateA = new Date(a.dataEnvio || a.dataenvio || 0);
          const dateB = new Date(b.dataEnvio || b.dataenvio || 0);
          return dateB - dateA;
        });
        setFormularios(sorted);
        setFilteredFormularios(sorted);
        setTotal(response.data.total || response.data.length || 0);
      } catch (error) {
        console.error("Erro ao buscar formulários:", error);
      }
    };

    fetchData();
  }, [dataEnvio, page]);

  useEffect(() => {
    if (!searchTerm) {
      setFilteredFormularios(formularios);
      return;
    }
    const filtered = formularios.filter((form) =>
      (form.clientePosto || "").toLowerCase().includes(searchTerm.toLowerCase())
    );
    setFilteredFormularios(filtered);
  }, [searchTerm, formularios]);

  return (
    <div className="flex-1 overflow-auto relative z-10">
      <div className="bg-white text-gray-900 dark:bg-gray-800 dark:text-gray-100 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-2 sm:p-6 border border-gray-200 dark:border-gray-700">
        <div className="overflow-x-auto">
          <div className="relative w-full sm:w-64 mb-4">
            <input
              type="text"
              placeholder="Buscar Clientes..."
              className="bg-gray-700 text-white placeholder-gray-400 rounded-lg pl-10 pr-4 py-2 w-full focus:outline-none focus:ring-2 focus:ring-blue-500"
              value={searchTerm}
              onChange={handleSearch}
            />
            <Search
              className="absolute left-3 top-2.5 text-gray-400"
              size={18}
            />
          </div>
          <table className="min-w-full divide-y divide-gray-200 dark:divide-gray-700 text-xs sm:text-sm">
            <thead>
              <tr>
                <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider border-b border-gray-200 dark:border-gray-700">
                  Cliente
                </th>
                <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider border-b border-gray-200 dark:border-gray-700">
                  Data de Emissão
                </th>                                
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-200 dark:divide-gray-700">
              {filteredFormularios.map((form) => (
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
