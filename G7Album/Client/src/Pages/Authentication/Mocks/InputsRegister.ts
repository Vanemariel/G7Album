import { IInputs } from "../../../Components/Input/Inputs.interface";

export const InputsRegister: IInputs[] = [
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