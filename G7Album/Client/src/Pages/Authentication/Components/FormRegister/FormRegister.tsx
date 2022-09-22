import { Input } from "../../../../Components/Input/Input";
import FormRegisterCSS from "./FormRegister.module.css";
import { InputsRegister } from "../../Mocks/InputsRegister";
import { useAuth } from "../../Context/useAuth";

import { useNavigate } from "react-router-dom"
import { useFormCustom } from "../../../../Hooks/useFormCustom";
import { IDataRegisterForm } from "../../../../Interface/DTO Front/Auth/IDataRegisterForm";
import AuthService from "../../Services/Auth.services";

export const FormRegister: React.FC = () => {
  
  /// HOOKS
  const storeAuth = useAuth()
  const navigate = useNavigate();

  const formularioLogin = useFormCustom<IDataRegisterForm>({
    Email: '',  Password: '', ConfirmPassword: '', UserName: ''
  });

  const { formulario, handleChange, resetForm } = formularioLogin;


  const register = async (event: any) => {

    try {
      
      event.preventDefaukt();
  
      /// Loader true
  
      const { Data, MessageError } = await AuthService.Register(formulario)
  
      if (Data == null || MessageError != null)
      {
          throw new Error(MessageError);
      }

      storeAuth.SetLoginActive(true);
      storeAuth.SetRegisterActive(false);
      
      // storeGlobal.SetShowLoader(false);
      // storeGlobal.SetMessageModal(Data);
      // storeGlobal.SetShowMessageModal(true);

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
      ${FormRegisterCSS.containerFormRegister}} 
      ${storeAuth.IsRegisterActive() 
        ? FormRegisterCSS.containerFormRegister___Show 
        : FormRegisterCSS.containerFormRegister___Hide}
    `}>

      <h2>Registrarse</h2>

      <form onSubmit={register}>

        {InputsRegister.map((inputProps: any, index: any) => (
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
