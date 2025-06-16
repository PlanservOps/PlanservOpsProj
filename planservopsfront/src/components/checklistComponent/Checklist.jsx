import React, { useState } from "react";

const initialItems = [
  { time: "06:00 - 06:10", desc: "Retirada de material de limpeza" },
  { time: "06:10 - 07:30", desc: "Limpeza dos 6 elevadores e halls S1, S2, recepção e sala administrativa (Lavagem a seco)" },
  { time: "07:30 - 08:30", desc: "Lavar WC fem. e masc. do térreo (Teto, parede, espelho e piso) - Secar!" },
  { time: "08:30 - 09:30", desc: "Lavar WCs fem. e masc. do 1º andar (Teto, parede, espelho e piso) - Secar!" },
  { time: "09:30 - 10:00", desc: "Limpeza da recepção (apenas piso)" },
  { time: "10:00 - 11:00", desc: "Lavar WC fem. e masc. Subsolo 1 (Teto, parede, espelho e piso) - Secar!" },
  { time: "11:00 - 11:30", desc: "Revisão WC fem. e masc. térreo (Teto, parede, espelho e piso) - Secar!" },
  { time: "11:30 - 12:00", desc: "Revisão WC fem. e masc. 1º andar (Teto, parede, espelho e piso) - Secar!" },

  { time: "13:00 - 13:40", desc: "Limpeza dos 6 elevadores e halls S1, S2 (Teto, parede, piso, espelho, mármore)" },
  { time: "13:40 - 14:40", desc: "Lavar WC fem. e masc. do térreo (Teto, parede, espelho e piso) - Secar!" },
  { time: "14:40 - 15:40", desc: "Lavar WCs fem. e masc. do 1º andar (Teto, parede, espelho e piso) - Secar!" },
  { time: "15:40 - 16:40", desc: "Lavar WC fem. e masc. do térreo (Teto, parede, espelho e piso) - Secar!" },
  { time: "16:40 - 17:30", desc: "Limpeza da recepção (mármore, parede vazada, piso, mobiliário, detalhes, vidro, maçanetas) - PRIORIZAR DETALHES!" },
  { time: "17:30 - 18:00", desc: "Limpeza da copa (Teto, parede, piso, eletros, utensílios, pia, armários)" },
  { time: "18:00", desc: "Organização do material" },
  // ...adicione os demais itens conforme o checklist...
];

export default function CleaningChecklist() {
  const [items, setItems] = useState(
    initialItems.map(item => ({
      ...item,
      checked: false,
      photo: null,
      descEdit: item.desc,
      photoPreview: null,
    }))
  );

  const handleCheck = (idx) => {
    setItems(items =>
      items.map((item, i) =>
        i === idx ? { ...item, checked: !item.checked } : item
      )
    );
  };

  const handleDescChange = (idx, value) => {
    setItems(items =>
      items.map((item, i) =>
        i === idx ? { ...item, descEdit: value } : item
      )
    );
  };

  const handlePhotoChange = (idx, file) => {
    const reader = new FileReader();
    reader.onloadend = () => {
      setItems(items =>
        items.map((item, i) =>
          i === idx
            ? { ...item, photo: file, photoPreview: reader.result }
            : item
        )
      );
    };
    if (file) reader.readAsDataURL(file);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Aqui você pode enviar os dados para a API
    const data = items.map(({ time, descEdit, checked, photo }) => ({
      time,
      desc: descEdit,
      checked,
      photo,
    }));
    console.log("Checklist enviado:", data);
    alert("Checklist enviado!");
  };

  return (
    <form onSubmit={handleSubmit} className="max-w-2xl mx-auto p-4 bg-gray-800 rounded shadow">
      <h2 className="text-xl font-bold mb-4">Checklist de Limpeza</h2>
      <ul className="space-y-4">
        {items.map((item, idx) => (
          <li key={idx} className="flex flex-col gap-2 border-b pb-4">
            <div className="flex items-center gap-2">
              <input
                type="checkbox"
                checked={item.checked}
                onChange={() => handleCheck(idx)}
                id={`check-${idx}`}
              />
              <span className="font-mono text-sm">{item.time}</span>
              <input
                type="text"
                value={item.descEdit}
                onChange={e => handleDescChange(idx, e.target.value)}
                className="flex-1 border rounded px-2 py-1 ml-2"
              />
            </div>
            {item.checked && (
              <div className="flex items-center gap-2 ml-6">
                <label className="text-xs font-semibold">
                  Foto obrigatória:
                  <input
                    type="file"
                    accept="image/*"
                    onChange={e => handlePhotoChange(idx, e.target.files[0])}
                    required
                    className="ml-2"
                  />
                </label>
                {item.photoPreview && (
                  <img
                    src={item.photoPreview}
                    alt="Prévia"
                    className="w-16 h-16 object-cover rounded border"
                  />
                )}
              </div>
            )}
          </li>
        ))}
      </ul>
      <button
        type="submit"
        className="mt-6 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700"
      >
        Enviar Checklist
      </button>
    </form>
  );
}