import { IAlbumData } from "../Album/IAlbumData";

export interface IAlbumImagenesData {
    numeroImagen: number;
    codigoImagenOriginal: number;
    cantidadImpresa: number;
    imagen: String;
    titulo: String;
    album: IAlbumData;
    albumId: number;
}