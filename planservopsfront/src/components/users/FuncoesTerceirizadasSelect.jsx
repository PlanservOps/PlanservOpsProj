import React from "react";
import CreatableSelect from "react-select/creatable";

const FuncoesTerceirizadasSelect = ({ value, onChange, opcoes }) => {
  const options = opcoes.map((f) => ({ value: f, label: f }));

  return (
    <CreatableSelect
      isClearable
      options={options}
      value={value ? { value, label: value } : null}
      onChange={(option) => onChange(option ? option.value : "")}
      placeholder="Selecione ou digite uma função"
    />
  );
};

export default FuncoesTerceirizadasSelect;
