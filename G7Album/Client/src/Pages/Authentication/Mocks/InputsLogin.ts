import { IInputs } from "../../../Components/Input/Inputs.interface";

export const InputsLogin: IInputs[] = [
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
