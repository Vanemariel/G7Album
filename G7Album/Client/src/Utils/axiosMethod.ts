import axios, { Method } from "axios";
import { IResponseDTO } from "../Interface/DTO Back/IResponseDTO";

interface IDataParams {
  url: string;
  method: Method | undefined;
  dataSend?: any;
}

export const axiosMethod = async <TypeResponse>(Params: IDataParams) => {
  
  const { method, url, dataSend } = Params;
  const URL_API = process.env.REACT_APP_URL_API;

  let MessageError = null;
  let Data = {} as TypeResponse; 

  try {
    let Result = await axios(`${URL_API}${url}`, {
      method: method,
      data: dataSend ?? {},
    });

    Data = await Result.data;

  } catch (Error: any) {

    // Manipulacion del error
    console.log("Error e",Error.response )

    MessageError = Error?.response?.statusText || "Ocurrio un error";

  }

  // TODO: VER SI COLOCAMOS EL TEMA DEL MODAL DE ERROR ACA. Ejecutandose con el Store.


  return {
    Data,
    MessageError,
  };
};

/* 
  MODO DE USO
  1) Instalar previamente Axios.

  2) Definimos en un archivo .ENV cuyo nombre de variable puede ser:
    VITE_URL_API o REACT_APP_URL_API y le colocamos la direccion de la 
    API a la que le vamos a pegar... 
    Por ejem.: REACT_APP_URL_API=https://formsubmit.co/ajax

  3) Para utilizar el metodo, sera lo siguiente:
  const { data, message } = await axiosMethod({
      method: "POST",
      url: "/5e0986ed3ab6208281bd2ec47b0252c1",
      dataSend: dataForm,
  });




*/
