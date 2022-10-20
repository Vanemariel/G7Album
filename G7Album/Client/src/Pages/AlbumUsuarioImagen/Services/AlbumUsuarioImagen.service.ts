import { IAlbumUsuarioImagenes } from "../../../Interface/DTO Back/AlbumUsuarioImagenes/IAlbumUsuarioImagenes";
import { IPagination } from "../../../Interface/DTO Back/IPagination";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { axiosMethod } from "../../../Utils/axiosMethod";

const AlbumUsuarioImagenService = {

    GetAllMyFiguritas: async ({page, idUsuario} : any): Promise<IResponseDTO<IPagination<IAlbumUsuarioImagenes[]>>> => {
        //en type scrip los: significa lo q retorna el metodo. se dice: me retorna una promesa(promise)
        //de tipo responsedto que recibe comoparametro una paginacion de albumusuario data
        const Response = await axiosMethod<IPagination<IAlbumUsuarioImagenes[]>>({
            //axiod es una funcion que le paso cm prametro un objeto con propiedades en este caso
            //method y url. funcion q especifica el tipo de dato q trae cm rta
            method: "GET",
            url: `/AlbumUsuarioImagenes/GetAllPage/${page}/${idUsuario}`
        });

        return {
            Result: Response.Result,
            MessageError: Response.MessageError
        };
        
    },
}
//async y await que pa la ejecucion demora en dar la rta

export default AlbumUsuarioImagenService; 