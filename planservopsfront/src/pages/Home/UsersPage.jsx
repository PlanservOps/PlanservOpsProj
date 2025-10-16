import React, { useState, useEffect } from "react";
import Header from "../../components/common/Header";
import { motion } from "framer-motion";
import StatsCards from "../../components/common/StatsCards";
import { UserCheck, UserPlus, UsersIcon, UserX } from "lucide-react";
import UsersTable from "../../components/tables/UsersTable";
import api from "../../api";

const UsersPage = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await api.get("/Clientes");
        setUsers(response.data);
      } catch (error) {
        setUsers([]);
      } finally {
        setLoading(false);
      }
    };
    fetchUsers();
  }, []);

  const totalUsers = users.length;

  const now = new Date();
  const currentMonth = now.getMonth();
  const currentYear = now.getFullYear();
  const newUsersThisMonth = users.filter((u) => {
    if (!u.createdAt) return false;
    const createdDate = new Date(u.createdAt);
    return (
      createdDate.getMonth() === currentMonth &&
      createdDate.getFullYear() === currentYear
    );
  }).length;

  return (
    <div className="flex-1 overflow-auto relative z-10 bg-white text-gray-900 dark:bg-gray-900 dark:text-gray-100 transition-colors">
      <Header title="Clientes" />

      <main className="max-w-7xl mx-auto py-6 px-4 lg:px-8">
        {/* STATS */}
        <motion.div
          className="grid grid-cols-1 gap-5 sm:grid-cols-2 lg:grid-cols-4 mb-8"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 1 }}
        >
          <StatsCards
            name="Clientes Total"
            icon={UsersIcon}
            value={loading ? "..." : totalUsers}
            color="#6366F1"
          />
          <StatsCards
            name="Novos Clientes"
            icon={UserPlus}
            value={loading ? "..." : newUsersThisMonth}
            color="#10B981"
          />
          <StatsCards
            name="Clientes Ativos"
            icon={UserCheck}
            value={"?"}
            color="#F59E0B"
          />
          <StatsCards
            name="Distratos"
            icon={UserX}
            value={"?"}
            color="#EF4444"
          />
        </motion.div>

        <UsersTable users={users} loading={loading} />
      </main>
    </div>
  );
};

export default UsersPage;
