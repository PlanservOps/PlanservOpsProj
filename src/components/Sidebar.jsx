import { BarChart2 } from "lucide-react"
import { useState } from "react"
import { motion } from "framer-motion"

const SIDEBAR_ITEMS = [
    {
        name:"Overview", icon:BarChart2, color:"#6366f1", path:"/"
    },
    {name: "NPS", icon:BarChart2, color:"#f43f5e", path:"/Nps"},
    {name: "Odds", icon:BarChart2, color:"#10b981", path:"/Odds"},
    {name: "Complaint", icon:BarChart2, color:"#3b82f6", path:"/Complaint"},
    {name: "Feedback", icon:BarChart2, color:"#f59e0b", path:"/Feedback"},
    {name: "Clients", icon:BarChart2, color:"#ef4444", path:"/Clients"},
    {name: "Search", icon:BarChart2, color:"#6366f1", path:"/Search"},
]
const Sidebar = () => {
    const [isSidebarOpen, setIsSidebarOpen] = useState(true)
  return (
    <motion.div
    className={`relative z-10 transition-all duration-300 ease-in-out flex-shrink-0 ${isSidebarOpen ? 'w-64' : 'w-20'}`}
    animate={{width: isSidebarOpen ? 256 : 80}}
    >
        <div className='h-full bg-gray-800 bg-opacity-50 backdrop-blur-md p-4 flex flex-col border-r border-gray-700'>
            <motion.button
            whileHover={{scale: 1.1}}
            whileTap={{scale: 0.9}}
            onClick={() => setIsSidebarOpen(!isSidebarOpen)}
            className='p-2 rounded-full hover-bg-gray-700 transition-colors max-w-fit'
            >
                <Menu size={24}/>

            </motion.button>
            
        </div>          
    </motion.div>
)
};
export default Sidebar;