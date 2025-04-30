import { useEffect, useState } from 'react';
import axiosInstance from '../lib/axiosInstance';

export const useFetchUsers = () => {
  const [users, setUsers] = useState([]);
  const [filteredUsers, setFilteredUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const { data } = await axiosInstance.get('/api'); 
        setUsers(data);
        setFilteredUsers(data);
      } catch (err) {
        setError(err);
      } finally {
        setLoading(false);
      }
    };

    fetchUsers();
  }, []);

  return { users, filteredUsers, setFilteredUsers, loading, error };
};
