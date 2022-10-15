
import { IAlbumImagenesData } from "../../../Interface/DTO Back/AlbumImagenes/IAlbumImagenes";
import { IColeccionData } from "../../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IPagination } from "../../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { axiosMethod } from "../../../Utils/axiosMethod";

const AlbumImagenService = {

    GetAllColeccionAlbumes: async (page: number): Promise<IResponseDTO<IPagination<IAlbumImagenesData[]>>> => {
        
        const Response = await axiosMethod<IPagination<IAlbumImagenesData[]>>({
            method: "GET",
            url: `/AlbumImagenes/GetAllPage/${page}`
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
        
    }

}

export default AlbumImagenService; 