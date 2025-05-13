import { motion } from 'framer-motion'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import Logo from '../../assets/images/Logo nobg.png'

const Login = () => {
	const navigate = useNavigate();

    const [newLeadAccess, setNewLeadAccess] = useState(
        {
            leadEmail: "",
            leadPassword: ""
        }
    )
    const handleInput = (e) => {
        const { name, value } = e.target
        setNewLeadAccess({ ...newLeadAccess, [name]: value })
    };

	const handleLogin = () => {
		if (!newLeadAccess.leadEmail || !newLeadAccess.leadPassword) {
			alert("Preencha todos os campos")
			return
		}
		const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
		if (!emailRegex.test(newLeadAccess.leadEmail)) {
			alert("E-mail inválido")
			return
		}
		
			if (
				newLeadAccess.leadEmail === "planservacesso@planserv.com" &&
				newLeadAccess.leadPassword === "planserv1234"
	
			) {
				navigate("/Home");
			} else {
				alert("E-mail ou senha inválidos");
				}
	}

	const handleKeyDown = (e) => {
        if (e.key === "Enter") {
            handleLogin();
        }
    };
		
	console.log("Enviando dados de login:", newLeadAccess)

  return (
    <motion.div
	style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', minHeight: '100vh' }}>
        <div className="form-register bg-gray-700 p-6 rounded-lg shadow-lg w-full max-w-md mx-auto">
					<img src={Logo} alt='logo'/>
					
					<div className="space-y-4">
						<div>
							<label className="block text-sm font-medium text-gray-300">E-mail</label>
							<input
								type="text"
								name="leadEmail"
								value={newLeadAccess.leadEmail}
								onChange={handleInput}
								onKeyDown={handleKeyDown}
								className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
							/>
						</div>
						<div>
							<label className="block text-sm font-medium text-gray-300">Senha</label>
							<input
								type="password"
								name="leadPassword"
								value={newLeadAccess.leadPassword}
								onChange={handleInput}
								onKeyDown={handleKeyDown}
								className="w-full px-4 py-2 rounded-lg bg-gray-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
							/>
						</div>			
					</div>
			
					<div className="mt-6 flex justify-end space-x-4">
						<button
							className='bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700 transition-colors'
							onClick={handleLogin}
						>
							Entrar
						</button>						
					</div> 
				</div>
    </motion.div>    
)
}

export default Login