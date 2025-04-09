import React from 'react'
import Login from '../components/leadsAccess/login'

const LoginPage = () => {
  return (
    <div className='flex-1 overflow-auto relative z-10'>
      <Login title="login" />

        <main className='max-w-7xl mx-auto py-6 px-4 lg:px-8'>
            <div className='grid grid-cols-1 lg:grid-cols-2 gap-8'>
                <Login />
            </div>
        </main>
    </div>
  )
}

export default LoginPage