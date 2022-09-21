import { useReducer } from "react";
import { AuthContext } from "./AuthContext";
import { AuthReducer, INITIAL_STATE } from "./AuthReducer";


interface Props {
  children: JSX.Element | JSX.Element[];
}

export const AuthProvider: React.FC<Props> = (props) => {

  const [AuthState, dispatch] = useReducer(AuthReducer, INITIAL_STATE);

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

        SetLoginActive,
        SetRegisterActive,
        ChangeClassCssForm
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
};