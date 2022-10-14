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
    public class AlbumImagenes : BaseEntity 
    {
        [Required(ErrorMessage = "Campo obligatorio.")]   
        public int NumeroImagen { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public int CodigoImagenOriginal { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public int CantidadImpresa { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Imagen { get; set; }

        //[Required(ErrorMessage = "Campo obligatorio.")]
        //public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Titulo { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        public int AlbumId { get; set; }


        //Claves foraneas
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

    }
}
