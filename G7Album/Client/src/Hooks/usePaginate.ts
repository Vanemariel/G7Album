import { useState } from "react"

export const usePaginate = () => {

    const [paginate, setPaginate] = useState({
        currentPage: 0,
        pagesTotal: 0
    }) 


    return {
        paginate, 
        setPaginate
    }
}