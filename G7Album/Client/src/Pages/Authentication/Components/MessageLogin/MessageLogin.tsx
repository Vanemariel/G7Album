import React from "react";
import MessageLoginCSS from "./MessageLogin.module.css";



export const MessageLogin: React.FC = () => {

  const store : any = undefined;


  const goToLogin = (): void => {
    store.SetLoginActive(true);
    store.SetRegisterActive(false);
    store.ResetFormRegister();
  }


  return (

      <article className={`
          ${MessageLoginCSS.containerBackgroundLogin} 
          ${store.IsLoginActive() ? MessageLoginCSS.noneElement : ""}
        `}
        // style={{store.IsRegisterActive() ? "opacity: 1" : "opacity: 0"}}
      >

        <h3> ¿Ya tienes una cuenta?</h3>
        <p> Inicia sesion para entrar a la pagina</p>
        
        <button onClick={goToLogin}>
            Iniciar sesion
        </button>

      </article>
  );
};
