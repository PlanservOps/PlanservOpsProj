import React from 'react'
import Logo from '../../assets/images/Logo nobg.png'
import UserProfileMenu from './UserProfileMenu';

const Header = ({ title, user, handleLogout }) => {
  return (
    <header
        className='flex items-center justify-between px-6 bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg border-b border-gray-700'
    >
        <div className='flex-1 max-w-7xl mx-auto py-4 px-4 sm:px-6 lg:px-8'>
            <img src={Logo} alt='logo' className='h-10 w-auto'/>
            <h1 className='text-2xl font-semibold text-gray-100'>{title}</h1>
        </div>
        <UserProfileMenu user={user} onLogout={handleLogout} />
    </header>

);
}

export default Header