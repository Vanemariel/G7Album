import { createMapperUser } from "../../../Mappers/User.mappers";
import { IAuthData } from "../../../Interface/DTO Back/Auth/IAuthData";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { IDataLoginForm } from "../../../Interface/DTO Front/Auth/IDataLoginForm";
import { IDataRegisterForm } from "../../../Interface/DTO Front/Auth/IDataRegisterForm";
import { UserModels } from "../../../Models/User.models";
import { axiosMethod } from "../../../Utils/axiosMethod";


const AuthService = {

    Login: async (DataLoginForm: IDataLoginForm): Promise<IResponseDTO<UserModels>> => {
        
        const Response = await axiosMethod<IAuthData>({
            method: "POST",
            url: "/Usuario/Login",
            dataSend: DataLoginForm,
        });

        let UserAdapted = {} as UserModels;

        if (Response.Result != undefined && Response.MessageError == undefined) {
            UserAdapted = createMapperUser(Response.Result);
        }

        return {
            Result: UserAdapted,
            MessageError: Response.MessageError
        };
    },

    Register: async (DataRegisterForm: IDataRegisterForm): Promise<IResponseDTO<string>> => {

        const { Result, MessageError } = await axiosMethod<string>({
            method: "POST",
            url: "/Usuario/Create",
            dataSend: DataRegisterForm,
        });

        return {
            Result: Result,
            MessageError: MessageError,
        };
    }

}

export default AuthService; 