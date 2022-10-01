import { useEffect } from "react";
import { FormLogin } from "./Components/FormLogin/FormLogin";
import { FormRegister } from "./Components/FormRegister/FormRegister";
import { MessageLogin } from "./Components/MessageLogin/MessageLogin";
import { MessageRegister } from "./Components/MessageRegister/MessageRegister";
import { useAuth } from "./Context/useAuth";
import AuthCSS from "./Index.module.css"


export const Authentication: React.FC = () => {


    /// HOOKS
    const storeAuth = useAuth()


    /// METODOS
    useEffect(()=>{
        storeAuth.ChangeClassCssForm();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <main className={AuthCSS.mainAuthentication}>
            <div className={AuthCSS.containerPage}>
                <section className={AuthCSS["containerPage__Background"]}>
                    <MessageLogin />

                    <MessageRegister />
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