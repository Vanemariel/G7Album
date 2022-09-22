import { createContext } from "react";


/* Interface de las propiedades / metodos 
   que podremos utilziar en los Componentes */
/// Colocamos propeidades y metodos a retornar.
export interface IAuthContext {
   IsLoginActive: () => boolean,
   IsRegisterActive: () => boolean,
   GetClassCssFormModifed: () => string,
   
   SetLoginActive: (value: boolean) => void,
   SetRegisterActive: (value: boolean) => void,
   ChangeClassCssForm: () => void
}

/* Este Context tendra alojada toda la informacion que 
   compartiremos con nuestros componentes */
export const AuthContext = createContext<IAuthContext>({} as IAuthContext);
