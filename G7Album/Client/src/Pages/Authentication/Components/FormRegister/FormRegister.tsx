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

  /// VARIABLES CSS
  const css_formulario_registro = registerActive
    ? FormRegisterCSS.formulario__registro_show
    : FormRegisterCSS.formulario__registro_hide;

  const styleFormRegister = `
    ${FormRegisterCSS.form_LoginAndRegister} 
    ${css_formulario_registro}
  `;

  return (

    <div className={`
      ${FormRegisterCSS.containerFormLogin}} 
      ${store.IsLoginActive() 
        ? FormRegisterCSS.containerFormLogin___Show 
        : FormRegisterCSS.containerFormLogin___Hide}
    `}>

      <h2>Registrarse</h2>

      <form className={styleFormRegister}>

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

        <button onClick={registrar}>Registrarse</button>
      </form>

    </div>
  );
};
