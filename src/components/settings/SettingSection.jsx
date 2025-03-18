import { motion } from "framer-motion"

const SettingSection = (icon:Icon, title, children) => {
  return (
    <motion.div
    className='bg-gray-800 bg-opacity-50 backdrop-filter backdrop-blur-lg shadow-lg rounded-xl p-6 border border-gray-700 mb-8'
    initial={{ opacity: 0, y: 20 }}
    animate={{ opacity: 1, y: 0 }}
    transition={{ duration: 0.5 }}
    >
        
    </motion.div>
  )
}

export default SettingSection