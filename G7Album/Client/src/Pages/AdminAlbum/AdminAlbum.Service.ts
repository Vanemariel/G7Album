import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IResponseDTO } from "../../Interface/DTO Back/IResponseDTO";
import { axiosMethod } from "../../Utils/axiosMethod";


const AdminAlbumService = {
    GetAllAdminAlbumes: async (): Promise<IResponseDTO<IColeccionData[]>> => {
        
        const Response = await axiosMethod<IColeccionData[]>({
            method: "GET",
            url: `/Album/GetAllPage/1`
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };  
    },
    UpDateAdminAlbumes: async (id:number): Promise<IResponseDTO<IColeccionData[]>> => {
        
        const Response = await axiosMethod<IColeccionData[]>({
            method: "PUT",
            url: `Album/${id}/`
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
    },
    DeleteAdminAlbumes: async (id:number): Promise<IResponseDTO<IColeccionData[]>> => {
        
        const Response = await axiosMethod<IColeccionData[]>({
            method: "DELETE",
            url: `Album/${id}/`
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
    },


}

export default AdminAlbumService