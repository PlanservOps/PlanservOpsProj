import { motion } from 'framer-motion'
import { useState } from 'react'
import api from '../../api'
import { useNavigate } from 'react-router-dom'
import Logo from '../../assets/images/Logo nobg.png'

const Login = () => {
	  	const [form, setForm] = useState({ email: "", senha: "" });
  		const [error, setError] = useState("");
  		const navigate = useNavigate();

     	const handleChange = (e) => {
    		setForm({ ...form, [e.target.name]: e.target.value });
  			};

  		const handleSubmit = async (e) => {
    		e.preventDefault();
    		setError("");
			try {
			const res = await api.post("/profile/login", {
				email: form.email,
				password: form.senha,
			});
			// Salve o token JWT (exemplo: localStorage)
			localStorage.setItem("token", res.data.token);
			// Redirecione para a página principal
			navigate("/Home");
			} catch (err) {
			setError("E-mail ou senha inválidos.");
			}
		};

	const handleKeyDown = (e) => {
        if (e.key === "Enter") {
            handleLogin();
        }
    };
		

  return (
    <motion.div
	style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', minHeight: '100vh' }}>
        <div className="form-register bg-gray-700 p-6 rounded-lg shadow-lg w-full max-w-md mx-auto">
					<img src={Logo} alt='logo'/>
					
					<form onSubmit={handleSubmit} className="space-y-5">
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
							name="senha"
							value={form.senha}
							onChange={handleChange}
							required
							className="w-full px-3 py-2 bg-gray-800 text-gray-100 border border-gray-700 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
						/>
						</div>
						<button
						type="submit"
						className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700 transition font-semibold shadow"
						>
						Entrar
						</button>
						{error && <div className="text-red-400 mt-2">{error}</div>}
					</form>
				</div>
    </motion.div>    
)
}

export default Login