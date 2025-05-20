using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;

namespace LogicaAplicacion.CasosDeUso
{
    public class ObtenerEmpleadoPorUsuario : IObtenerEmpleadoPorUsuario
    {
        private IRepositorioEmpleados repoEmpleados;

        public ObtenerEmpleadoPorUsuario(IRepositorioEmpleados RepoEmpleados)
        {
            repoEmpleados = RepoEmpleados;
        }

        public string ObtenerEmailEmpleadoPorEmailUsuario(string emailUsuario)
        {
            Empleado empleado = repoEmpleados.BuscarPorEmailUsuario(emailUsuario);
            return empleado?.Email?.Valor?.Trim().ToLower();
        }
    }
}