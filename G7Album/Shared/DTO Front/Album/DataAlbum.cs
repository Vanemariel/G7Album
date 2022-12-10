namespace G7Album.Shared.DTO_Front
{

    public class DataAlbum
    {
        public int IdColeccion { get; set; }
        public int CodigoAlbum { get; set; }
        public string? Titulo { get; set; }
        public string? ImgAlbum { get; set; }

        public string Descripcion { get; set; }
        public int CantidadImagen { get; set; }
        public int CantidadImpreso { get; set; }
    }
}
