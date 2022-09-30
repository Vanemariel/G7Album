import { useReducer } from "react";
import { useFormCustom } from "../../../Hooks/useFormCustom";
import { IDataLoginForm } from "../../../Interface/DTO Front/Auth/IDataLoginForm";
import { IDataRegisterForm } from "../../../Interface/DTO Front/Auth/IDataRegisterForm";
import { AuthContext } from "./AuthContext";
import { AuthReducer, INITIAL_STATE } from "./AuthReducer";


interface Props {
  children: JSX.Element | JSX.Element[];
}

export const AuthProvider: React.FC<Props> = (props) => {

  /// HOOKS
  const [AuthState, dispatch] = useReducer(AuthReducer, INITIAL_STATE);
  const formularioLogin = useFormCustom<IDataLoginForm>({
    Email: '',  Password: ''
  });
    const formularioRegister = useFormCustom<IDataRegisterForm>({
        EmailRegister: '', PasswordRegister: '', ConfirmPassword: '', NombreCompleto: ''
  })

  /// METODOS
  const IsLoginActive = (): boolean => AuthState.LoginActive;
  const SetLoginActive = (value: boolean): void => {
    dispatch({
      type: "SetLoginActive",
      payload: { newState: value }
    });
    ChangeClassCssForm()
  };

  const IsRegisterActive = () : boolean => AuthState.RegisterActive;
  const SetRegisterActive = (value: boolean): void => {
    dispatch({
      type: "SetRegisterActive",
      payload: { newState: value }
    });
    ChangeClassCssForm()
  };

  const GetClassCssFormModifed = (): string => AuthState.ClassCSSForm;
  const ChangeClassCssForm = (): void => {
    dispatch({
      type: "ChangeClassCssForm"
    });
  };


  return (
    <AuthContext.Provider value={{
        IsLoginActive,
        IsRegisterActive,
        GetClassCssFormModifed,
        formularioLogin,
        formularioRegister,
        
        SetLoginActive,
        SetRegisterActive,
        ChangeClassCssForm
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
};