import { IComunId } from "../../Comun/IComunId.interface";
import { IAlbumData } from "../Album/IAlbumData";

export interface IAlbumImagenesData extends IComunId {
    albumId: number;
    album: IAlbumData;
    cantidadImpresa: number;
    codigoImagenOriginal: number;
    imagen: string;
    numeroImagen: number;
    titulo: string;
}