import Login from '../components/leadsAccess/Login'

const LoginPage = () => {    
    
  return ( 
        <main className='flex justify-center items-center w-screen min-h-screen bg-[url(/src/assets/images/bgLoginTemplate.jpg)] bg-cover bg-center'>
            <div className='w-full max-w-md bg-trasparent'>
                <Login />
            </div>
        </main>
    )
}

export default LoginPage