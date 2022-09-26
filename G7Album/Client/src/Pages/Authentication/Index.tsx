import { useEffect } from "react";
import { FormLogin } from "./Components/FormLogin/FormLogin";
import { FormRegister } from "./Components/FormRegister/FormRegister";
import { MessageLogin } from "./Components/MessageLogin/MessageLogin";
import { MessageRegister } from "./Components/MessageRegister/MessageRegister";
import { useAuth } from "./Context/useAuth";
import AuthCSS from "./Index.module.css"
import AuthService from "./Services/Auth.services";


export const Authentication : React.FC = () => {


    /// HOOKS
    const storeAuth = useAuth()


    /// METODOS
    const probandoConexion = async () => {

        const asd = await AuthService.Register({
            Email: "OKAOKA@gmail.com",
            NombreCompleto: "Esteban Quito",
            Password: "holahola123",
            ConfirmPassword: "holahola123"
        })
        console.log("🚀 ~ file: Index.tsx ~ line 27 ~ probandoConexion ~ asd", asd)
    }

    useEffect(()=>{
        //probandoConexion();
        storeAuth.ChangeClassCssForm();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <main className={AuthCSS.mainAuthentication}>
            <div className={AuthCSS.containerPage}>
                <section className={AuthCSS["containerPage__Background"]}>                
                    <MessageLogin/>

                    <MessageRegister/>
                </section>

               <section className={`
                    ${AuthCSS["containerPage__Auth"]} ${AuthCSS[storeAuth.GetClassCssFormModifed()]}
                `}>
                    <FormLogin />
                    
                    <FormRegister />
                </section>                                                                                                                           
            </div>
        </main>   
    )
}