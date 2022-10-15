import { IAlbumData } from "../Album/IAlbumData";

export interface IColeccionData {
    listadoAlbum: IAlbumData[];
    id: number;
    tituloColeccion: string;
}