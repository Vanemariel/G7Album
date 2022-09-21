/*
 No es necesario hacer una interface con
  parametros pero sirve de practica
*/
/// Esto seria un Dto Back
export interface EndPointDataLogin<TypeIdUser> {
  user: EndPointUserModels<TypeIdUser>;
  token: string;
}

interface EndPointUserModels<TypeIdUser> {
  _id: TypeIdUser;
  user_name: string;
  name_completed: string;
  last_name: string;
  email: string;
}
