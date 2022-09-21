import MessageRegisterCSS from "./MessageRegister.module.css";



export const MessageRegister: React.FC= () => {

  const store : any = undefined;

  const goToRegister = (): void => {
    store.SetLoginActive(false);
    store.SetRegisterActive(true);
    store.ResetFormLogin();
  }

  return (
    <article className={`
        ${MessageRegisterCSS.containerBackgroundLogin} 
        ${store.IsLoginActive() ? MessageRegisterCSS.noneElement : ""}
      `}
      // style={{store.IsRegisterActive() ? "opacity: 1" : "opacity: 0"}}
    >
      <h3>¿Aun no tienes una cuenta?</h3>
      <p>Registrate para que puedas iniciar sesion</p>

      <button onClick={goToRegister}>
        Registrarse
      </button>
    </article>
  );
};
