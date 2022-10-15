import { IComunId } from "../../Comun/IComunId.interface";

export interface IAlbumData extends IComunId {
    codigoAlbum: number;
    titulo: string;
    descripcion: string;
    cantidadImagen: string;
    cantidadImpreso: string;
    desde: Date;
    hasta: Date;
    coleccionAlbumId: number;
}