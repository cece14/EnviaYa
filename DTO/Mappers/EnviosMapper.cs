using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
   public class EnviosMapper
    {
        public static Envio FromDTO(AltaEnvioDTO dto, Cliente c, Agencia a, string nroTracking)
        {
            DateTime fechaSalida = DateTime.Now;

            if (dto.TipoEnvio == "Urgente")
            {
                return new EnvioUrgente(c, dto.DireccionPostal?.Trim(), nroTracking, dto.Peso, fechaSalida);
            }
            else if (dto.TipoEnvio == "Estandar")
            {
                return new EnvioEstandar(c, a, nroTracking, dto.Peso, fechaSalida);
            }

            return null;
        }


        public static AgenciaDTO ToDTO(Agencia a)
        {
            return new AgenciaDTO
            {
                Id = a.Id,
                Nombre = a.Nombre
            };
        }
        public static EnvioDTO ToDTO(Envio e)
        {
            return new EnvioDTO
            {
                Id = e.Id,
                Tipo = e is EnvioUrgente ? "Urgente" : "Estandar",
                Estado = e.EstadoActual.ToString(),
                EmailCliente = e.Cliente.Email.Valor,
                Agencia = e is EnvioEstandar ? e.AgenciaDeRetiro?.Nombre : null,
                DireccionPostal = e is EnvioUrgente u ? u.DireccionPostal : null,
                FechaSalida = e.FechaSalida,
               
                FechaEntrega = e.FechaEntrega,
                Peso = e.Peso,
                EntregaEficiente = e is EnvioUrgente urg ? urg.EntregaEficiente : null,
                NroTracking = e.NroTracking,
                UltimoComentario = e.Seguimientos?
                    .OrderByDescending(s => s.Fecha)
                    .FirstOrDefault()?.Comentario // Solo el más reciente
            };
        }

        public static List<EnvioDTO> ToDTOs(IEnumerable<Envio> envios)
        {
            return envios.Select(ToDTO).ToList();
        }

    }
}
