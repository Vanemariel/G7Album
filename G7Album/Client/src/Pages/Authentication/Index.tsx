import { useEffect } from "react";


export const Authentication : React.FC = () => {

    const probandoConexion = async () => {

        const res = await fetch("https://localhost:7040/Api/Album/GetAll")

        const data = await res.json();
        console.log("🚀 ~ file: App.tsx ~ line 16 ~ probandoConexion ~ data", data)
    }

    useEffect(()=>{
        probandoConexion()
    }, [])

    return (
        <p>asd</p>
    )
}