import { IComunId } from "../../Comun/IComunId.interface";
import { IAlbumImagenesData } from "../AlbumImagenes/IAlbumImagenes";

export interface IAlbumData extends IComunId {
    cantidadImagen: string;
    cantidadImpreso: string;
    codigoAlbum: number;
    coleccionAlbumId: number;
    descripcion: string;
    desde: Date;
    hasta: Date;
    listadoImagenes: IAlbumImagenesData[];
    titulo: string;
    imagen: string;
}