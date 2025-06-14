import React, { useState } from 'react';

const roles = [
  { value: 'generalAdmin', label: 'Diretoria' },
  { value: 'manager', label: 'Gerente Operacional' },
  { value: 'innerAdmin', label: 'Administrador Interno' },
  { value: 'supervisor', label: 'Fiscal' },
];

const Settings = () => {
  const [form, setForm] = useState({
    name: '',
    email: '',
    password: '',
    role: roles[0].value,
  });
  const [success, setSuccess] = useState('');
  const [error, setError] = useState('');

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setSuccess('');
    setError('');
    try {
      // Substitua pelo seu endpoint de cadastro
      // await api.post('/users', form);
      setSuccess('Usuário cadastrado com sucesso!');
      setForm({ name: '', email: '', password: '', role: roles[0].value });
    } catch (err) {
      setError('Erro ao cadastrar usuário.');
    }
  };

  return (
    <div className="max-w-md mx-auto mt-10 bg-gray-900 bg-opacity-80 backdrop-blur-md rounded-xl shadow-lg border border-gray-700 p-8">
      <h2 className="text-2xl font-bold mb-6 text-gray-100">Cadastrar Novo Usuário</h2>
      <form onSubmit={handleSubmit} className="space-y-5">
        <div>
          <label className="block text-sm font-medium mb-1 text-gray-300">Nome</label>
          <input
            type="text"
            name="name"
            value={form.name}
            onChange={handleChange}
            required
            className="w-full px-3 py-2 bg-gray-800 text-gray-100 border border-gray-700 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        <div>
          <label className="block text-sm font-medium mb-1 text-gray-300">E-mail</label>
          <input
            type="email"
            name="email"
            value={form.email}
            onChange={handleChange}
            required
            className="w-full px-3 py-2 bg-gray-800 text-gray-100 border border-gray-700 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        <div>
          <label className="block text-sm font-medium mb-1 text-gray-300">Senha</label>
          <input
            type="password"
            name="password"
            value={form.password}
            onChange={handleChange}
            required
            className="w-full px-3 py-2 bg-gray-800 text-gray-100 border border-gray-700 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        <div>
          <label className="block text-sm font-medium mb-1 text-gray-300">Função</label>
          <select
            name="role"
            value={form.role}
            onChange={handleChange}
            className="w-full px-3 py-2 bg-gray-800 text-gray-100 border border-gray-700 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
          >
            {roles.map((role) => (
              <option key={role.value} value={role.value}>
                {role.label}
              </option>
            ))}
          </select>
        </div>
        <button
          type="submit"
          className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700 transition font-semibold shadow"
        >
          Cadastrar
        </button>
        {success && <div className="text-green-400 mt-2">{success}</div>}
        {error && <div className="text-red-400 mt-2">{error}</div>}
      </form>
    </div>
  );
};

export default Settings;