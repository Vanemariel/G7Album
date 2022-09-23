import { AuthData } from "../Interface/DTO Back/Auth/AuthData";
import { UserModels } from "../Models/User.models";

export const createAddaptedUser = (AuthData: AuthData): UserModels => {
  
    const formattedUser: UserModels = {
        Id: AuthData.User?.Id,
        FullName: AuthData.User?.NombreCompleto,
        Email: AuthData.User?.Email,
        Token: AuthData.Token,
    };

    return formattedUser;
};
