import React from "react";
import Header from "../../components/common/Header";
import { motion } from "framer-motion";
import StatsCards from "../../components/common/StatsCards";
import {
  BarChart2,
  BellPlus,
  TriangleAlert,
  ShieldAlert,
} from "lucide-react";
import PreventiveOverviewChart from "../../components/overview/PreventiveOverviewChart";
import IndexNpsChart from "../../components/overview/IndexNpsChart";
import CorrectiveOverviewChart from "../../components/overview/CorrectiveOverviewChart";

const OverviewPage = () => {
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
            name="Índice de Atendimento"
            icon={BarChart2}
            value="60.5%"
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
