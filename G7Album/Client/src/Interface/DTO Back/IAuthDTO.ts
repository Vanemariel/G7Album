export interface IAuthDTO {
    User: {
        Id: string; 
        Name: string; 
        Email: string;
        Lastname: string;
        UserName: string;
    }
    Token: string;
}