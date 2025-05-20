using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class ObtenerEmpleados : IObtenerEmpleados
    {
        public IRepositorioEmpleados Repo { get; set; }

        public ObtenerEmpleados(IRepositorioEmpleados repo)
        {
            Repo = repo;
        }
        public Empleado FindById(int id)
        {
            return Repo.FindById(id); 
        }

        public List<EmpleadoDTO> ObtenerTodos()
        {
            List<Empleado> empleados = Repo.FindAll().ToList();
            List<EmpleadoDTO> DTO = EmpleadosMapper.ToDTOs(empleados);
            return DTO;
        }
    }
}
