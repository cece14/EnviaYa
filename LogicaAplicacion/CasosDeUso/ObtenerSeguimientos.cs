using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class ObtenerSeguimientos : IObtenerSeguimientos
    {
        private IRepositorioSeguimientos RepoSeguimientos;

        public ObtenerSeguimientos(IRepositorioSeguimientos repo)
        {
            RepoSeguimientos = repo; 
        }

        public List<SeguimientoDTO> ObtenerSeguimientosPorEnvio(int envioId)
        {
            IEnumerable<Seguimiento> seguimientos = RepoSeguimientos.ObtenerPorEnvioId(envioId);
            List<SeguimientoDTO> seguimientosDTO = SeguimientosMapper.ToDTOs(seguimientos).ToList();

            return seguimientosDTO;
        }
    }
}

