using G7Album.BaseDatos.Data.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G7Album.BaseDatos.Entidades
{
    public class AlbumUsuario : BaseEntity
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Codigo del album no puede superar {1} caracteres")]
        public string CodigoAlbumUsuario{ get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Codigo del album no puede superar {1} caracteres")]
        public string CodigoAlbum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int UsuarioId { get; set; }

        //  [InverseProperty("AlbumId")]
        // public List<AlbumUsuario> ListaAlbumUsuario {get; set;}


        [ForeignKey("AlbumId")]
        public Album Album { get; set; }


        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

    }
}
