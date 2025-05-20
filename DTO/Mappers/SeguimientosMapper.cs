using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public static class SeguimientosMapper
    {
        public static SeguimientoDTO ToDTO(Seguimiento s)
        {
            return new SeguimientoDTO
            {
                Comentario = s.Comentario,
                Fecha = s.Fecha,
                EmpleadoNombre = s.Empleado.Nombre + " " + s.Empleado.Apellido
            };
        }

        public static IEnumerable<SeguimientoDTO> ToDTOs(IEnumerable<Seguimiento> seguimientos)
        {
            return seguimientos.Select(ToDTO).ToList();
        }
    }
}
