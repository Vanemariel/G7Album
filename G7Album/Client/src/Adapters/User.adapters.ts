// import { EndPointDataLogin } from "../DTO/EndPointUser.models";
import { AuthData } from "../Interface/DTO Back/Auth/AuthData";
import { UserModels } from "../Models/User.models";

export const createAddaptedUser = (AuthData: AuthData): UserModels => {
  
  const formattedUser: UserModels = {
    Id: AuthData.User.Id,
    Name: AuthData.User.Name,
    Email: AuthData.User.Email,
    Lastname: AuthData.User.Lastname,
    UserName: AuthData.User.UserName,
    Token: AuthData.Token,
  };

  return formattedUser;
};
