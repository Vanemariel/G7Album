import { AuthData } from "../Interface/DTO Back/Auth/AuthData";
import { UserModels } from "../Models/User.models";

export const createMapperUser = (AuthData: AuthData): UserModels => {

    const formattedUser: UserModels = {
        Id: AuthData.user?.id,
        FullName: AuthData.user?.nombreCompleto,
        Email: AuthData.user?.email,
        Token: AuthData.token,
    };

    return formattedUser;
};
