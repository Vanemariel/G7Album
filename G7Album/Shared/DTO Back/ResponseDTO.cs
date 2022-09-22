namespace G7Album.Shared.DTO_Back
{
    public class ResponseDto<TypeData>
    {
        public TypeData Data { get; set; } //Informacion
      
        public string MessageError { get; set; }
    }
}