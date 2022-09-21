 import { axiosMethod } from "../../../Utils/axiosMethod";
// import { createAddaptedUser } from "../Adapters/CreateAddapterdUser";
// import { EndPointDataLogin } from "../DTO/EndPointUser.models";
// import { UserLogin } from "../Models/UserLogin.models";

// export const Login = async (dataUser: UserLogin) => {
//   let dataLogin = null;
//   const { data, messageError } = await axiosMethod({
//     method: "POST",
//     url: "/login",
//     dataSend: dataUser,
//   });

//   if (data !== null && data.User !== null && data.Token !== null) {
//     dataLogin = createAddaptedUser(data as EndPointDataLogin<string>);
//   }

//   return {
//     ...dataLogin,
//     messageError,
//   };
// };
