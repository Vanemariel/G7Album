import { IComunId } from "../../Comun/IComunId.interface";
import { IAlbumImagenesData } from "../AlbumImagenes/IAlbumImagenes"; //importo la interfaz de albumimagen
import { IAlbumUsuarioData } from "../AlbumUsuario/IAlbumUsuario"; //importo la interfaz de albumusuario
import { IUsuario } from "../Usuario/IUsuario";
        
    export interface IAlbumUsuarioImagenes extends IComunId {
        //especifico los tipos de datos de cosa
        albumUsuarioId: number;
        albumImagenesId: number;
        usuarioId: number;
        //objetos de las entidades
        albumUsuario: IAlbumUsuarioData //lo que tengo dentro de la intefaz son los datos pasados en el back
        albumImagenes: IAlbumImagenesData
        usuario: IUsuario
         //por nomenclatura empieza con minuscula   
     }