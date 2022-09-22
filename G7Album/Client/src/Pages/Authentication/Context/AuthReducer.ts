
interface IAuthState{
    LoginActive: boolean;
    RegisterActive: boolean;
    ClassCSSForm: string;
}

/// Definimos las acciones que ejecutara nuestro Reducer
export type TAuthActions =  
    { type: "SetLoginActive"; payload: {newState: boolean} }  |  
    { type: "SetRegisterActive"; payload: {newState: boolean} } |
    { type: "ChangeClassCssForm"; } 
;


export const INITIAL_STATE: IAuthState = {
    LoginActive: true,
    RegisterActive: false,
    ClassCSSForm: "",
};

// ACA MODIFICAMOS EL STATE INICIAL
export const AuthReducer = ( state: IAuthState, action: TAuthActions): IAuthState => {

  switch (action.type) {

    case "SetLoginActive": 
      return {
        ...state,
        LoginActive: action.payload.newState
      }
    ;
    
    case "SetRegisterActive":
      return {
        ...state,
        RegisterActive: action.payload.newState
      }
    ;

    case "ChangeClassCssForm":
        
        let valueCSS: string; 
        (state.LoginActive && !state.RegisterActive) 
           ? valueCSS = "containerPage__Auth--loginActive"
           : valueCSS = "containerPage__Auth--registerActive"            
        
        return {
            ...state,
            ClassCSSForm: valueCSS
        }
    ;

    default:
      return state;
  }
};