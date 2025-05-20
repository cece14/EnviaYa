using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioClientes : IRepositorio<Cliente>
    {
        Cliente BuscarPorEmail(string email);
        void Delete(int id);

    }
}
