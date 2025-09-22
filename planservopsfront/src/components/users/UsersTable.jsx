import { useState, useEffect } from "react";
import { motion } from "framer-motion";
import { Search, X } from "lucide-react";
import api from "../../api";
import FuncoesTerceirizadasSelect from "../common/FuncoesTerceirizadasSelect";

function UsersTable() {
  const baseUrl = import.meta.env.VITE_API_URL;

  const [searchTerm, setSearchTerm] = useState("");
  const [users, setUsers] = useState([]);
  const [filteredUsers, setFilteredUsers] = useState([]);
  const [selectedUser, setSelectedUser] = useState(null);

  const [showForm, setShowForm] = useState(false);

  const [newUser, setNewUser] = useState({
    clientePosto: "",
    clienteResponsavel: "",
    clienteContato: "",
    clienteFuncaoResponsavel: "",
    clienteEndereco: "",
    clienteBairro: "",
    clienteFuncoesTerceirizadasId: "",
  });

  const [editUserId, setEditUserId] = useState(null);
  const [successMessage, setSuccessMessage] = useState("");

  const openCloseForm = () => {
    setShowForm(!showForm);
    if (showForm) {
      setEditUserId(null);
      setNewUser({
        clientePosto: "",
        clienteResponsavel: "",
        clienteContato: "",
        clienteFuncaoResponsavel: "",
        clienteEndereco: "",
        clienteBairro: "",
        clienteObservacao: "",
        clienteFuncoesTerceirizadasId: "",
      });
    }
  };

  const openEditForm = (user) => {
    setEditUserId(user.clienteId);
    setNewUser(user);
    setShowForm(true);
  };

  const openAddForm = () => {
    setEditUserId(null); // Limpa o modo edição
    setNewUser({
      clientePosto: "",
      clienteResponsavel: "",
      clienteContato: "",
      clienteFuncaoResponsavel: "",
      clienteEndereco: "",
      clienteBairro: "",
      clienteObservacao: "",
      clienteFuncoesTerceirizadasId: "",
    });
    setShowForm(true);
  };

  const updateUser = async () => {
    try {
      console.log("Atualizando usuário:", newUser);
      const { data } = await api.put(`/Clientes/${editUserId}`, payload);
      const updatedUsers = users.map((user) =>
        user.clienteId === editUserId ? data : user
      );
      setUsers(updatedUsers);
      setFilteredUsers(updatedUsers);
      setShowForm(false);
      setEditUserId(null);
      setSuccessMessage("Cliente atualizado com sucesso!");
      setTimeout(() => setSuccessMessage(""), 3000);
    } catch (error) {
      console.error("Erro ao atualizar usuário:", error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setNewUser({
      ...newUser,
      [name]: value,
    });
    console.log(newUser);
  };

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await api.get("/Clientes");
        setUsers(response.data);
        setFilteredUsers(response.data);
      } catch (error) {
        console.error("Erro ao buscar usuários:", error);
      }
    };

    fetchUsers();
  }, [baseUrl]);

  const funcaoEnumMap = {
    Gerente: 2,
    Síndico: 1,
    Síndica: 0,
  };

  const payload = {
    ...newUser,
    clienteFuncaoResponsavel: funcaoEnumMap[newUser.clienteFuncaoResponsavel],
  };

  const addUser = async () => {
    try {
      const payload = {
        ...newUser,
        clienteFuncaoResponsavel:
          funcaoEnumMap[newUser.clienteFuncaoResponsavel],
        clienteFuncoesTerceirizadasId: parseInt(
          newUser.clienteFuncoesTerceirizadasId
        ),
      };

      if (newUser.clienteFuncoesTerceirizadasId) {
        payload.clienteFuncoesTerceirizadasId = parseInt(
          newUser.clienteFuncoesTerceirizadasId
        );
      }

      console.log("Enviando usuário:", payload);

      const { data } = await api.post("/Clientes", payload);
      setUsers([...users, data]);
      setFilteredUsers([...users, data]);
      setShowForm(false);
      setSuccessMessage("Cliente adicionado com sucesso!");
      setTimeout(() => setSuccessMessage(""), 3000);
    } catch (error) {
      console.error("Erro ao adicionar usuário:", error);
    }
  };

  const handleSearch = (e) => {
    const term = e.target.value.toLowerCase();
    setSearchTerm(term);
    if (!term) {
      setFilteredUsers(users); // mostra todos se o campo estiver vazio
      return;
    }
    const filtered = users.filter((user) =>
      user.clientePosto?.toLowerCase().includes(term)
    );
    setFilteredUsers(filtered);
  };

  const deleteUser = async (userId) => {
    try {
      await api.delete(`/Clientes/${userId}`);
      const updatedUsers = users.filter((user) => user.clienteId !== userId);
      setUsers(updatedUsers);
      setFilteredUsers(updatedUsers);
      setSuccessMessage("Cliente excluído com sucesso!");
      setTimeout(() => setSuccessMessage(""), 3000);
    } catch (error) {
      console.error("Erro ao excluir usuário:", error);
    }
  };

  return (
    <motion.div
      className="bg-white text-gray-900 dark:bg-gray-800 dark:text-gray-100 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-2 sm:p-6 border border-gray-200 dark:border-gray-700"
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ delay: 0.2 }}
    >
      <div className="flex flex-col sm:flex-row sm:justify-between sm:items-center mb-6 gap-4">
        <h2 className="text-lg sm:text-xl font-semibold text-gray-100">
          Clientes
        </h2>
        <button
          className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors w-full sm:w-auto"
          onClick={openAddForm}
        >
          Adicionar Cliente
        </button>

        <div className="relative w-full sm:w-64">
          <input
            type="text"
            placeholder="Buscar Clientes..."
            className="bg-gray-700 text-white placeholder-gray-400 rounded-lg pl-10 pr-4 py-2 w-full focus:outline-none focus:ring-2 focus:ring-blue-500"
            value={searchTerm}
            onChange={handleSearch}
          />
          <Search className="absolute left-3 top-2.5 text-gray-400" size={18} />
        </div>
      </div>

      {successMessage && (
        <motion.div className="mb-4 p-4 bg-green-600 text-white rounded-lg text-center text-sm sm:text-base">
          {successMessage}
        </motion.div>
      )}

      {selectedUser && (
        <motion.div
          className="fixed inset-0 z-50 flex items-center justify-center bg-gray-800 bg-opacity-80 p-2"
          initial={{ opacity: 0 }}
          animate={{ opacity: 1 }}
        >
          <div className="bg-gray-900 rounded-lg p-4 sm:p-8 shadow-lg relative w-full max-w-xs sm:max-w-md">
            <button
              className="absolute top-2 right-2 text-gray-400 hover:text-gray-200"
              onClick={() => setSelectedUser(null)}
              title="Fechar"
            >
              <X size={20} />
            </button>
            <h3 className="text-lg sm:text-xl font-bold text-white mb-">
              Detalhes do Cliente
            </h3>
            <div className="space-y-2 text-gray-200 text-sm sm:text-base">
              <div>
                <strong>Posto:</strong> {selectedUser.clientePosto}
              </div>
              <div>
                <strong>Responsável:</strong> {selectedUser.clienteResponsavel}
              </div>
              <div>
                <strong>Contato:</strong> {selectedUser.clienteContato}
              </div>
              <div>
                <strong>Função:</strong> {selectedUser.clienteFuncaoResponsavel}
              </div>
              <div>
                <strong>Endereço:</strong> {selectedUser.clienteEndereco}
              </div>
              <div>
                <strong>Bairro:</strong> {selectedUser.clienteBairro}
              </div>
              <div>
                <strong>Funções Terceirizadas:</strong>{" "}
                {selectedUser.clienteFuncoesTerceirizadasId}
              </div>
            </div>
            <div className="flex flex-col sm:flex-row gap-2 sm:gap-4 mt-6">
              <button
                className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 w-full sm:w-auto"
                onClick={() => {
                  openEditForm(selectedUser);
                  setSelectedUser(null);
                }}
              >
                Editar
              </button>
              <button
                className="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700 w-full sm:w-auto"
                onClick={() => {
                  deleteUser(selectedUser.clienteId);
                  setSelectedUser(null);
                }}
              >
                Excluir
              </button>
            </div>
          </div>
        </motion.div>
      )}

      <div className="overflow-x-auto">
        <table className="min-w-full divide-y divide-gray-200 dark:divide-gray-700 text-xs sm:text-sm">
          <thead>
            <tr>
              <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider">
                Posto
              </th>
              <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider">
                Responsável
              </th>
              <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider">
                Contato
              </th>
              <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider">
                Função
              </th>
              <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider">
                Endereço
              </th>
              <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider">
                Bairro
              </th>
              <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider">
                Funções Terceirizadas
              </th>
              <th className="px-2 sm:px-6 py-3 text-left font-medium text-gray-600 dark:text-gray-400 uppercase tracking-wider">
                Ações
              </th>
            </tr>
          </thead>
          <tbody className="divide-y divide-gray-200 dark:divide-gray-700">
            {Array.isArray(filteredUsers) &&
              filteredUsers.map((user) => (
                <motion.tr
                  key={user.clientePosto}
                  initial={{ opacity: 0 }}
                  animate={{ opacity: 1 }}
                  transition={{ duration: 0.3 }}
                  className="hover:bg-gray-100 dark:hover:bg-gray-700 transition-colors cursor-pointer"
                  onClick={() => setSelectedUser(user)}
                >
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    <div className="flex items-center">
                      <div className="flex-shrink-0 h-8 w-8 sm:h-10 sm:w-10">
                        <div className="h-8 w-8 sm:h-10 sm:w-10 rounded-full bg-gradient-to-r from-purple-400 to-blue-500 flex items-center justify-center text-white font-semibold">
                          {(user?.clientePosto || "?").charAt(0)}
                        </div>
                      </div>
                      <div className="ml-2 sm:ml-4">
                        <div className="text-xs sm:text-sm font-medium">
                          {user.clientePosto}
                        </div>
                      </div>
                    </div>
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    <div className="text-xs sm:text-sm">
                      {user.clienteResponsavel}
                    </div>
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    <div className="text-xs sm:text-sm">
                      {user.clienteContato}
                    </div>
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    <span className="px-2 inline-flex text-xs leading-5 font-semibold rounded-full bg-blue-800 text-blue-100">
                      {user.clienteFuncaoResponsavel}
                    </span>
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    <div className="text-xs sm:text-sm">
                      {user.clienteEndereco}
                    </div>
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    <div className="text-xs sm:text-sm">
                      {user.clienteBairro}
                    </div>
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap">
                    <div className="text-xs sm:text-sm">
                      {user.clienteFuncoesTerceirizadasId}
                    </div>
                  </td>
                  <td className="px-2 sm:px-6 py-4 whitespace-nowrap text-xs sm:text-sm">
                    <button
                      type="button"
                      className="text-indigo-600 dark:text-indigo-400 hover:text-indigo-400 dark:hover:text-indigo-300 mr-2"
                      onClick={(e) => {
                        e.stopPropagation();
                        openEditForm(user);
                      }}
                    >
                      Editar
                    </button>
                    <button
                      type="button"
                      className="text-red-600 dark:text-red-400 hover:text-red-400 dark:hover:text-red-300"
                      onClick={(e) => {
                        e.stopPropagation();
                        deleteUser(user.clienteId);
                      }}
                    >
                      Excluir
                    </button>
                  </td>
                </motion.tr>
              ))}
          </tbody>
        </table>
        {showForm && (
          <motion.div
            className="fixed inset-0 z-50 flex items-center justify-center bg-gray-900 bg-opacity-70 backdrop-blur-md p-4"
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            transition={{ duration: 0.3 }}
          >
            <div className="relative bg-white dark:bg-gray-800 rounded-xl shadow-xl w-full max-w-lg max-h-[90vh] overflow-y-auto p-6">
              <button
                className="absolute top-3 right-3 text-gray-400 hover:text-gray-200"
                onClick={openCloseForm}
              >
                <X size={22} />
              </button>

              <h2 className="text-lg sm:text-xl font-semibold text-gray-900 dark:text-white mb-6">
                {editUserId ? "Editar Cliente" : "Adicionar Cliente"}
              </h2>

              <div className="space-y-4">
                <div>
                  <label className="block text-sm font-medium text-gray-300">
                    Posto
                  </label>
                  <input
                    type="text"
                    name="clientePosto"
                    value={newUser.clientePosto}
                    onChange={handleChange}
                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">
                    Responsável
                  </label>
                  <input
                    type="text"
                    name="clienteResponsavel"
                    value={newUser.clienteResponsavel}
                    onChange={handleChange}
                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">
                    Contato
                  </label>
                  <input
                    type="text"
                    name="clienteContato"
                    value={newUser.clienteContato}
                    onChange={handleChange}
                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">
                    Função
                  </label>
                  <select
                    name="clienteFuncaoResponsavel"
                    value={newUser.clienteFuncaoResponsavel}
                    onChange={handleChange}
                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  >
                    <option value="" disabled>
                      Selecione uma função
                    </option>
                    <option value="Gerente">Gerente</option>
                    <option value="Síndico">Síndico</option>
                    <option value="Síndica">Síndica</option>
                  </select>
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">
                    Endereço
                  </label>
                  <input
                    type="text"
                    name="clienteEndereco"
                    value={newUser.clienteEndereco}
                    onChange={handleChange}
                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">
                    Bairro
                  </label>
                  <input
                    type="text"
                    name="clienteBairro"
                    value={newUser.clienteBairro}
                    onChange={handleChange}
                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">
                    Observações Gerais
                  </label>
                  <input
                    type="text"
                    name="clienteObservacao"
                    value={newUser.clienteObservacao}
                    onChange={handleChange}
                    className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-300">
                    Funções Terceirizadas
                  </label>
                  <FuncoesTerceirizadasSelect
                    value={newUser.clienteFuncoesTerceirizadasId}
                    onChange={(id) =>
                      setNewUser((prev) => ({
                        ...prev,
                        clienteFuncoesTerceirizadasId: id,
                      }))
                    }
                  />
                </div>
              </div>

              <div className="mt-6 flex flex-col sm:flex-row justify-end gap-3">
                {editUserId ? (
                  <button
                    type="button"
                    className="w-full sm:w-auto bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700 transition-colors"
                    onClick={updateUser}
                  >
                    Atualizar
                  </button>
                ) : (
                  <button
                    className="w-full sm:w-auto bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors"
                    onClick={() => {
                      addUser();
                      setNewUser({
                        clientePosto: "",
                        clienteResponsavel: "",
                        clienteContato: "",
                        clienteFuncaoResponsavel: "",
                        clienteEndereco: "",
                        clienteBairro: "",
                        clienteObservacao: "",
                        clienteFuncoesTerceirizadasId: "",
                      });
                    }}
                  >
                    Adicionar
                  </button>
                )}
                <button
                  className="w-full sm:w-auto bg-red-600 text-white px-4 py-2 rounded-lg hover:bg-red-700 transition-colors"
                  onClick={openCloseForm}
                >
                  Cancelar
                </button>
              </div>
            </div>
          </motion.div>
        )}
      </div>
    </motion.div>
  );
}

export default UsersTable;
