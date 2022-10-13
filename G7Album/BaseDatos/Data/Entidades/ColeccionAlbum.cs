using G7Album.BaseDatos.Data.Comun;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G7Album.BaseDatos.Entidades
{
    public class ColeccionAlbum :BaseEntity
    {

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string TituloColeccion {get; set;}


        [InverseProperty("ColeccionAlbum")]
        public List<Album> ListadoAlbum {get; set;}

    }
}
