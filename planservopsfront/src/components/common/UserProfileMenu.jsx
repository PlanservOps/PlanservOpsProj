import React, { useState, useRef, useEffect } from 'react';
import { User } from 'lucide-react';
import { useNavigate } from 'react-router-dom';

const UserProfileMenu = ({ user, onLogout }) => {
  const [open, setOpen] = useState(false);
  const menuRef = useRef(null);
  const navigate = useNavigate();

  // Fecha o menu ao clicar fora
  useEffect(() => {
    const handleClickOutside = (event) => {
      if (menuRef.current && !menuRef.current.contains(event.target)) {
        setOpen(false);
      }
    };
    document.addEventListener('mousedown', handleClickOutside);
    return () => document.removeEventListener('mousedown', handleClickOutside);
  }, []);

  const handleLogout = () => {
    setOpen(false);
    if (onLogout) onLogout();
    navigate('/');
  };

  return (
    <div className="relative" ref={menuRef}>
      <button
        className="flex items-center px-3 py-2 rounded hover:bg-gray-200 transition"
        onClick={() => setOpen((prev) => !prev)}
      >
        <User size={24} />
        <span className="ml-2">{user?.profileName || 'Usuário'}</span>
      </button>
      {open && (
        <div className="absolute right-0 mt-2 w-48 bg-white border rounded shadow-lg z-60">
            <div className="px-4 py-2 text-gray-700 border-b">{user?.profileName || 'Perfil desconhecido'}</div>
            <button
            className="w-full text-left px-4 py-2 hover:bg-gray-100 text-red-600"
            onClick={handleLogout}
            >
            Logout
            </button>
        </div>
        )}
    </div>
  );
};

export default UserProfileMenu;