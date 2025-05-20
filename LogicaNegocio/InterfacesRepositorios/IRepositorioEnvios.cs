using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvios : IRepositorio<Envio>
    {
        void Add(Envio envio);
        Envio FindById(int id);
        void Update(Envio e);
        IEnumerable<Envio> FindAll();
       
        IEnumerable<Envio> FindEnProceso();

        Envio BuscarPorNroTracking(string nroTracking);

        List<Envio> ObtenerTodosConSeguimientos();
    }
}
