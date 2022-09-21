import { createAddaptedUser } from "../../../Adapters/User.adapters";
import { IDataLoginForm } from "../../../Interface/DTO Front/Auth/IDataLoginForm";
import { IDataRegisterForm } from "../../../Interface/DTO Front/Auth/IDataRegisterForm";
import { axiosMethod } from "../../../Utils/axiosMethod";


const AuthService = {
    
    Login: async (DataLoginForm: IDataLoginForm): Promise<object> => {

        let dataLogin = null;
        const { data, messageError } = await axiosMethod({
            method: "POST",
            url: "/Auth/Login",
            dataSend: DataLoginForm,
        });

        if (data !== null && data.User !== null && data.Token !== null) {
            dataLogin = createAddaptedUser(data as any);
        }

        return {
            dataLogin,
            messageError,
        };
    },

    Register: async (DataRegisterForm: IDataRegisterForm): Promise<object> => {

        const { data, messageError } = await axiosMethod({
            method: "POST",
            url: "/Auth/Register",
            dataSend: DataRegisterForm,
        });

        return {
            data,
            messageError,
        };
    }

}

export default AuthService; 