import { IAlbumData } from "../../Interface/DTO Back/Album/IAlbumData";
import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IPagination } from "../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../Interface/DTO Back/IResponseDTO";
import { axiosMethod } from "../../Utils/axiosMethod";

const AdminAlbumService = {
  GetAllAdminAlbumes: async (): Promise<
    IResponseDTO<IPagination<IAlbumData[]>>
  > => {
    const Response = await axiosMethod<IPagination<IAlbumData[]>>({
      method: "GET",
      url: `/Album/GetAllPage/1`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },
  updateAdminAlbumes: async (
    IdAlbum: number,
    titulo: string
  ): Promise<IResponseDTO<IAlbumData[]>> => {
    const Response = await axiosMethod<IAlbumData[]>({
      method: "PUT",
      url: `Album/${IdAlbum}/`,
      dataSend: { titulo },
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },
  DeleteAdminAlbumes: async (
    id: number
  ): Promise<IResponseDTO<IAlbumData[]>> => {
    const Response = await axiosMethod<IAlbumData[]>({
      method: "DELETE",
      url: `Album/${id}/`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },
};

export default AdminAlbumService;
