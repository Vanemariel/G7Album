using G7Album.BaseDatos.Data.Comun;
using G7Album.BaseDatos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G7Album.BaseDatos.Data.Entidades
{
    public class Roles : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
