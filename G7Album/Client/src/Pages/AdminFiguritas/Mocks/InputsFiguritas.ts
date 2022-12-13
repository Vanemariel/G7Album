import { IInputs } from "../../../Components/Input/Inputs.interface";

export const InputsMockFiguritas: IInputs[] = [
    {
        placeholder: "Ingrese titulo de la figurita",
        type: "text",
        name: "Titulo",
        expReg: /^.{1,255}$/,
        errorMessage: "Solo puede contener numeros",
    },
    {
        placeholder: "Url imagen: ",
        type: "text",
        name: "Imagen",
        expReg: /^.{1,255}$/ ,
        errorMessage: "Minimo 1 caracter, maximo 255",
    },
    {
        placeholder: "Ingrese Numero de Imagen: ",
        type: "text",
        name: "NumeroImagen",
        expReg: /^[0-9]+$/i,
        errorMessage: "Solo puede contener numeros",
    },
    {
        placeholder: "Ingrese codigo imagen original: ",
        type: "text",
        name: "CodigoImagenOriginal",
        expReg: /^[0-9]+$/i,
        errorMessage: "Solo puede contener numeros",
    },
    {
        placeholder: "Ingrese cantidad impresa",
        type: "text",
        name: "CantidadImpresa",
        expReg: /^[0-9]+$/i,
        errorMessage: "Solo puede contener numeros",
    },
];