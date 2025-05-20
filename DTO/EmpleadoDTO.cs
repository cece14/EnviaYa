using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; } 

        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
        public string Apellido { get; set; } 

        [EmailAddress(ErrorMessage = "Debe ingresar un email válido")]
        public string Email { get; set; } 

        public string Telefono { get; set; } 

        public DateTime FechaAlta { get; set; } 

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La contraseña debe tener entre 4 y 50 caracteres")]
        public string Password { get; set; } 

        [Required(ErrorMessage = "Debe seleccionar un rol")]
        
        public RolDTO Rol { get; set; }
    }
}