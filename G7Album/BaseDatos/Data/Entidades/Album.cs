using G7Album.BaseDatos.Data.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
