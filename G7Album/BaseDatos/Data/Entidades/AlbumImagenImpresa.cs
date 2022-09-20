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
    public class AlbumImagenImpresa : BaseEntity
    {
        [Required(ErrorMessage = "Campo obligatorio.")]
        public int CodigoImagenImpresa { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string PathImagenImpreso { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public int AlbumImagenId { get; set; }


        //claves foraneas
        [ForeignKey("AlbumImagenId")]
        public AlbumImagenes AlbumImagenes { get; set; }
    }
}
