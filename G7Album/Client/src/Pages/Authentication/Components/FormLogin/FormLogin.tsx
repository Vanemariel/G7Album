import React from "react";
import { Input } from "../../../../Components/Input/Input";
import { IFormInputs } from "../../../../Components/Input/Inputs.interface";
import LoginAndRegisterCSS from "../../LoginAndRegister.module.css";

interface Props {
  loginActive: any;
  formLogin: any;
  handleLogin: any;
  iniciarSesion: any;
}

export const FormLogin: React.FC<Props> = (props) => {
  const { loginActive, formLogin, handleLogin, iniciarSesion } =
    props;

  const inputLogin: IFormInputs[] = [
    {
      placeholder: "Correo electronico: ",
      type: "email",
      name: "emailLogin",
      expReg: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/i,
      errorMessage:
        "El correo solo puede contener letras, numeros, puntos, guiones y guion bajo.",
    },
    {
      placeholder: "Contraseña: ",
      type: "password",
      name: "passwordLogin",
      expReg: /^.{6,255}$/,
      errorMessage: "Minimo 6 caracteres",
    },
  ];

  /// VARIABLES CSS
  const css_formulario_login = loginActive
    ? LoginAndRegisterCSS.formulario__login_show
    : LoginAndRegisterCSS.formulario__login_hide;

  const styleFormLogin = ` 
    ${LoginAndRegisterCSS.form_LoginAndRegister} 
    ${css_formulario_login}
  `;

  return (
    <form className={styleFormLogin} onSubmit={iniciarSesion}>
      <h2>Iniciar Sesion</h2>

      {inputLogin.map((inputProps: any, index: any) => (
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
  );
};
