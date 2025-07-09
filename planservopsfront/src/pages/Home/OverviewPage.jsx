import React, {useState, useEffect} from "react";
import Header from "../../components/common/Header";
import { motion } from "framer-motion";
import StatsCards from "../../components/common/StatsCards";
import {
  UsersIcon,
  BellPlus,
  TriangleAlert,
  ShieldAlert,
} from "lucide-react";
import PreventiveOverviewChart from "../../components/overview/PreventiveOverviewChart";
import IndexNpsChart from "../../components/overview/IndexNpsChart";
import CorrectiveOverviewChart from "../../components/overview/CorrectiveOverviewChart";
import api from "../../api";

const OverviewPage = () => {

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

  return (
    <div className="flex-1 overflow-auto relative z-10">
      <Header title="Overview" />

      <main className="max-w-7xl mx-auto py-6 px-4 lg:px-8">
        {/* STATS */}

        <motion.div
          className="grid grid-cols-1 gap-5 sm:grid-cols-2 lg:grid-cols-4 mb-8"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 1 }}
        >
          <StatsCards
            name="Novas Ocorrências"
            icon={BellPlus}
            value="10"
            color="#8B5CF6"
          />
          <StatsCards
            name="Não Atendidas"
            icon={TriangleAlert}
            value="8"
            color="#EC4899"
          />
          <StatsCards
            name="Clientes"
            icon={UsersIcon}
            value={loading ? "..." : totalUsers}
            color="#10B981"
          />
          <StatsCards
            name="Reclamações"
            icon={ShieldAlert}
            value="5"
            color="#FF0000"
          />
        </motion.div>

        {/* CHARTS */}

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
          <PreventiveOverviewChart />
          <CorrectiveOverviewChart />
          <IndexNpsChart />
        </div>
      </main>
    </div>
  );
};

export default OverviewPage;
