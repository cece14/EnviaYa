using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EnvioDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; } 
        public string Estado { get; set; } 
        public string EmailCliente { get; set; }
        public string? Agencia { get; set; } 
        public string? DireccionPostal { get; set; } 
        public DateTime FechaSalida { get; set; }
       
        public double Peso { get; set; }
        public string ClienteEmail { get; set; }

        public bool? EntregaEficiente { get; set; }
                                                       
        public DateTime? FechaEntrega { get; set; } // si querés permitir null
        public string NroTracking { get; set; }

        public string UltimoComentario { get; set; } 

        public List<SeguimientoDTO> Seguimientos { get; set; }


    }
}
