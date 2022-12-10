
import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IPagination } from "../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../Interface/DTO Back/IResponseDTO";
import { IDataColeccionForm } from "../../Interface/DTO Front/Coleccion/IDataColeccionForm";
import { axiosMethod } from "../../Utils/axiosMethod";

const AdminCollectionService = {
  GetAllAdminCollection: async (page: number): Promise<
    IResponseDTO<IPagination<IColeccionData[]>>
  > => {
    const Response = await axiosMethod<IPagination<IColeccionData[]>>({
      method: "GET",
      url: `/ColeccionAlbum/GetAllPage/${page}`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },
  updateAdminCollection: async ( id: number, Titulo: string
  ): Promise<IResponseDTO<string>> => {
    const Response = await axiosMethod<string>({
      method: "PUT",
      url: `/ColeccionAlbum/${id}/`,
      dataSend: { Titulo },
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },
  DeleteAdminCollection: async (id: number): Promise<IResponseDTO<string>> => {
    const Response = await axiosMethod<string>({
      method: "DELETE",
      url: `/ColeccionAlbum/${id}/`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },


  AddAdminColeccion: async (form: IDataColeccionForm): Promise<IResponseDTO<string>> => {
    const Response = await axiosMethod<string>({
      method: "POST",
      url: `/ColeccionAlbum/`,
      dataSend: form
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },
};

export default AdminCollectionService;
