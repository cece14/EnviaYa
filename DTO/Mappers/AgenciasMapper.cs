using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public static class AgenciasMapper
    {
        public static AgenciaDTO ToDTO(Agencia agencia)
        {
            return new AgenciaDTO
            {
                Id = agencia.Id,
                Nombre = agencia.Nombre
            };
        }

        public static List<AgenciaDTO> ToDTOs(IEnumerable<Agencia> agencias)
        {
            List<AgenciaDTO> lista = new List<AgenciaDTO>();

            foreach (Agencia a in agencias)
            {
                lista.Add(ToDTO(a));
            }

            return lista;
        }
    }
}
