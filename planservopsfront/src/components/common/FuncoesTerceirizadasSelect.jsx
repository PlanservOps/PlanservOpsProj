import React, { useState, useEffect } from "react";
import api from "../../api";

const FuncoesTerceirizadasSelect = ({ value, onChange }) => {
  const [funcoes, setFuncoes] = useState([]);
  const [input, setInput] = useState(value || "");
  const [showOptions, setShowOptions] = useState(false);

  useEffect(() => {
    api
      .get("/FuncaoTerceirizada")
      .then((res) => setFuncoes(res.data))
      .catch(() => setFuncoes([]));
  }, []);

  const handleSelect = (funcao) => {
    onChange(funcao.funcoaterceirizadaid);
    setInput(funcao.funcaoTerceirizadaNome);
    setShowOptions(false);
  };

  const handleAddNew = async () => {
    if (
      input.trim() &&
      !funcoes.some(
        (f) =>
          f.funcaoTerceirizadaNome.toLowerCase() === input.trim().toLowerCase()
      )
    ) {
      try {
        const res = await api.post("/FuncaoTerceirizada", {
          funcaoTerceirizadaNome: input.trim(),
        });
        setFuncoes([...funcoes, res.data]);
        onChange(res.data.funcoaterceirizadaid);
        setInput(res.data.funcaoTerceirizadaNome);
        setShowOptions(false);
      } catch (error) {
        console.error("Erro ao adicionar nova função:", error);
        alert("Erro ao adicionar nova função. Tente novamente.");
      }
    }
  };

  const filteredFuncoes = !input
    ? funcoes
    : funcoes.filter(
        (f) =>
          f &&
          f.funcaoTerceirizadaNome &&
          f.funcaoTerceirizadaNome
            .toLowerCase()
            .includes(String(input).toLowerCase())
      );

  console.log("Funções do banco:", funcoes);

  return (
    <div className="relative">
      <input
        type="text"
        className="w-full px-3 py-2 bg-gray-800 text-gray-100 border border-gray-700 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
        value={input}
        onChange={(e) => {
          setInput(e.target.value);
          setShowOptions(true);
        }}
        onFocus={() => setShowOptions(true)}
        placeholder="Selecione ou digite uma nova função"
        autoComplete="off"
      />
      {showOptions && (
        <ul className="absolute left-0 right-0 mt-1 bg-gray-900 border border-gray-700 rounded shadow-lg z-50 max-h-40 overflow-auto">
          {filteredFuncoes.map((f) => (
            <li
              key={f.funcoaterceirizadaid}
              className="px-4 py-2 cursor-pointer hover:bg-gray-700 text-gray-100"
              onClick={() => handleSelect(f)}
            >
              {f.funcaoTerceirizadaNome}
            </li>
          ))}
          {input &&
            !funcoes.some(
              (f) =>
                f &&
                f.funcaoTerceirizadaNome &&
                f.funcaoTerceirizadaNome.toLowerCase() ===
                  input.trim().toLowerCase()
            ) && (
              <div
                className="px-4 py-2 cursor-pointer text-blue-400 hover:bg-gray-700"
                onClick={handleAddNew}
              >
                Adicionar nova função:{" "}
                <span className="font-semibold">{input}</span>
              </div>
            )}
        </ul>
      )}
    </div>
  );
};

export default FuncoesTerceirizadasSelect;
