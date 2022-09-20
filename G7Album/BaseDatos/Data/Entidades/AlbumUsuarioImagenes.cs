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
    public class AlbumUsuarioImagenes : BaseEntity 
    {
        [Required(ErrorMessage = "Campo obligatorio.")]
        //preguntar xq tin y int
        public string EstaPegada { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public int AlbumUsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public int AlbumImagenImpresaId { get; set; }

        //claves foraneas
        [ForeignKey("AlbumUsuarioId")]
        public AlbumUsuario AlbumUsuario { get; set; }

        [ForeignKey("AlbumImagenImpresaId")]
        public AlbumImagenImpresa AlbumImagenImpresa { get; set; }



    }
}
