using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FinalizarEnvioDTO
    {
        public int Id { get; set; }
        public DateTime? FechaEntrega { get; set; }

        // Agregá estos dos:
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
    }
}
