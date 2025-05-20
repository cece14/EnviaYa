using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Auditoria
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Accion { get; set; } 
        public string UsuarioEmail { get; set; } 
        public int EmpleadoId { get; set; } 
    }
}
    