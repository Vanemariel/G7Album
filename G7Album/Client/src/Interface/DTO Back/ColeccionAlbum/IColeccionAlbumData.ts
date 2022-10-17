import { IComunId } from "../../Comun/IComunId.interface";
import { IAlbumData } from "../Album/IAlbumData";

export interface IColeccionData extends IComunId {
    listadoAlbum: IAlbumData[];
    tituloColeccion: string;
}