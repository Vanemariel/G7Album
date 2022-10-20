import { IAlbumUsuarioData } from "../../../Interface/DTO Back/AlbumUsuario/IAlbumUsuario";
import { IPagination } from "../../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { axiosMethod } from "../../../Utils/axiosMethod";

const AlbumUsuarioService = {

    GetAllMyAlbumes: async ({page, idUsuario} : any): Promise<IResponseDTO<IPagination<IAlbumUsuarioData[]>>> => {
        
        const Response = await axiosMethod<IPagination<IAlbumUsuarioData[]>>({
            method: "GET",
            url: `/AlbumUsuario/GetAllPage/${page}/${idUsuario}`
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
        
    },
}

export default AlbumUsuarioService; 