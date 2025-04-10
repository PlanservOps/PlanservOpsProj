import Login from '../components/leadsAccess/login'

const LoginPage = () => {    
    
  return ( 
        <main className='flex items-center justify-center h-screen'>
            <div className='grid grid-cols-1 lg:grid-cols-2 gap-8'>
                <Login />
            </div>
        </main>
    )
}

export default LoginPage