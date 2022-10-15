export interface IAuthData {
    user: {
        id: string; 
        nombreCompleto: string; 
        email: string;
    }
    token: string;
}