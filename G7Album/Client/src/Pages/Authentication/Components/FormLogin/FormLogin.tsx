import React from "react";
import { Input } from "../../../../Components/Input/Input";
import FormLoginCSS from "../../FormLoginCSS.module.css";

import { InputsLogin } from "../../Mocks/InputsLogin";

interface Props {
  loginActive?: any;
  formLogin?: any;
  handleLogin?: any;
  iniciarSesion?: any;
}

export const FormLogin: React.FC<Props> = (props) => {
  const { loginActive, formLogin, handleLogin, iniciarSesion } =
    props;


  const store: any = undefined;



  return (

    <div className={`
      ${FormLoginCSS.containerFormLogin}} 
      ${store.IsLoginActive() 
        ? FormLoginCSS.containerFormLogin___Show 
        : FormLoginCSS.containerFormLogin___Hide}
    `}>

      <h2>Iniciar Sesion</h2>

      <form onSubmit={iniciarSesion}>

        {InputsLogin.map((inputProps: any, index: any) => (
          <Input
            key={index}
            inputProps={inputProps}
            value={formLogin[inputProps.name]}
            handleChange={handleLogin}
            errorMessage={inputProps.errorMessage}
            pattern={inputProps.expReg}
          />
        ))}

        <button type="submit">Entrar</button>
      </form>

    </div>

  );
};
