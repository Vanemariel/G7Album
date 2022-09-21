import { useAuth } from "../../Context/useAuth";
import MessageRegisterCSS from "./MessageRegister.module.css";



export const MessageRegister: React.FC= () => {

  /// HOOKS
  const storeAuth = useAuth()


  const goToRegister = (): void => {
    storeAuth.SetLoginActive(false);
    storeAuth.SetRegisterActive(true);
    // store.ResetFormLogin();
  }

  return (
    <article className={`
        ${MessageRegisterCSS.containerBackgroundLogin} 
        ${storeAuth.IsRegisterActive() ? MessageRegisterCSS.noneElement : ""}
      `}
      style={storeAuth.IsLoginActive() ? {"opacity": 1} : {"opacity": 0}}
    >
      <h3>¿Aun no tienes una cuenta?</h3>
      <p>Registrate para que puedas iniciar sesion</p>

      <button onClick={goToRegister}>
        Registrarse
      </button>
    </article>
  );
};
