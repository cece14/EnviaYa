using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AltaEnvioDTO
    {
        [Required]
        public string TipoEnvio { get; set; }

        [Required(ErrorMessage = "Debe ingresar el email del cliente.")]
        public string EmailCliente { get; set; }

        public int? AgenciaId { get; set; }

        public string? DireccionPostal { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar un peso válido")]
        public double Peso { get; set; }
       
    }

}
