
import { IColeccionData } from "../../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IPagination } from "../../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { IDataAlbumSend } from "../../../Interface/DTO Front/Album/IDataAlbumSend";
import { axiosMethod } from "../../../Utils/axiosMethod";

const AlbumService = {

    GetAllColeccionAlbumes: async (page: number, query?: string): Promise<IResponseDTO<IPagination<IColeccionData[]>>> => {
        
        let url;
        query === '' || query === undefined
          ? url = `/ColeccionAlbum/GetAllPage/${page}/`
          : url = `/ColeccionAlbum/GetAllPage/${page}/${query}`

        const Response = await axiosMethod<IPagination<IColeccionData[]>>({
            method: "GET",
            url: url
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