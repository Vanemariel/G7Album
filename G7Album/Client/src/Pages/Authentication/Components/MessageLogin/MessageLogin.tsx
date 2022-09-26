import React from "react";
import { useAuth } from "../../Context/useAuth";
import MessageLoginCSS from "./MessageLogin.module.css";



export const MessageLogin: React.FC = () => {


  /// HOOKS
  const storeAuth = useAuth()
  const { resetForm } = storeAuth.formularioRegister;

  /// METOODS
  const goToLogin = (): void => {
    storeAuth.SetLoginActive(true);
    storeAuth.SetRegisterActive(false);
    resetForm()
  }

  return (

      <article className={`
          ${MessageLoginCSS.containerBackgroundLogin} 
          ${storeAuth.IsLoginActive() ? MessageLoginCSS.noneElement : ""}
        `}
        style={storeAuth.IsRegisterActive() ? {"opacity": 1} : {"opacity": 0}}
      >

        <h3> ¿Ya tienes una cuenta?</h3>
        <p> Inicia sesion para entrar a la pagina</p>
        
        <button onClick={goToLogin}>
            Iniciar sesion
        </button>

      </article>
  );
};
