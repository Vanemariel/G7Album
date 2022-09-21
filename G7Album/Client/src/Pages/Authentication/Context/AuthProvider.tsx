import { useEffect, useReducer } from "react";
import { AuthContext } from "./AuthContext";
import { AuthReducer, INITIAL_STATE } from "./AuthReducer";


interface Props {
  children: JSX.Element | JSX.Element[];
}

export const AuthProvider: React.FC<Props> = (props) => {


  const [AuthState, dispatch] = useReducer(AuthReducer, INITIAL_STATE);


  const IsLoginActive = () => AuthState.LoginActive;
  const SetLoginActive = (newState: boolean) => {
    dispatch({
      type: "SetLoginActive",
      payload: { newState }
    });
  };

  const IsRegisterActive = () => AuthState.RegisterActive;
  const SetRegisterActive = (newState: boolean) => {
    dispatch({
      type: "SetRegisterActive",
      payload: { newState }
    });
  };

  const GetClassCssFormModifed = () => AuthState.ClassCSSForm;
  const ChangeClassCssForm = () => {
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