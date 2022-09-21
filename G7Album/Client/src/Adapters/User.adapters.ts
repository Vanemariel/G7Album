// import { EndPointDataLogin } from "../DTO/EndPointUser.models";
import { UserModels } from "../Models/User.models";

export const createAddaptedUser = (DataUser: any): UserModels => {
  
  const formattedUser: any = {
  // const formattedUser: DataLogin<string> = {
    // User: {
    //   Id: DataLogin.user._id,
    //   Name: DataLogin.user.name_completed,
    //   Email: DataLogin.user.email,
    //   Lastname: DataLogin.user.last_name,
    //   UserName: DataLogin.user.user_name,
    // },
    // Token: DataLogin.token,
  };

  return formattedUser;
};
