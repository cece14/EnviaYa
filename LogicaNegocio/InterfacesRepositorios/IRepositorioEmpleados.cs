using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEmpleados : IRepositorio<Empleado>
    {
        bool ExisteEmail(string email);
        Empleado BuscarPorEmail(string email);
        Empleado BuscarPorEmailUsuario(string emailUsuario);

    }
}
