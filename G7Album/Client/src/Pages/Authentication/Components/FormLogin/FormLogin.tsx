import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom"
import { Input } from "../../../../Components/Input/Input";
import { useFormCustom } from "../../../../Hooks/useFormCustom";
import { IDataLoginForm } from "../../../../Interface/DTO Front/Auth/IDataLoginForm";
import { useAuth } from "../../Context/useAuth";
import FormLoginCSS from "./FormLogin.module.css";

import { InputsLogin } from "../../Mocks/InputsLogin";
import AuthService from "../../Services/Auth.services";


export const FormLogin: React.FC = () => {

  /// HOOKS
  const storeAuth = useAuth()
  const navigate = useNavigate();

  const formularioLogin = useFormCustom<IDataLoginForm>({
    Email: '',  Password: ''
  });
  const { formulario, handleChange, resetForm } = formularioLogin;

  

  const login = async (event: any) => {

    try {
      
      event.preventDefaukt();
  
      /// Loader true
  
      const { UserAdapted, MessageError } = await AuthService.Login(formulario)
  
      if (UserAdapted == null || MessageError != null)
      {
          throw new Error(MessageError);
      }

      /// Guardar datos del Usuario en el Store de Redux
      
      navigate("/home");

    } catch (error: any) {
      
      /// Cargar mensaje de modal error.Message
      /// Abrir modal

    } finally {
      /// Loader false
      /// Reset form login

      /// Despues de 5 seg. cerrar Modal
    }


  }


  return (

    <div className={`
      ${FormLoginCSS.containerFormLogin}} 
      ${storeAuth.IsLoginActive() 
        ? FormLoginCSS["containerFormLogin--show"] 
        : FormLoginCSS["containerFormLogin--hide"]}
    `}>

      <h2>Iniciar Sesion</h2>

      <form onSubmit={login}>

        {InputsLogin.map((inputProps: any, index: any) => (
          <Input
            key={index}
            inputProps={inputProps}
            value={formulario[inputProps.name]}
            handleChange={handleChange}
            errorMessage={inputProps.errorMessage}
            pattern={inputProps.expReg}
          />
        ))}

        <button type="submit">Entrar</button>
      </form>

    </div>

  );
};
