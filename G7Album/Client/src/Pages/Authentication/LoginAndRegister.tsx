import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Loader } from "../../Components/Loader/Loader";
import {
  ModalContainer,
  openAndShowMessageModal,
} from "../../Components/ModalContainer/ModalContainer";
import { useFormCustom } from "../../Hooks/useFormCustom";
import { IFormLogin } from "../../Interface/IFormLogin";
import { IFormRegister } from "../../Interface/IFormRegister";
import { FormLogin } from "./Components/FormLogin/FormLogin";
import { FormRegister } from "./Components/FormRegister/FormRegister";
import { MessageLogin } from "./Components/MessageLogin/MessageLogin";
import { MessageRegister } from "./Components/MessageRegister/MessageRegister";
import LoginAndRegisterCSS from "./LoginAndRegister.module.css";
// import { Login } from "./Services/Login";

// import {
//   useAppDispatch,
//   useAppSelector,
// } from "../../Hooks/useTypedHookRedux";
// import { incrementByAmount } from "../../Redux/UserRedux/UserReducer";

const LoginAndRegister: React.FC = () => {
  // The `state` arg is correctly typed as `RootState` already
  // const count = useAppSelector((state) => state.user.value);
  // const dispatch = useAppDispatch();
  // /* ------------------- */

  // console.log(
  //   "ESTE ES EL STORE ",
  //   useAppSelector((state) => state)
  // );

  // const validationHash = location.hash?.includes("#error-login");

  /// HOOKS
  const navigate = useNavigate();
  const [loginActive, setLoginActive] = useState(true);
  const [registerActive, setRegisterActive] = useState(false);
  const [messageModal, setMessageModal] = useState("");

  const [isLoader, setIsLoader] = useState(false);

  const {
    formulario: formLogin,
    handleChange: handleLogin,
    resetForm: resetLogin,
  } = useFormCustom<IFormLogin>({
    emailLogin: "",
    passwordLogin: "",
  });

  const {
    formulario: formRegister,
    handleChange: handleRegister,
    resetForm: resetRegister,
  } = useFormCustom<IFormRegister>({
    nameCompleted: "",
    emailRegister: "",
    userName: "",
    passwordRegister: "",
    confirmPassword: "",
  });

  /// METOODS
  const iniciarSesion = async (e: any) => {
    e.preventDefault();

    setIsLoader(true);

    // const { User, Token, messageError } = await Login(formLogin);

    setIsLoader(false);

    // if (messageError !== null) {
    //   setMessageModal(messageError);
    //   return openAndShowMessageModal("#error-login");
    // }

    // console.log("Mis datos ", User);
    // console.log("Mis token ", Token);
    /// Agregar "user" al redux.
    /// Agregar "token" al redux.

    // navigate("/home");
  };

  const registrar = (e: any) => {
    e.preventDefault();

    console.log("form Register", formRegister);
    navigate("/home");
  };

  /// VARIABLES CSS
  const css_containerFormActive =
    loginActive && !registerActive
      ? LoginAndRegisterCSS.container__loginActive
      : LoginAndRegisterCSS.container__registerActive;

  const styleContainerForms = `
    ${LoginAndRegisterCSS.containerLoginAndRegister}
    ${css_containerFormActive} 
  `;

  return (
    <main>
      {isLoader && <Loader />}

      <div className={LoginAndRegisterCSS.containerPage}>
          {/* <h1>{count}</h1>

        <button onClick={() => dispatch(incrementByAmount(5))}>asdsa</button> */}

        {/* <!-- Es el recuadro azul --> */}
        <section className={LoginAndRegisterCSS.containerBackground}>
          {/* <!-- La parte de iniciar sesion --> */}
          <MessageLogin
            loginActive={loginActive}
            registerActive={registerActive}
            resetRegister={resetRegister}
            setLoginActive={setLoginActive}
            setRegisterActive={setRegisterActive}
          />

          {/* <!-- La parte de registrarse --> */}
          <MessageRegister
            loginActive={loginActive}
            registerActive={registerActive}
            resetLogin={resetLogin}
            setLoginActive={setLoginActive}
            setRegisterActive={setRegisterActive}
          />
        </section>

        {/* <!-- Es el recuadro blanco, formulario.  --> */}
        <section className={styleContainerForms}>
          <FormLogin
            loginActive={loginActive}
            formLogin={formLogin}
            handleLogin={handleLogin}
            iniciarSesion={iniciarSesion}
          />

          <FormRegister
            registerActive={registerActive}
            formRegister={formRegister}
            handleRegister={handleRegister}
            registrar={registrar}
          />
        </section>
     
      </div>

      {/* <ModalContainer
        validation={validationHash}
        cssModalCOntainer={LoginAndRegisterCSS.errorLogin}
        message={messageModal}
      /> */}
    </main>
  );
};

export default LoginAndRegister;
