import Login from '../components/leadsAccess/Login'

const LoginPage = () => {    
    
  return ( 
        <main className='flex justify-center items-center w-screen min-h-screen bg-gray-900 background-image `Url(/src/assets/images/bgLoginTemplate.jpg)` background-cover background-center'>
            <div className='w-full max-w-md'>
                <Login />
            </div>
        </main>
    )
}

export default LoginPage