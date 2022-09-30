import { IInputs } from "../../../Components/Input/Inputs.interface";

export const InputsMockRegister: IInputs[] = [
    {
      placeholder: "Correo electronico: ",
      type: "email",
      name: "EmailRegister",
      expReg: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/i,
      errorMessage: "El correo solo puede contener letras, numeros, puntos, guiones y guion bajo.",
    },
    {
      placeholder: "Nombre completo: ",
      type: "text",
      name: "NombreCompleto",
        expReg: /^[A-Za-zÑñÁáÉéÍíÓóÚúÜü\s]{2,40}$/i,
        errorMessage: "Solo puede contener letras. Minimo 2 caracteres",
    },
    {
      placeholder: "Contraseña: ",
      type: "password",
      name: "PasswordRegister",
      expReg: /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$/,
      errorMessage: "La contraseña debe contener al menos: 1 letra mayuscula, 1 letra minuscula y 1 numero.",
    },
    {
      placeholder: "Confirmar contraseña: ",
      type: "password",
      name: "ConfirmPassword",
      expReg: /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$/,
      errorMessage: "La contraseña debe contener al menos: 1 letra mayuscula, 1 letra minuscula y 1 numero.",
    },
  ];