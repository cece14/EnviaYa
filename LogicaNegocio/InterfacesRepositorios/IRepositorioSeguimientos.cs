using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioSeguimientos
    {
        void Add(Seguimiento seguimiento);

        List<Seguimiento> ObtenerPorEnvioId(int envioId);
        
    }
}
