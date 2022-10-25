import { IComunId } from "../../Comun/IComunId.interface";

export interface IAlbumImagenesData extends IComunId {
    albumId: number;
    cantidadImpresa: number;
    codigoImagenOriginal: number;
    imagen: string;
    numeroImagen: number;
    titulo: string;
}