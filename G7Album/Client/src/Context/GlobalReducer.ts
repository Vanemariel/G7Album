import { ModalModels } from "../Models/Modal.models";
import { UserModels } from "../Models/User.models";
import { getStorage } from "../Utils/updateStorage";

interface IGlobalState{
    ShowLoader: boolean;
    MessageModal: ModalModels;
    User: UserModels;

}

/// Definimos las acciones que ejecutara nuestro Reducer
export type TGlobalActions =  
    { type: "SetMyUserData"; payload: {newState: UserModels} }  |  
    { type: "SetShowLoader"; payload: {newState: boolean} } |
    { type: "SetShowMessageModal"; payload: {newState: boolean} } |
    { type: "SetMessageModal"; payload: {newState: string} } 
;


export const INITIAL_STATE: IGlobalState = {
    ShowLoader: false,
    MessageModal: {} as ModalModels,
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
    
    case "SetShowMessageModal":
      return {
        ...state,
        MessageModal: {
            ...state.MessageModal, 
            ShowModal: action.payload.newState
        }
      }
    ;

    case "SetMessageModal":
        return {
            ...state,
            MessageModal: {
                ...state.MessageModal, 
                Message: action.payload.newState
            }
          }
    ;

    default:
      return state;
  }
};