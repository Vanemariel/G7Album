import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom"
import { Input } from "../../../../Components/Input/Input";
import { useAuth } from "../../Context/useAuth";
import FormLoginCSS from "./FormLogin.module.css";

import { InputsMockLogin } from "../../Mocks/InputsLogin";
import AuthService from "../../Services/Auth.services";
import { useGlobalContext } from "../../../../Context/useGlobalContext";
import { IInputs } from "../../../../Components/Input/Inputs.interface";
import { updateStorage } from "../../../../Utils/updateStorage";


export const FormLogin: React.FC = () => {

  /// HOOKS
  const storeAuth = useAuth()
  const storeGlobal = useGlobalContext();
  const navigate = useNavigate();


  const { formulario, handleChange, resetForm } = storeAuth.formularioLogin;

  

  const login = async (event: any) => {

    try {
      
      event.preventDefault();
                                  
      storeGlobal.SetShowLoader(true)
                                                                    
      const { Result: UserAdapted, MessageError } = await AuthService.Login(formulario)
                                                                             
      if (MessageError != undefined)
      {
        throw new Error(MessageError);
      }
                                              
      storeGlobal.SetMyUserData(UserAdapted);                          
      updateStorage("User", UserAdapted)
                                                   
      navigate("/home");
            
    } catch (error: any) {
    
      storeGlobal.SetMessageModal(error.Message)
      storeGlobal.SetShowMessageModal(true)
    
    } finally {
                
      storeGlobal.SetShowLoader(false)
      resetForm()
      setTimeout(() => {
        storeGlobal.SetShowMessageModal(false)
      }, 5000);

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

        {InputsMockLogin.map((inputProps: IInputs, index: number) => (
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
