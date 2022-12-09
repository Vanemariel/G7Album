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
        placeholder: "Url imagen: ",
        type: "text",
        name: "ImgAlbum",
        expReg: /^[A-Za-zÑñÁáÉéÍíÓóÚúÜü\s]{2,40}$/i,
        errorMessage: "Solo puede contener letras. Minimo 2 caracteres",
    },
];