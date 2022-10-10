import axios, { Method } from "axios";
import { IResponseDTO } from "../Interface/DTO Back/IResponseDTO";

interface IDataParams {
  url: string;
  method: Method | undefined;
  dataSend?: any;
}

export const axiosMethod = async<TypeResult>(Params: IDataParams): Promise<IResponseDTO<TypeResult>> => {
  
    const { method, url, dataSend } = Params;
    const URL_API = process.env.REACT_APP_URL_API;

    let ResponseDTO = {} as IResponseDTO<TypeResult>

    try {

        let Response = await axios(`${URL_API}${url}`, {
            method: method,
            data: dataSend ?? {},
        });
        
        console.log("🚀 ~ file: axiosMethod.ts ~ line 23 ~ axiosMethod ~ Response", Response)

        ResponseDTO.Result = await Response.data.result;

    } catch (Error: any) {

        ResponseDTO.MessageError = Error.response.data?.messageError ||
            `Ha ocurrido un error al enviar la solicitud. Intentelo nuevamente!. Status: ${Error.response.status}`;
    }

    return ResponseDTO;
};

/* 

  MODO DE USO
  1) Instalar previamente Axios.

  2) Definimos en un archivo .ENV cuyo nombre de variable puede ser:
    VITE_URL_API o REACT_APP_URL_API y le colocamos la direccion de la 
    API a la que le vamos a pegar... 
    Por ejem.: REACT_APP_URL_API=https://formsubmit.co/ajax

  3) Para utilizar el metodo, sera lo siguiente:
  const { result, messageError } = await axiosMethod({
      method: "POST",
      url: "/5e0986ed3ab6208281bd2ec47b0252c1",
      dataSend: dataForm,
  });

*/
