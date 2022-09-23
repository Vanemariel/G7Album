import { createAddaptedUser } from "../../../Adapters/User.adapters";
import { AuthData } from "../../../Interface/DTO Back/Auth/AuthData";
import { IResponseDTO } from "../../../Interface/DTO Back/IResponseDTO";
import { IDataLoginForm } from "../../../Interface/DTO Front/Auth/IDataLoginForm";
import { IDataRegisterForm } from "../../../Interface/DTO Front/Auth/IDataRegisterForm";
import { UserModels } from "../../../Models/User.models";
import { axiosMethod } from "../../../Utils/axiosMethod";

interface IResponseLogin {
    UserAdapted: UserModels;
    MessageError: string;
}

interface IResponseRegister {
    Data : string;
    MessageError : string;
}

const AuthService = {
    
    Login: async (DataLoginForm: IDataLoginForm): Promise<IResponseLogin> => {
        
        /// VER TEMA DE CONEXION BACK con el tema de las respuestas en caso de error y no error
        const Response = await axiosMethod<AuthData>({
            method: "POST",
            url: "/Auth/Login",
            dataSend: DataLoginForm,
        });
        
        let UserAdapted = {} as UserModels;
        
        if (Response != null && Response.Data != null && Response.MessageError == null) {
            UserAdapted = createAddaptedUser(Response.Data);
        }

        return {
            UserAdapted,
            ...Response.MessageError
        };
    },

    Register: async (DataRegisterForm: IDataRegisterForm): Promise<IResponseRegister> => {

        const { Data, MessageError } = await axiosMethod<string>({
            method: "POST",
            url: "/Auth/Register",
            dataSend: DataRegisterForm,
        });

        return {
            Data,
            MessageError,
        };
    }

}

export default AuthService; 