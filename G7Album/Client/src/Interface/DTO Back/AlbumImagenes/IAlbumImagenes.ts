import { IComunId } from "../../Comun/IComunId.interface";
import { IAlbumData } from "../Album/IAlbumData";

export interface IAlbumImagenesData extends IComunId {
    albumId: number;
    cantidadImpresa: number;
    codigoImagenOriginal: number;
    imagen: String;
    numeroImagen: number;
    titulo: String;
}