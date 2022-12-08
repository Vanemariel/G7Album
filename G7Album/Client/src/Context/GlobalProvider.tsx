import { useReducer } from "react";
import { UserModels } from "../Models/User.models";
import { getStorage } from "../Utils/updateStorage";
import { GlobalContext } from "./GlobalContext";
import { GlobalReducer, INITIAL_STATE } from "./GlobalReducer";


interface Props {
  children: JSX.Element | JSX.Element[];
}

export const GlobalProvider: React.FC<Props> = (props) => {

  const [GlobalState, dispatch] = useReducer(GlobalReducer, INITIAL_STATE);

  const GetMyUserData = (): UserModels => GlobalState.User ?? getStorage<UserModels>("User");
  const SetMyUserData = (value: UserModels): void => {
    dispatch({
      type: "SetMyUserData",
      payload: { newState: value }
    });
  };

  const IsShowLoader = (): boolean => GlobalState.ShowLoader;
  const SetShowLoader = (value: boolean): void => {
    dispatch({
      type: "SetShowLoader",
      payload: { newState: value }
    });
  };

  const IsShowModalStatus = (): boolean => GlobalState.ModalStatus.ShowModal;
  const SetShowModalStatus = (value: boolean): void => {
    dispatch({
      type: "SetShowModalStatus",
      payload: { newState: value }
    });
  };

  const IsShowModalContainer = (): boolean => GlobalState.ShowModalContainer;
  const SetShowModalContainer = (value: boolean): void => {
    dispatch({
      type: "SetShowModalContainer",
      payload: { newState: value }
    });
  };


  const GetMessageModalStatus = (): string => GlobalState.ModalStatus.Message;
  const SetMessageModalStatus = (value: string): void => {
    dispatch({
      type: "SetMessageModalStatus",
      payload: { newState: value }
    });
  };


  return (
    <GlobalContext.Provider value={{
      GetMyUserData,
      SetMyUserData,
      IsShowLoader,
      SetShowLoader,
      IsShowModalStatus,
      SetShowModalStatus,
      IsShowModalContainer,
      SetShowModalContainer,
      GetMessageModalStatus,
      SetMessageModalStatus
    }}
    >
      {props.children}
    </GlobalContext.Provider>
  );
};