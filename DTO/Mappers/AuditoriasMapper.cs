using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public static class AuditoriasMapper
    {
        public static Auditoria FromEmpleado(string accion, Empleado empleado, string usuarioEmail)
        {
            return new Auditoria
            {
                FechaHora = DateTime.Now,
                Accion = accion,
                UsuarioEmail = usuarioEmail,
                EmpleadoId = empleado.Id
            };
        }
    }
}
