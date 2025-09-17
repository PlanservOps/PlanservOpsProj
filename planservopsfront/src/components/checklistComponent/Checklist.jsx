import React, { useState, useEffect } from "react";
import api from "../../api";

const initialItems = [
  { time: "06:00 - 06:10", desc: "Retirada de material de limpeza" },
  {
    time: "06:10 - 07:30",
    desc: "Limpeza dos 6 elevadores e halls S1, S2, recepção e sala administrativa (Lavagem a seco)",
  },
  {
    time: "07:30 - 08:30",
    desc: "Lavar WC fem. e masc. do térreo (Teto, parede, espelho e piso) - Secar!",
  },
  {
    time: "08:30 - 09:30",
    desc: "Lavar WCs fem. e masc. do 1º andar (Teto, parede, espelho e piso) - Secar!",
  },
  { time: "09:30 - 10:00", desc: "Limpeza da recepção (apenas piso)" },
  {
    time: "10:00 - 11:00",
    desc: "Lavar WC fem. e masc. Subsolo 1 (Teto, parede, espelho e piso) - Secar!",
  },
  {
    time: "11:00 - 11:30",
    desc: "Revisão WC fem. e masc. térreo (Teto, parede, espelho e piso) - Secar!",
  },
  {
    time: "11:30 - 12:00",
    desc: "Revisão WC fem. e masc. 1º andar (Teto, parede, espelho e piso) - Secar!",
  },
  {
    time: "13:00 - 13:40",
    desc: "Limpeza dos 6 elevadores e halls S1, S2 (Teto, parede, piso, espelho, mármore)",
  },
  {
    time: "13:40 - 14:40",
    desc: "...",
  },
];

export default function CleaningChecklist() {
  const [items, setItems] = useState(
    initialItems.map((item) => ({
      ...item,
      checked: false,
      photo: null,
      descEdit: item.desc,
      photoPreview: null,
    }))
  );

  const [clientes, setClientes] = useState([]);
  const [clienteBusca, setClienteBusca] = useState("");
  const [clienteSelecionado, setClienteSelecionado] = useState("");
  const [successMessage, setSuccessMessage] = useState("");
  const [pdfUrl, setPdfUrl] = useState(null);

  useEffect(() => {
    const fetchClientes = async () => {
      try {
        const response = await api.get("/Clientes");
        setClientes(response.data);
      } catch (error) {
        setClientes([]);
      }
    };
    fetchClientes();
  }, []);

  const handleCheck = (idx) => {
    setItems((items) =>
      items.map((item, i) =>
        i === idx ? { ...item, checked: !item.checked } : item
      )
    );
  };

  const handleDescChange = (idx, value) => {
    setItems((items) =>
      items.map((item, i) => (i === idx ? { ...item, descEdit: value } : item))
    );
  };

  const handleTimeChange = (idx, value) => {
    setItems((items) =>
      items.map((item, i) => (i === idx ? { ...item, timeEdit: value } : item))
    );
  };

  const handlePhotoChange = (idx, file) => {
    const reader = new FileReader();
    reader.onloadend = () => {
      setItems((items) =>
        items.map((item, i) =>
          i === idx
            ? { ...item, photo: file, photoPreview: reader.result }
            : item
        )
      );
    };
    if (file) reader.readAsDataURL(file);
  };

  const handleRemoveItem = (idx) => {
    setItems((items) => items.filter((_, i) => i !== idx));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const formData = new FormData();

    formData.append("cliente", clienteSelecionado);
    formData.append("DataHoraSubmissao", new Date().toISOString());

    items.forEach((item, index) => {
      const timeToUse = item.timeEdit || item.time;
      const [startTime, endTime] = timeToUse.split(" - ").map((t) => t.trim());

      formData.append(`ItensDescricao[${index}]`, item.descEdit);
      formData.append(`ItensHorarioInicio[${index}]`, startTime || "");
      formData.append(`ItensHorarioFim[${index}]`, endTime || "");
      formData.append(`ItensConcluido[${index}]`, item.checked);

      if (item.photo) {
        formData.append(`ItensImagem[${index}]`, item.photo);
      }
    });

    for (let pair of formData.entries()) {
      console.log(pair[0], pair[1]);
    }

    try {
      const response = await api.post("/Checklist/gerar-pdf", formData, {
        headers: {},
        responseType: "blob", // Importante para receber o PDF como blob
      });

      // Extrair nome do arquivo
      const contentDisposition = response.headers["content-disposition"];
      let filename = "Checklist.pdf";
      if (contentDisposition) {
        const match = contentDisposition.match(/filename\*?=(?:UTF-8'')?(.+)/);
        if (match && match[1]) {
          filename = decodeURIComponent(match[1].replace(/"/g, ""));
        }
      }

      // Criar link de download
      const url = window.URL.createObjectURL(
        new Blob([response.data], { type: "application/pdf" })
      );
      const link = document.createElement("a");
      link.href = url;
      link.setAttribute("download", filename);
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
      window.URL.revokeObjectURL(url);

      if (response.status === 200) {
        setSuccessMessage("Checklist enviado com sucesso!");
        // Se a API retorna a URL do PDF no body:
        if (response.data && response.data.pdfUrl) {
          setPdfUrl(response.data.pdfUrl);
        }
      }
      console.log("Checklist enviado com sucesso!");
    } catch (error) {
      console.error("Erro ao enviar checklist:", error);
    }
  };

  console.log("Cliente selecionado:", clienteSelecionado);
  console.log("Itens do checklist:", items);

  return (
    <form
      onSubmit={handleSubmit}
      className="max-w-2xl mx-auto p-4 bg-white text-gray-900 dark:bg-gray-800 dark:text-gray-100 rounded shadow transition-colors"
    >
      <h2 className="text-xl font-bold mb-4">Supervisão de Limpeza</h2>
      {successMessage && (
        <div className="mb-4 p-3 rounded bg-green-100 text-green-800 border border-green-300">
          {successMessage}
        </div>
      )}
      <div className="mb-4">
        <label className="block text-sm font-medium mb-1 text-gray-700 dark:text-gray-300">
          Buscar Cliente
        </label>
        <select
          value={clienteSelecionado}
          onChange={(e) => setClienteSelecionado(e.target.value)}
          className="border border-gray-300 dark:border-gray-600 rounded px-2 py-1 w-full bg-white dark:bg-gray-900 text-gray-900 dark:text-gray-100 transition-colors"
        >
          <option value="">Selecione um cliente</option>
          {clientes
            .filter((c) =>
              c.clientePosto?.toLowerCase().includes(clienteBusca.toLowerCase())
            )
            .map((c) => (
              <option key={c.clienteId} value={String(c.clientePosto)}>
                {c.clientePosto}
              </option>
            ))}
        </select>
      </div>

      <ul className="space-y-4">
        {items.map((item, idx) => (
          <li
            key={idx}
            className="flex flex-col gap-2 border-b border-gray-200 dark:border-gray-700 pb-4"
          >
            <div className="flex items-center gap-2">
              <input
                type="checkbox"
                checked={item.checked}
                onChange={() => handleCheck(idx)}
                id={`check-${idx}`}
                className="accent-blue-600 w-5 h-5"
              />
              <input
                type="text"
                value={item.timeEdit ?? item.time}
                onChange={(e) => handleTimeChange(idx, e.target.value)}
                maxLength={10}
                className="font-mono text-sm border border-gray-300 dark:border-gray-600 rounded px-2 py-1 w-32 bg-white dark:bg-gray-900 text-gray-900 dark:text-gray-100 transition-colors"
              />
              <input
                type="text"
                value={item.descEdit}
                onChange={(e) => handleDescChange(idx, e.target.value)}
                className="flex-1 border border-gray-300 dark:border-gray-600 rounded px-2 py-1 ml-2 bg-white dark:bg-gray-900 text-gray-900 dark:text-gray-100 transition-colors"
              />
              <button
                type="button"
                onClick={() => handleRemoveItem(idx)}
                className="ml-2 text-red-600 hover:text-red-800 text-xl"
                title="Remover tarefa"
              >
                🗑️
              </button>
            </div>
            {item.checked && (
              <div className="flex items-center gap-2 ml-6">
                <label className="text-xs font-semibold">
                  Foto obrigatória:
                  <input
                    type="file"
                    accept="image/*"
                    onChange={(e) => handlePhotoChange(idx, e.target.files[0])}
                    required
                    className="ml-2 text-gray-900 dark:text-gray-100"
                  />
                </label>
                {item.photoPreview && (
                  <img
                    src={item.photoPreview}
                    alt="Prévia"
                    className="w-16 h-16 object-cover rounded border border-gray-300 dark:border-gray-600"
                  />
                )}
              </div>
            )}
          </li>
        ))}
      </ul>
      <button
        type="button"
        className="mt-4 px-4 py-2 bg-green-600 text-white rounded hover:bg-green-700 transition-colors"
        onClick={() =>
          setItems((prev) => [
            ...prev,
            {
              time: "",
              desc: "",
              checked: false,
              photo: null,
              descEdit: "",
              timeEdit: "",
              photoPreview: null,
            },
          ])
        }
      >
        Adicionar tarefa
      </button>
      <button
        type="submit"
        className="mt-6 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700 transition-colors"
      >
        Enviar Formulário
      </button>      
    </form>
  );
}
