import { IListAlbum } from "../../Interface/DTO Back/Album/IListAlbum";
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

  getAllAlbumes: async (): Promise<IResponseDTO<IListAlbum[]>> => {
    const Response = await axiosMethod<IListAlbum[]>({
      method: "GET",
      url: `/Album/GetAllAlbum/`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },




  updateAdminAlbumes: async (IdFigurita: number, figuritaData: IDataAlbumForm): Promise<IResponseDTO<string>> => {
    const Response = await axiosMethod<string>({
      method: "PUT",
      url: `/AlbumImagenes/${IdFigurita}/`,
      dataSend: figuritaData ,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },

  DeleteAdminAlbumes: async (id: number): Promise<IResponseDTO<string>> => {
    const Response = await axiosMethod<string>({
      method: "DELETE",
      url: `/AlbumImagenes/${id}/`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },


  
  AddAdminAlbumes: async (form: IDataAlbumForm): Promise<IResponseDTO<string>> => { // incompleto
    console.log("🚀 ~ file: AdminFigurita.Services.ts:68 ~ AddAdminAlbumes: ~ form", form)
    const Response = await axiosMethod<string>({
      method: "POST",
      url: `/AlbumImagenes/`,
      dataSend: form
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  }
};

export default AdminFiguritaService;
