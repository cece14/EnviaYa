    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AltaEmpleadoDTO
    {
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Telefono { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        public RolDTO Rol { get; set; }
    }
}
