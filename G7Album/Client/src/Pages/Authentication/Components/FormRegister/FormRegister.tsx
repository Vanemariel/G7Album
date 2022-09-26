import { Input } from "../../../../Components/Input/Input";
import FormRegisterCSS from "./FormRegister.module.css";
import { InputsMockRegister } from "../../Mocks/InputsRegister";
import { useAuth } from "../../Context/useAuth";

import { useNavigate } from "react-router-dom"
import AuthService from "../../Services/Auth.services";
import { useGlobalContext } from "../../../../Context/useGlobalContext";
import { IInputs } from "../../../../Components/Input/Inputs.interface";

export const FormRegister: React.FC = () => {
  
  /// HOOKS
  const storeAuth = useAuth()
  const storeGlobal = useGlobalContext();
  const navigate = useNavigate();



  const { formulario, handleChange, resetForm } = storeAuth.formularioRegister;


  const register = async (event: any) => {

    try {
      
      event.preventDefault();
  
      storeGlobal.SetShowLoader(true)
  
      const { Result, MessageError } = await AuthService.Register(formulario)
  
      if (Result == null || MessageError != null)
      {
          throw new Error(MessageError);
      }

      storeAuth.SetLoginActive(true);
      storeAuth.SetRegisterActive(false);
      
      storeGlobal.SetShowLoader(false);
      storeGlobal.SetMessageModal(Result);
      storeGlobal.SetShowMessageModal(true);

    } catch (error: any) {
      
      storeGlobal.SetMessageModal(error.Message)
      storeGlobal.SetShowMessageModal(true)

    } finally {
      storeGlobal.SetShowLoader(false)
      resetForm()
      setTimeout(() => {
        storeGlobal.SetShowMessageModal(false)
      }, 500);
    }
  }

  return (

    <div className={`
      ${FormRegisterCSS.containerFormRegister}} 
      ${storeAuth.IsRegisterActive() 
        ? FormRegisterCSS["containerFormRegister-show"] 
        : FormRegisterCSS["containerFormRegister--hide"]}
    `}>

      <h2>Registrarse</h2>

      <form onSubmit={register}>

        {InputsMockRegister.map((inputProps: IInputs, index: number) => (
          <Input
            key={index}
            inputProps={inputProps}
            value={formulario[inputProps.name]}
            handleChange={handleChange}
            errorMessage={inputProps.errorMessage}
            pattern={inputProps.expReg}
          />
        ))}

        <button type="submit">Registrarse</button>
      </form>

    </div>
  );
};
