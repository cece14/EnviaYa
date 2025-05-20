using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class ObtenerAgencias : IObtenerAgencias
    {
        public  IRepositorioAgencias Repo;

        public ObtenerAgencias(IRepositorioAgencias repo)
        {
            Repo = repo;
        }

        public List<AgenciaDTO> ObtenerTodas()
        {
            IEnumerable<Agencia> agencias = Repo.FindAll();
            List<AgenciaDTO> agenciasDTO = AgenciasMapper.ToDTOs(agencias);
            return agenciasDTO;
        }
    }
}