/*
 No es necesario hacer una interface con
  parametros pero sirve de practica
*/

export interface DataLogin<TypeIdUser> {
  User: UserModels<TypeIdUser>;
  Token: string;
}

interface UserModels<TypeIdUser> {
  Id: TypeIdUser;
  UserName: string;
  Name: string;
  Lastname: string;
  Email: string;
}