import { AlbumData } from "../../../Interface/DTO Back/Album/AlbumData";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { axiosMethod } from "../../../Utils/axiosMethod";

const AlbumService = {

    GetAllAlbumes: async (page:number): Promise<IResponseDTO<AlbumData[]>> => {
        
        const Response = await axiosMethod<AlbumData[]>({
            method: "GET",
            url: `/Album/${page}`
        });

        // UNIFICAR LOS DTO REPSONSE PARA TRAER LA RESPUESTA DE ACA Y MOSTAR EN PAG
        

        return Response;

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

export default AlbumService; 