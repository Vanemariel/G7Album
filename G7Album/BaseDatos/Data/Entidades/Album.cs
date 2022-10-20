using G7Album.BaseDatos.Data.Comun;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G7Album.BaseDatos.Entidades
{
    public class Album :BaseEntity
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CodigoAlbum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Titulo del album no puede superar {1} caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(1000, ErrorMessage = "El Titulo del album no puede superar {1} caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CantidadImagen { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CantidadImpreso { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime Desde { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime Hasta { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int ColeccionAlbumId {get; set;}
        
        [ForeignKey("ColeccionAlbumId")]
        public ColeccionAlbum ColeccionAlbum {get; set;}

         [Required(ErrorMessage = "Campo obligatorio.")]
        public string Imagen { get; set; }




        [InverseProperty("Album")]
        public List<AlbumImagenes> ListadoImagenes {get; set;}
    }
}
