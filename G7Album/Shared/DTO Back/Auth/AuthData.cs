namespace G7Album.Shared.DTO_Back 
{
    public class User
    { 
        public int Id { get; set; }  
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; }

    }

    public class AuthData
    {
        public User User { get; set; }
        public string Token { get; set; }
        
    }
}