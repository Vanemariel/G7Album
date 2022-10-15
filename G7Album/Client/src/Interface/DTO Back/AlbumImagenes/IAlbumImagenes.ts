import { IComunId } from "../../Comun/IComunId.interface";
import { IAlbumData } from "../Album/IAlbumData";

export interface IAlbumImagenesData extends IComunId {
    numeroImagen: number;
    codigoImagenOriginal: number;
    cantidadImpresa: number;
    imagen: String;
    titulo: String;
    album: IAlbumData;
    albumId: number;
}