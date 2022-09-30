import { useEffect } from "react";


export const Authentication : React.FC = () => {

    const probandoConexion = async () => {

        const res = await fetch("https://localhost:7040/Api/Album/GetAll")


    /// METODOS
    useEffect(()=>{
        probandoConexion()
    }, [])

    return (
        <p>asd</p>
    )
}