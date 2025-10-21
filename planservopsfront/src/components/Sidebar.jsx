import {
  Menu,
  Users,
  ShieldAlert,
  MessageCircleWarning,
  ClipboardCheck,
  ChartLineIcon,
  Settings,
  AppWindow,
  BookCheck,
} from "lucide-react";
import { useState } from "react";
import { AnimatePresence, motion } from "framer-motion";
import { href, Link } from "react-router-dom";
import { getUserRole } from "../utils/auth";

const role = getUserRole();

const SIDEBAR_ITEMS = [
  { name: "Overview", icon: AppWindow, color: "#10B981", href: "/Home" },
  { name: "Clientes", icon: Users, color: "#10B981", href: "/Users" },
  {
    name: "Ocorrências",
    icon: ShieldAlert,
    color: "#10B981",
    href: "/Ocorrencias",
  },
  {
    name: "Reclamações",
    icon: MessageCircleWarning,
    color: "#10B981",
    href: "/Reclamacoes",
  },
  {
    name: "Supervisão de Limpeza",
    icon: ClipboardCheck,
    color: "#10B981",
    href: "/Checklist",
  },
  {
    name: "Acompanhamento Gerencial",
    icon: BookCheck,
    color: "#10B981",
    href: "/AcompanhamentoGerencialPage",
  },
  {
    name: "Configurações",
    icon: Settings,
    color: "#10B981",
    href: "/Settings",
  },
];

const Sidebar = () => {
  const [isSidebarOpen, setIsSidebarOpen] = useState(true);
  return (
    <motion.div
      className={`relative z-10 transition-all duration-300 ease-in-out flex-shrink-0 ${
        isSidebarOpen ? "w-64" : "w-20"
      }`}
      animate={{ width: isSidebarOpen ? 256 : 80 }}
    >
      <div className="h-full bg-gray-100 dark:bg-gray-800 text-gray-900 dark:text-gray-100 bg-opacity-50 backdrop-blur-md p-4 flex flex-col border-r border-gray-200 dark:border-gray-700">
        {role === "Diretoria" && (
          <Link to="/overview" className="text-gray-700 dark:text-gray-100 hover:text-blue-600 dark:hover:text-blue-400 transition">
            Dashboard
          </Link>
        )}
        {role === "AdministradorInterno" && (
          <Link to="/clientes" className="text-gray-700 dark:text-gray-100 hover:text-blue-600 dark:hover:text-blue-400 transition">
            Clientes
          </Link>
        )}
        {role === "Fiscal" && (
          <Link to="/checklist" className="text-gray-700 dark:text-gray-100 hover:text-blue-600 dark:hover:text-blue-400 transition">
            Checklist
          </Link>
        )}
        {/* Exemplo: mostrar para mais de um papel */}
        {["Diretoria", "AdministradorInterno"].includes(role) && (
          <Link to="/relatorios" className="text-gray-700 dark:text-gray-100 hover:text-blue-600 dark:hover:text-blue-400 transition">
            Relatórios
          </Link>
        )}

        <motion.button
          whileHover={{ scale: 1.1 }}
          whileTap={{ scale: 0.9 }}
          onClick={() => setIsSidebarOpen(!isSidebarOpen)}
          className="p-2 rounded-full hover:bg-gray-700 transition-colors max-w-fit"
        >
          <Menu size={24} />
        </motion.button>

        <nav className="mt-8 flex-grow">
          {SIDEBAR_ITEMS.map((item) => (
            <Link key={item.href} to={item.href}>
              <motion.div className="flex items-center p-4 text-sm font-medium rounded-lg hover:bg-gray-700 transition-colors mb-2">
                <item.icon
                  size={20}
                  style={{ color: item.color, minWidth: "20px" }}
                />

                <AnimatePresence>
                  {isSidebarOpen && (
                    <motion.span
                      className="ml-4 whitespace-nowrap"
                      initial={{ opacity: 0, width: 0 }}
                      animate={{ opacity: 1, width: "auto" }}
                      exit={{ opacity: 0, width: 0 }}
                      transition={{ duration: 0.2, delay: 0.3 }}
                    >
                      {item.name}
                    </motion.span>
                  )}
                </AnimatePresence>
              </motion.div>
            </Link>
          ))}
        </nav>
      </div>
    </motion.div>
  );
};
export default Sidebar;
