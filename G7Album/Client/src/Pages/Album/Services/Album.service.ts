
import { IColeccionData } from "../../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IPagination } from "../../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { axiosMethod } from "../../../Utils/axiosMethod";

const AlbumService = {

    GetAllColeccionAlbumes: async (page: number): Promise<IResponseDTO<IPagination<IColeccionData[]>>> => {
        
        const Response = await axiosMethod<IPagination<IColeccionData[]>>({
            method: "GET",
            url: `/ColeccionAlbum/GetAllPage/${page}`
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
        
    },

    sendAlbum: async (idUsuario: number, idAlbun: number) => {
        console.log("🚀 ~ file: Album.service.ts ~ line 24 ~ sendAlbum: ~ idAlbun", idAlbun)
        console.log("🚀 ~ file: Album.service.ts ~ line 24 ~ sendAlbum: ~ idUsuario", idUsuario)
        // const Response = await axiosMethod<IPagination<IColeccionData[]>>({
        //     method: "GET",
        //     url: `/AlbumUsuario/SendAlbum`
        // });

        // return {
        //     Result: Response.Result,
        //     MessageError: Response.MessageError
        // };
    }

}

export default AlbumService; 