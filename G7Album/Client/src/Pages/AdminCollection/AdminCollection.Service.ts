
import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IPagination } from "../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../Interface/DTO Back/IResponseDTO";
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
  updateAdminCollection: async (
    TituloColeccion: string,
    id: number
  ): Promise<IResponseDTO<IColeccionData[]>> => {
    const Response = await axiosMethod<IColeccionData[]>({
      method: "PUT",
      url: `ColeccionAlbum/${id}/`,
      dataSend: { TituloColeccion },
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },
  DeleteAdminCollection: async (
    id: number
  ): Promise<IResponseDTO<IColeccionData[]>> => {
    const Response = await axiosMethod<IColeccionData[]>({
      method: "DELETE",
      url: `ColeccionAlbum/${id}/`,
    });

    return {
      Result: Response.Result,
      MessageError: Response.MessageError,
    };
  },
};

export default AdminCollectionService  ;
