
import { IAlbumData } from "../../../Interface/DTO Back/Album/IAlbumData";
import { IPagination } from "../../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { axiosMethod } from "../../../Utils/axiosMethod";

const AlbumImagenService = {

    GetAllFiguritasAlbumes: async (page: number): Promise<IResponseDTO<IPagination<IAlbumData[]>>> => {
        
        const Response = await axiosMethod<IPagination<IAlbumData[]>>({
            method: "GET",
            url: `/Album/GetAllPage/${page}`
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
        
    }

}

export default AlbumImagenService; 