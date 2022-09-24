import { useContext } from "react";
import { GlobalContext } from "./GlobalContext";

export const useGlobalContext = () => {
    
  /* 
    Utilizamos este useHooks para evitar llamar muchas veces el Context
    Entonces, de esta manera, llamamos solo una vez el context y retomamos
    los valores que nos provee
  */

  const globalContext = useContext(GlobalContext);

  return { ...globalContext };
};