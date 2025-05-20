using DTO;
using LogicaNegocio.EntidadesDominio;
using System.ComponentModel.DataAnnotations;
namespace Obligatorio.Models
{
    public class AltaSeguimientoViewModel
    {
        public AltaSeguimientoDTO DTO { get; set; }
        public string? NombreCliente { get; set; }
        public string? DireccionPostal { get; set; }

        // Historial de seguimientos
        public List<SeguimientoDTO> SeguimientosAnteriores { get; set; } = new();
    }
}
