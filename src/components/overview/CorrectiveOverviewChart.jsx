import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from "recharts";
import { motion } from "framer-motion";

const progressData = [
    { name: "Jul", progress: 40 },
    { name: "Aug", progress: 30 },
    { name: "Sep", progress: 25 },
    { name: "Oct", progress: 35 },
    { name: "Nov", progress: 12 },
    { name: "Dec", progress: 26 },
    { name: "Jan", progress: 26 },
    { name: "Feb", progress: 30 },
    { name: "Mar", progress: 25 },
    { name: "Apr", progress: 20 },
    { name: "May", progress: 18 },
    { name: "Jun", progress: 15 },
];

import React from 'react'

const CorrectiveOverviewChart = () => {
  return (
    <motion.div
    className='bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700'
    initial={{ opacity: 0, y: 20 }}
    animate={{ opacity: 1, y: 0 }}
    transition={{ delay: 0.2 }}
    >
        <h2
            className='text-lg font-medium mb-4 text-gray-100'
        >Visitas Corretivas</h2>

        <div className="h-80">
            <ResponsiveContainer width={"100%"} height={"100%"}>
                <LineChart data={progressData}>
                    <CartesianGrid strokeDasharray='3 3' stroke='#4b5563'/>
                    <XAxis dataKey={"name"} stroke="#9ca3af"/>
                    <YAxis stroke="#9ca3af"/>
                    <Tooltip
                        contentStyle={{
                            backgroundColor: "rgba(31, 41, 55, 0.8)",
                            borderColor: "#4B5563",
                        }}
                        itemStyle={{ color: "#E5E7EB" }}
                    />
                        <Line
                            type='monotone'
                            dataKey='progress'
                            stroke='#10B981'
                            strokeWidth={3}
                            dot={{ fill: "#10B981", strokeWidth: 2, r: 6 }}
                            activeDot={{ r: 8, strokeWidth: 2 }}
                        />    
                </LineChart>
            </ResponsiveContainer>
        </div>
    </motion.div>
  )
}

export default CorrectiveOverviewChart