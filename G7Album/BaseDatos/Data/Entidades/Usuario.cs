using G7Album.BaseDatos.Data.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace G7Album.BaseDatos.Entidades
{
    public class Usuario : BaseEntity
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Codigo del album no puede superar {1} caracteres")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Codigo del album no puede superar {1} caracteres")]
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; } 

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Codigo del album no puede superar {1} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Codigo del album no puede superar {1} caracteres")]
        public string Apellido { get; set; }


    }
}
