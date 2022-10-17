import { ModalModels } from "../Models/Modal.models";
import { UserModels } from "../Models/User.models";
import { getStorage } from "../Utils/updateStorage";

interface IGlobalState{
    ShowLoader: boolean;
    ModalStatus: ModalModels;
    User: UserModels;

}

/// Definimos las acciones que ejecutara nuestro Reducer
export type TGlobalActions =  
    { type: "SetMyUserData"; payload: {newState: UserModels} }  |  
    { type: "SetShowLoader"; payload: {newState: boolean} } |
    { type: "SetShowModalStatus"; payload: {newState: boolean} } |
    { type: "SetMessageModalStatus"; payload: {newState: string} } 
;


export const INITIAL_STATE: IGlobalState = {
  ShowLoader: false,
  ModalStatus: {} as ModalModels,
  User: getStorage<UserModels>("User") ?? {} as UserModels,
};

// ACA MODIFICAMOS EL STATE INICIAL
export const GlobalReducer = ( state: IGlobalState, action: TGlobalActions): IGlobalState => {

  switch (action.type) {

    case "SetMyUserData": 
      return {
        ...state,
        User: action.payload.newState
      }
    ;

    case "SetShowLoader": 
      return {
        ...state,
        ShowLoader: action.payload.newState
      }
    ;
    
      case "SetShowModalStatus":
          return {
              ...state,
              ModalStatus: {
                  ...state.ModalStatus, 
                  ShowModal: action.payload.newState
              }
          }
      ;

      case "SetMessageModalStatus":
        return {
            ...state,
            ModalStatus: {
                ...state.ModalStatus, 
                Message: action.payload.newState
            }
          }
       ;

    default:
      return state;
  }
};