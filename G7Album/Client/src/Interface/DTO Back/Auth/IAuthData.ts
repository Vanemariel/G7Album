export interface IAuthData {
    user: {
        id: number; 
        nombreCompleto: string; 
        email: string;
    }
    token: string;
}