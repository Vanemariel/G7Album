import { useEffect } from "react";
import { FormLogin } from "./Components/FormLogin/FormLogin";
import { FormRegister } from "./Components/FormRegister/FormRegister";
import { MessageLogin } from "./Components/MessageLogin/MessageLogin";
import { MessageRegister } from "./Components/MessageRegister/MessageRegister";
import { AuthProvider } from "./Context/AuthProvider";
import { useAuth } from "./Context/useAuth";
import AuthCSS from "./Index.module.css"


export const Authentication : React.FC = () => {


    /// HOOKS
    const storeAuth = useAuth()


    /// METODOS
    const probandoConexion = async () => {

        const res = await fetch("https://localhost:7040/Api/Album/GetAll")

        const data = await res.json();
        console.log("🚀 ~ file: App.tsx ~ line 16 ~ probandoConexion ~ data", data)
    }

    useEffect(()=>{
        probandoConexion();
        storeAuth.ChangeClassCssForm();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (

        <AuthProvider>

            <main className={AuthCSS.mainAuthentication}>

                <div className={AuthCSS.containerPage}>

                    <section className={AuthCSS.containerPage__Background}>                

                        <MessageLogin/>

                        <MessageRegister/>

                    </section>

                    <section className={`${AuthCSS.containerPage__LoginAndRegister} ${storeAuth.GetClassCssFormModifed()}`}>

                        <FormLogin />
                        
                        <FormRegister />

                    </section>                                                                                                                           

                </div>

            </main>

        </AuthProvider>    
    )
}