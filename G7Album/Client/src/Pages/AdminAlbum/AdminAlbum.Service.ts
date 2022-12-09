import { IAlbumData } from "../../Interface/DTO Back/Album/IAlbumData";
import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IListColeccion } from "../../Interface/DTO Back/ColeccionAlbum/IListColeccion";
import { IPagination } from "../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../Interface/DTO Back/IResponseDTO";
import { IDataAlbumForm } from "../../Interface/DTO Front/Album/IDataAlbumForm";
import { axiosMethod } from "../../Utils/axiosMethod";

const AdminAlbumService = {
  GetAllAdminAlbumes: async (page: number): Promise<
    IResponseDTO<IPagination<IAlbumData[]>>
  > => {
    const Response = await axiosMethod<IPagination<IAlbumData[]>>({
      method: "GET",
      url: `/Album/GetAllPage/${page}`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },

  updateAdminAlbumes: async (IdAlbum: number, albumData: IDataAlbumForm): Promise<IResponseDTO<string>> => {
    console.log("🚀 ~ file: AdminAlbum.Service.ts:24 ~ updateAdminAlbumes: ~ albumData", albumData)
    const Response = await axiosMethod<string>({
      method: "PUT",
      url: `/Album/${IdAlbum}/`,
      dataSend: albumData,
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

  GetAllColecction: async (): Promise<IResponseDTO<IListColeccion[]>> => {
    const Response = await axiosMethod<IListColeccion[]>({
      method: "GET",
      url: `/ColeccionAlbum/GetAllColecction/`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },
};

export default AdminAlbumService;
