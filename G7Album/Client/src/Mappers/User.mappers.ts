import { IAuthData } from "../Interface/DTO Back/Auth/IAuthData";
import { UserModels } from "../Models/User.models";

export const createMapperUser = (AuthData: IAuthData): UserModels => {

    const formattedUser: UserModels = {
        Id: AuthData.user?.id,
        FullName: AuthData.user?.nombreCompleto,
        Email: AuthData.user?.email,
        Token: AuthData.token,
    };

    return formattedUser;
};
