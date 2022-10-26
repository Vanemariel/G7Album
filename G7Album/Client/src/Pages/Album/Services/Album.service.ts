
import { IColeccionData } from "../../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IPagination } from "../../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { IDataAlbumSend } from "../../../Interface/DTO Front/Album/IDataAlbumSend";
import { axiosMethod } from "../../../Utils/axiosMethod";

const AlbumService = {

    GetAllColeccionAlbumes: async (page: number): Promise<IResponseDTO<IPagination<IColeccionData[]>>> => {
        
        const Response: IResponseDTO<IPagination<IColeccionData[]>> = await axiosMethod<IPagination<IColeccionData[]>>({
            method: "GET",
            url: `/ColeccionAlbum/GetAllPage/${page}`
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
        
    },

    buyAlbum: async (dataAlbum: IDataAlbumSend) => {
        const Response = await axiosMethod<string>({
            method: "POST",
            url: `/AlbumUsuario/BuyAlbum`,
            dataSend: dataAlbum
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
    }

}

export default AlbumService; 