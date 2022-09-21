import axios, { Method } from "axios";

interface IDataPetition {
  url: string;
  method: Method | undefined;
  dataSend?: any;
}

export const axiosMethod = async (dataPetition: IDataPetition) => {
  const { method, url, dataSend } = dataPetition;
  const URL_API =
    process.env.REACT_APP_URL_API || process.env.VITE_URL_API;

  let messageError = null;
  let data = null;

  try {
    let response = await axios(`${URL_API}${url}`, {
      method: method,
      data: dataSend ?? {},
    });

    data = await response.data;

  } catch (error: any) {
    // Manipulacion del error
    console.log("Error e",error.response )
    messageError = error?.response?.statusText || "Ocurrio un error";
  }

  return {
    data,
    messageError,
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
