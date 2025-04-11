import { motion } from 'framer-motion'
import React from 'react'
import { useState } from 'react'

const Login = () => {

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
	}

	const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
	if (!emailRegex.test(newLeadAccess.leadEmail)) {
		alert("E-mail inválido")
		return
	}
	
	console.log("Enviando dados de login:", newLeadAccess)

  return (
    <motion.div
        className='flex-1 overflow-auto relative z-10'
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 1 }}
    >
        <div className="form-register bg-gray-700 p-6 rounded-lg shadow-lg w-full max-w-md">
					<h2 className="text-xl font-semibold text-white mb-4">Login</h2>
					
					<div className="space-y-4">
						<div>
							<label className="block text-sm font-medium text-gray-300">E-mail</label>
							<input
								type="text"
								name="leadEmail"
								value={newLeadAccess.leadEmail}
								onChange={handleInput}
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