import { createContext } from "react";
import { UserModels } from "../Models/User.models";

/* Interface de las propiedades / metodos 
   que podremos utilziar en los Componentes */
/// Colocamos propeidades y metodos a retornar.
export interface IGlobalContext {

   GetMyUserData: () => UserModels,
   SetMyUserData: (value: UserModels) => void,

   IsShowLoader: () => boolean,
   SetShowLoader: (value: boolean) => void,

   IsShowModalContainer: () => boolean,
   SetShowModalContainer: (value: boolean) => void,

   IsShowModalStatus: () => boolean,
   SetShowModalStatus: (value: boolean) => void, 
    
   GetMessageModalStatus: () => string,
   SetMessageModalStatus: (value: string) => void
}

/* Este Context tendra alojada toda la informacion que 
   compartiremos con nuestros componentes */
export const GlobalContext = createContext<IGlobalContext>({} as IGlobalContext);
