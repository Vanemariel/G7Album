import {  } from "react-router";
 import { Route, Navigate} from "react-router-dom";
import { UserModels } from "../../Models/User.models";
import { getStorage } from "../../Utils/updateStorage";

interface IRoutePrivate {
    children: JSX.Element;
    redirectTo?: string;
}

export const RoutePrivate: React.FC<IRoutePrivate> = ({ children, redirectTo ="/" }) => {

    /* Futuro: �No deberia pegar al back enviando este token para ver si coincide
       con el token actual almacenado?
       Tb deberia hacer que el back me actualice el token cuando envie una peticion y 
       vea q mi token expiro!
    */
    const jwt = getStorage<UserModels>("User")?.Token;


    if (jwt == undefined) {
        // return <Navigate to={redirectTo} />
    }

    return children
 };
