import React from "react";
import LoginAndRegisterCSS from "../../LoginAndRegister.module.css";

interface Props {
  loginActive: boolean;
  registerActive: boolean;
  setLoginActive: any;
  setRegisterActive: any;
  resetRegister: any;
}

export const MessageLogin: React.FC<Props> = (props) => {
  const {
    loginActive,
    registerActive,
    resetRegister,
    setLoginActive,
    setRegisterActive,
  } = props;

  /// VARIABLES cSS

  const styleMessageLogin = `
    ${LoginAndRegisterCSS.containerBackground__login} 
    ${loginActive ? LoginAndRegisterCSS.noneElement : undefined}
  `;

  return (
    <article
      className={styleMessageLogin}
      style={registerActive ? { opacity: "1" } : { opacity: "0" }}
    >
      <h3>¿Ya tienes una cuenta?</h3>
      <p>Inicia sesion para entrar a la pagina</p>
      <button
        onClick={() => {
          setLoginActive(true);
          setRegisterActive(false);
          resetRegister();
        }}
      >
        Iniciar Sesion
      </button>
    </article>
  );
};
