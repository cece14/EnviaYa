using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class ObtenerEnvios : IObtenerEnvios
    {
        private readonly IRepositorioEnvios RepoEnvios;

        public ObtenerEnvios(IRepositorioEnvios repo)
        {
            RepoEnvios = repo;
        }

        public List<EnvioDTO> ObtenerTodos()
        {
            
            var lista = RepoEnvios.ObtenerTodosConSeguimientos();
            return EnviosMapper.ToDTOs(lista);
        }

    

        public List<EnvioDTO> ObtenerEnProceso()
        {
            var lista = RepoEnvios.FindEnProceso(); 
            return EnviosMapper.ToDTOs(lista);
        }

        public EnvioDTO ObtenerPorId(int id)
        {
            var envio = RepoEnvios.FindById(id);
            return envio == null ? null : EnviosMapper.ToDTO(envio);
        }
    }
}