 import React from "react";
import LoginAndRegisterCSS from "../../LoginAndRegister.module.css";

interface Props {
  loginActive: boolean;
  registerActive: boolean;
  setLoginActive: any;
  setRegisterActive: any;
  resetLogin: any;
}

export const MessageRegister: React.FC<Props> = (props) => {
  const {
    loginActive,
    registerActive,
    resetLogin,
    setLoginActive,
    setRegisterActive,
  } = props;

  /// VARIABLES cSS

  const styleMessageRegister = ` 
    ${LoginAndRegisterCSS.containerBackground__register} 
    ${registerActive ? LoginAndRegisterCSS.noneElement : undefined}
  `;

  return (
    <article
      className={styleMessageRegister}
      style={loginActive ? { opacity: "1" } : { opacity: "0" }}
    >
      <h3>¿Aun no tienes una cuenta?</h3>
      <p>Registrate para que puedas iniciar sesion</p>
      <button
        onClick={() => {
          setLoginActive(false);
          setRegisterActive(true);
          resetLogin();
        }}
      >
        Registrarse
      </button>
    </article>
  );
};
