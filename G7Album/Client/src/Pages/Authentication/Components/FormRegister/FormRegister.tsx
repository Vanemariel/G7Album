import React from "react";
import { Input } from "../../../../Components/Input/Input";
import { IFormInputs } from "../../../../Components/Input/Inputs.interface";
import LoginAndRegisterCSS from "../../LoginAndRegister.module.css";

interface Props {
  registerActive: any;
  formRegister: any;
  handleRegister: any;
  registrar: any;
}

export const FormRegister: React.FC<Props> = (props) => {
  const { registerActive, formRegister, handleRegister, registrar } =
    props;

  const inputRegister: IFormInputs[] = [
    {
      placeholder: "Correo electronico: ",
      type: "email",
      name: "emailRegister",
      expReg: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/i,
      errorMessage:
        "El correo solo puede contener letras, numeros, puntos, guiones y guion bajo.",
    },
    {
      placeholder: "Nombre completo: ",
      type: "text",
      name: "nameCompleted",
      expReg: /^[A-Za-zÑñÁáÉéÍíÓóÚúÜü\s]{2,40}$/i,
      errorMessage: "Solo puede contener letras. Minimo 2 caracteres",
    },
    {
      placeholder: "Usuario: ",
      type: "text",
      name: "userName",
      expReg: /^[A-Za-zÑñÁáÉéÍíÓóÚúÜü0-9_.+-\s]{2,20}$/i,
      errorMessage:
        "Puede contener letras, numeros, puntos, guiones y guion bajo. Minimo 2 caracteres. Maximo 20 caracteres",
    },
    {
      placeholder: "Contraseña: ",
      type: "password",
      name: "passwordRegister",
      expReg: /^.{6,255}$/,
      errorMessage: "Minimo 6 caracteres",
    },
    {
      placeholder: "Confirmar contraseña: ",
      type: "password",
      name: "confirmPassword",
      expReg: /^.{6,255}$/,
      errorMessage: "Minimo 6 caracteres",
    },
  ];

  /// VARIABLES CSS
  const css_formulario_registro = registerActive
    ? LoginAndRegisterCSS.formulario__registro_show
    : LoginAndRegisterCSS.formulario__registro_hide;

  const styleFormRegister = `
    ${LoginAndRegisterCSS.form_LoginAndRegister} 
    ${css_formulario_registro}
  `;

  return (
    <form className={styleFormRegister}>
      <h2>Registrarse</h2>

      {inputRegister.map((inputProps: any, index: any) => (
        <Input
          key={index}
          inputProps={inputProps}
          value={formRegister[inputProps.name]}
          handleChange={handleRegister}
          errorMessage={inputProps.errorMessage}
          pattern={inputProps.expReg}
        />
      ))}

      <button onClick={registrar}>Registrarse</button>
    </form>
  );
};
