
import { IAlbumData } from "../../../Interface/DTO Back/Album/IAlbumData";
import { IPagination } from "../../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { IAlbumImagenDataBuy } from "../../../Interface/DTO Front/AlbumImagen/IAlbumImagenDataBuy";
import { axiosMethod } from "../../../Utils/axiosMethod";

const AlbumImagenService = {

    GetAllFiguritasAlbumes: async (page: number, query?: string): Promise<IResponseDTO<IPagination<IAlbumData[]>>> => {

        let url;
        query === '' || query === undefined
            ? url = `/Album/GetAllPage/${page}/`
            : url = `/Album/GetAllPage/${page}/${query}`

        const Response = await axiosMethod<IPagination<IAlbumData[]>>({
            method: "GET",
            url: url
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };

    },
    buyFigurita: async (dataAlbum: IAlbumImagenDataBuy) => {
        const Response = await axiosMethod<string>({
            method: "POST",
            url: `/AlbumUsuarioImagenes/buy/figus`,
            dataSend: dataAlbum
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
    }


}

export default AlbumImagenService; 