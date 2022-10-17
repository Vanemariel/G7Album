import { IAlbumData } from "../Album/IAlbumData";

export interface IAlbumUsuarioData {
    albumId: number;
    album: IAlbumData;
    usuarioId: number;
}