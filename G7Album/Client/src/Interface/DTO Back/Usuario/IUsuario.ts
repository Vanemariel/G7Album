import { IComunId } from "../../Comun/IComunId.interface";
import { IAlbumUsuarioData } from "../AlbumUsuario/IAlbumUsuario"; 

 export interface IUsuario extends IComunId {
    
        nombreCompleto: string; 
        email: string;
        listaAlbumUsuario: IAlbumUsuarioData[] //mi lista es un arrglo de albumusuariodata 
        //aparte de ser un arreglo de objeto. [] es un arreglo de albumusuario data

     //por nomenclatura empieza con minuscula   
 }