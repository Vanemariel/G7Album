using G7Album.BaseDatos.Entidades;

namespace G7Album.Shared.Models
{
    public class Response<TypeData> 
    {
        //public Response()
        //{
        //}

        public List<Album> TablaAlbumes { get; set; } = new List<Album>();
        public List<AlbumImagenImpresa> TablaImagenesImpresas { get; set; } = new List<AlbumImagenImpresa>();
        public List<AlbumImagenes> TablaImagenes { get; set; } = new List<AlbumImagenes>();   
        public List<AlbumUsuarioImagenes> TablaUsuarioImagenes { get; set; } = new List<AlbumUsuarioImagenes>();
        public List<ColeccionAlbum> TablaColeccionAlbumes { get; set; } = new List<ColeccionAlbum>();

        public int Pages { get; set; }
        public int CurrentPage { get; set; }

        //public Response(TypeData data, bool succeeded = true, string[] errors = null, string message = "Success")
        //{
        //    Data = data;
        //    Succeeded = succeeded;
        //    Errors = errors;
        //    Message = message;
        //}

        //public TypeData Data { get; set; }
        //public bool Succeeded { get; set; }
        //public string[] Errors { get; set; }
        //public string Message { get; set; }
    }
    public static class ResponseMessage
    {
        public const string Success = "Success";
        public const string Error = "Error";
        public const string NotFound = "Record not found";
        public const string NotFoundOrDeleted = "Entity not found or deleted";
        public const string ValidationErrors = "Validations errors found";
        public const string UnexpectedErrors = "An unexpected error occurred, try again later";
    }
}
