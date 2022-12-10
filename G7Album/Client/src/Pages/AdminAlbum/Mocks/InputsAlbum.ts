import { IInputs } from "../../../Components/Input/Inputs.interface";

export const InputsMockAlbum: IInputs[] = [
    {
        placeholder: "Titulo del album: ",
        type: "text",
        name: "Titulo",
        expReg: /^[A-Za-zÑñÁáÉéÍíÓóÚúÜü\s]{2,40}$/i,
        errorMessage: "Solo puede contener letras. Minimo 2 caracteres",
    },
    {
        placeholder: "Descripcion del album: ",
        type: "text",
        name: "Descripcion",
        expReg: /^[A-Za-zÑñÁáÉéÍíÓóÚúÜü\s]{2,40}$/i,
        errorMessage: "Solo puede contener letras. Minimo 2 caracteres",
    },
    {
        placeholder: "Codigo album",
        type: "text",
        name: "CodigoAlbum",
        expReg: /^[0-9]+$/i,
        errorMessage: "Solo puede contener numeros",
    },
    {
        placeholder: "Url imagen: ",
        type: "text",
        name: "ImgAlbum",
        expReg: /^.{1,255}$/ ,
        errorMessage: "Minimo 1 caracter, maximo 255",
    },
    {
        placeholder: "Cantidad de imagenes",
        type: "text",
        name: "CantidadImagen",
        expReg: /^[0-9]+$/i,
        errorMessage: "Solo puede contener numeros",
    },
    {
        placeholder: "Cantidad de impresas",
        type: "text",
        name: "CantidadImpreso",
        expReg: /^[0-9]+$/i,
        errorMessage: "Solo puede contener numeros",
    }

];