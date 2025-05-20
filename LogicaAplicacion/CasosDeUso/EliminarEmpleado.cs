using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
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
    public class EliminarEmpleado : IEliminarEmpleado
    {
        private IRepositorioEmpleados Repo { get; set; }
        private IRepositorioAuditorias RepoAuditorias { get; set; }

        public EliminarEmpleado(IRepositorioEmpleados repo, IRepositorioAuditorias repoAuditorias)
        {
            Repo = repo;
            RepoAuditorias = repoAuditorias;
        }

        public void Eliminar(int id, string usuarioEmail)
        {
            Empleado empleadoExistente = Repo.FindById(id);

            if (empleadoExistente == null)
                throw new DatosInvalidosException("Empleado no encontrado.");

            
            Repo.Remove(id);

            
          

           
        }
        public EmpleadoDTO Buscar(int id)
        {
            Empleado empleado = Repo.FindById(id);

            if (empleado == null)
                return null;

            return EmpleadosMapper.ToEmpleadoDTO(empleado);
        }
    }
}