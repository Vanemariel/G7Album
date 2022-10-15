
import { IColeccionData } from "../../../Interface/DTO Back/ColeccionAlbum/ColeccionAlbumData";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { axiosMethod } from "../../../Utils/axiosMethod";

const ColeccionAlbumService = {

    GetAllColeccionAlbumes: async (page: number): Promise<IResponseDTO<IColeccionData[]>> => {
        
        const Response = await axiosMethod<IColeccionData[]>({
            method: "GET",
            url: `/ColeccionAlbum/GetAllPage/${page}`
        });
        // UNIFICAR LOS DTO REPSONSE PARA TRAER LA RESPUESTA DE ACA Y MOSTAR EN PAG
        

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };

    //    let UserAdapted = {} as UserModels;
    //    if (Response.Result != undefined && Response.MessageError == undefined) {
    //        UserAdapted = createMapperUser(Response.Result);
    //    }
    //    return {
    //        Result: UserAdapted,
    //        MessageError: Response.MessageError
    //    };
    }

}

export default ColeccionAlbumService; 