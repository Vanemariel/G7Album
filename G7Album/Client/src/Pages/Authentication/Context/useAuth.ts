import { useContext } from "react";
import { AuthContext } from "./AuthContext";

export const useAuth = () => {
    
  /* 
    Utilizamos este useHooks para evitar llamar muchas veces el Context
    Entonces, de esta manera, llamamos solo una vez el context y retomamos
    los valores que nos provee
  */

  const authContext = useContext(AuthContext);

  return { ...authContext };
};