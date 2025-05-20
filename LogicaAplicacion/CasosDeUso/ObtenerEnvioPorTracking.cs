using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class ObtenerEnvioPorTracking : IObtenerEnvioPorTracking
    {
        private readonly IRepositorioEnvios RepoEnvios;

        public ObtenerEnvioPorTracking(IRepositorioEnvios repo)
        {
            RepoEnvios = repo;
        }

        public EnvioDTO ObtenerPorTracking(string nroTracking)
        {
            var envio = RepoEnvios.BuscarPorNroTracking(nroTracking);
            return envio == null ? null : EnviosMapper.ToDTO(envio);
        }
    }
}
