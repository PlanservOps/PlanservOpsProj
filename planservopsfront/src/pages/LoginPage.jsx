import Login from '../components/leadsAccess/login'

const LoginPage = () => {    
    
  return ( 
        <main className='flex justify-center items-center w-screen min-h-screen bg-gray-900 background-image `Url(/src/assets/images/PlanservBgLogin.jpg)` background-cover background-center'>
            <div className='w-full max-w-md'>
                <Login />
            </div>
        </main>
    )
}

export default LoginPage