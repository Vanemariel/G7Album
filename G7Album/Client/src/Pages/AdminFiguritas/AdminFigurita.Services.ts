import { IAlbumImagenesData } from "../../Interface/DTO Back/AlbumImagenes/IAlbumImagenes";
import { IListColeccion } from "../../Interface/DTO Back/ColeccionAlbum/IListColeccion";
import { IPagination } from "../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../Interface/DTO Back/IResponseDTO";
import { IDataAlbumForm } from "../../Interface/DTO Front/Album/IDataAlbumForm";
import { axiosMethod } from "../../Utils/axiosMethod";

const AdminFiguritaService = {
  GetAllAdminFiguritas: async (page: number): Promise<
    IResponseDTO<IPagination<IAlbumImagenesData[]>>
  > => {
    const Response = await axiosMethod<IPagination<IAlbumImagenesData[]>>({
      method: "GET",
      url: `/AlbumImagenes/GetAllPage/${page}/`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },

  /*updateAdminAlbumes: async (IdAlbum: number, albumData: IDataAlbumForm): Promise<IResponseDTO<string>> => {
    console.log("🚀 ~ file: AdminAlbum.Service.ts:24 ~ updateAdminAlbumes: ~ albumData", albumData)
    const Response = await axiosMethod<string>({
      method: "PUT",
      url: `/Album/${IdAlbum}/`,
      dataSend: albumData ,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },

  DeleteAdminAlbumes: async (id: number): Promise<IResponseDTO<string>> => {
    const Response = await axiosMethod<string>({
      method: "DELETE",
      url: `/Album/${id}/`,
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
  
  AddAdminAlbumes: async (form: IDataAlbumForm): Promise<IResponseDTO<string>> => {
    const Response = await axiosMethod<string>({
      method: "POST",
      url: `/Album/`,
      dataSend: form
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  }*/
};

export default AdminFiguritaService;
