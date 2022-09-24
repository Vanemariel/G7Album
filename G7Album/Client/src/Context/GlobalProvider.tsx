import { useReducer } from "react";
import { UserModels } from "../Models/User.models";
import { GlobalContext } from "./GlobalContext";
import { GlobalReducer, INITIAL_STATE } from "./GlobalReducer";


interface Props {
  children: JSX.Element | JSX.Element[];
}

export const GlobalProvider: React.FC<Props> = (props) => {

  const [GlobalState, dispatch] = useReducer(GlobalReducer, INITIAL_STATE);

  const GetMyUserData = (): UserModels => GlobalState.User;
  const SetMyUserData = (value: UserModels): void => {
    dispatch({
      type: "SetMyUserData",
      payload: { newState: value }
    });
  };

  const IsShowLoader = () : boolean => GlobalState.ShowLoader;
  const SetShowLoader = (value: boolean): void => {
    dispatch({
      type: "SetShowLoader",
      payload: { newState: value }
    });
  };

  const IsShowMessageModal = (): boolean => GlobalState.MessageModal.ShowModal;
  const SetShowMessageModal = (value: boolean): void => {
    dispatch({
      type: "SetShowMessageModal",
      payload: {newState: value}
    });
  };
  
  const GetMessageModal = (): string => GlobalState.MessageModal.Message;
  const SetMessageModal = (value: string): void => {
    dispatch({
      type: "SetMessageModal",
      payload: {newState: value}
    });
  };


  return (
    <GlobalContext.Provider value={{
        GetMyUserData,
        SetMyUserData,
        IsShowLoader,
        SetShowLoader,
        IsShowMessageModal,
        SetShowMessageModal,
        GetMessageModal,
        SetMessageModal
      }}
    >
      {props.children}
    </GlobalContext.Provider>
  );
};