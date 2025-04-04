import { useState, useEffect } from "react";
import { motion } from "framer-motion";
import { Search } from "lucide-react";

/*const userData = [
	{ id: 1, post: "Arvoredo", name: "John Doe", phone: "(46) 3357-0215", role: "Síndica", address: "Rua Salvador Turati", hood: "Conjunto Habitacional Monsenhor João Batista Toffoli", outsourced:"" },
	{ id: 2, post: "Imperial Bessa", name: "Jane Smith", phone: "(83) 3255-4234m", role: "Gerente", address: "Rua Carlos Roberto Goldoni", hood: "Jardim Unesp", outsourced:"" },
	{ id: 3, post: "Luxor Oceano", name: "Bob Johnson", phone: "(61) 2340-4836", role: "Síndico", address: "Rua Florindo Cibin", hood: "São Jerônimo", outsourced:"" },
	{ id: 4, post: "Vert House", name: "Alice Brown", phone: "(66) 2759-6562", role: "Síndica", address: "Rua Wilson Vicente Guidugli", hood: "Jardim Gimenez", outsourced:"" },
	{ id: 5, post: "ASSIF", name: "Charlie Wilson", phone: "(95) 3788-8555", role: "Gerente", address: "Rua Aparecido Gomes", hood: "Jardim Adélia II", outsourced:"" },
];*/

function UsersTable() {

	const baseUrl = "https://localhost:44355/api/Clientes";

	const [searchTerm, setSearchTerm] = useState("");
	const [users, setUsers] = useState([]); // Lista original de usuários
	const [filteredUsers, setFilteredUsers] = useState([]); // Lista filtrada

	useEffect(() => {
		const fetchUsers = async () => {
			try {
				const response = await fetch(baseUrl);
				if (!response.ok) {
					throw new Error(`Erro: ${response.status} - ${response.statusText}`);
				}
				const data = await response.json();
				setUsers(data);
				setFilteredUsers(data);
			} catch (error) {
				console.error("Erro ao buscar usuários:", error);
			}
		};
		fetchUsers();
	}, []);

	const handleSearch = (e) => {
		const term = e.target.value.toLowerCase();
		setSearchTerm(term);
		const filtered = users.filter(
			(user) => user.post.toLowerCase().includes(term) ||
				user.name.toLowerCase().includes(term) ||
				user.phone.toLowerCase().includes(term)
		);
		setFilteredUsers(filtered);
	};

	return (
		<motion.div
			className='bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700'
			initial={{ opacity: 0, y: 20 }}
			animate={{ opacity: 1, y: 0 }}
			transition={{ delay: 0.2 }}
		>
			<div className='flex justify-between items-center mb-6'>
				<h2 className='text-xl font-semibold text-gray-100'>Clientes</h2>
				<button className=' bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors'>Adicionar Cliente</button>
				<div className='relative'>
					<input
						type='text'
						placeholder='Buscar Clientes...'
						className='bg-gray-700 text-white placeholder-gray-400 rounded-lg pl-10 pr-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500'
						value={searchTerm}
						onChange={handleSearch} />
					<Search className='absolute left-3 top-2.5 text-gray-400' size={18} />
				</div>
			</div>

			<div className='overflow-x-auto'>
				<table className='min-w-full divide-y divide-gray-700'>
					<thead>
						<tr>
							<th className='px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider'>
								Posto
							</th>
							<th className='px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider'>
								Responsável
							</th>
							<th className='px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider'>
								Contato
							</th>
							<th className='px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider'>
								Função
							</th>
							<th className='px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider'>
								Endereço
							</th>
							<th className='px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider'>
								Bairro
							</th>
							<th className='px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider'>
								Funções Terceirizadas
							</th>
							<th className='px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider'>
								Ações
							</th>
						</tr>
					</thead>

					<tbody className='divide-y divide-gray-700'>
						{filteredUsers.map((user) => (
							<motion.tr
								key={user.clienteId}
								initial={{ opacity: 0 }}
								animate={{ opacity: 1 }}
								transition={{ duration: 0.3 }}
							>
								<td className='px-6 py-4 whitespace-nowrap'>
									<div className='flex items-center'>
										<div className='flex-shrink-0 h-10 w-10'>
											<div className='h-10 w-10 rounded-full bg-gradient-to-r from-purple-400 to-blue-500 flex items-center justify-center text-white font-semibold'>
												{user.clientePosto.charAt(0)}
											</div>
										</div>
										<div className='ml-4'>
											<div className='text-sm font-medium text-gray-100'>{user.clientePosto}</div>
										</div>
									</div>
								</td>
								<td className='px-6 py-4 whitespace-nowrap'>
									<div className='text-sm text-gray-300'>{user.clienteResponsavel}</div>
								</td>
								<td className='px-6 py-4 whitespace-nowrap'>
									<div className='text-sm text-gray-300'>{user.clienteContato}</div>
								</td>

								<td className='px-6 py-4 whitespace-nowrap'>
									<span className='px-2 inline-flex text-xs leading-5 font-semibold rounded-full bg-blue-800 text-blue-100'>
										{user.clienteFuncaoResponsavel}
									</span>
								</td>
								<td className='px-6 py-4 whitespace-nowrap'>
									<div className='text-sm text-gray-300'>{user.clienteEndereco}</div>
								</td>
								<td className='px-6 py-4 whitespace-nowrap'>
									<div className='text-sm text-gray-300'>{user.clienteBairro}</div>
								</td>
								<td className='px-6 py-4 whitespace-nowrap'>
									<div className='text-sm text-gray-300'>{user.clienteFuncoesTerceirizadas}</div>
								</td>

								<td className='px-6 py-4 whitespace-nowrap text-sm text-gray-300'>
									<button className='text-indigo-400 hover:text-indigo-300 mr-2'>Edit</button>
									<button className='text-red-400 hover:text-red-300'>Delete</button>
								</td>

							</motion.tr>
						))}
					</tbody>
				</table>
			</div>
		</motion.div>
	);
}

export default UsersTable