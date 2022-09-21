// import { EndPointDataLogin } from "../DTO/EndPointUser.models";
import { DataLogin } from "../Models/User.models";

export const createAddaptedUser = (
  // DataLogin: EndPointDataLogin<string>
  DataLogin: any
) => {
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
