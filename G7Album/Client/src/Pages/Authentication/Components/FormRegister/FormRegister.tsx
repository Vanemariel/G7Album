import { Input } from "../../../../Components/Input/Input";
import FormRegisterCSS from "./FormRegister.module.css";
import { InputsRegister } from "../../Mocks/InputsRegister";

interface Props {
  registerActive?: any;
  formRegister?: any;
  handleRegister?: any;
  registrar?: any;
}

export const FormRegister: React.FC<Props> = (props) => {
  const { registerActive, formRegister, handleRegister, registrar } =
    props;


  const store: any = undefined;

  return (

    <div className={`
      ${FormRegisterCSS.containerFormRegister}} 
      ${store.IsRegisterActive() 
        ? FormRegisterCSS.containerFormRegister___Show 
        : FormRegisterCSS.containerFormRegister___Hide}
    `}>

      <h2>Registrarse</h2>

      <form onSubmit={registrar}>

        {InputsRegister.map((inputProps: any, index: any) => (
          <Input
            key={index}
            inputProps={inputProps}
            value={formRegister[inputProps.name]}
            handleChange={handleRegister}
            errorMessage={inputProps.errorMessage}
            pattern={inputProps.expReg}
          />
        ))}

        <button type="submit">Registrarse</button>
      </form>

    </div>
  );
};
