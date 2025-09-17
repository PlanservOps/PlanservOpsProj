import React from 'react'
import Header from '../../components/common/Header'
import CleaningChecklist from '../../components/checklistComponent/Checklist'

const ChecklistPage = () => {
    return (
        <div className="flex-1 overflow-auto relative z-10">
            <Header title="Supervisão de Limpeza" />            
            <div className="p-4">
                <CleaningChecklist />
            </div>
        </div>
        
    )
}

export default ChecklistPage