export interface AuthData {
    user: {
        id: string; 
        nombreCompleto: string; 
        email: string;
    }
    token: string;
}