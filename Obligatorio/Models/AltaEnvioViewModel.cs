using DTO;
using LogicaNegocio.EntidadesDominio;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Models
{
    public class AltaEnvioViewModel
    {
        public AltaEnvioDTO DTO { get; set; }

        public List<AgenciaDTO> Agencias { get; set; } = new();

        public List<EnvioDTO> Envios { get; set; } = new(); 

        public bool SoloEnProceso { get; set; }
    }
}
