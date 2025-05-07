import React from 'react'

const InfoBanner = ({ message }) => {
    return (
        <div className="bg-yellow-500 text-black px-4 py-2 rounded-lg shadow-md mb-4">
            <p className="text-sm font-medium">{message || "Mudanças ainda estão em andamento nesta página. Fique atento às atualizações!"}</p>
        </div>
    );
};

export default InfoBanner;