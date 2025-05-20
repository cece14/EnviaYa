using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Mappers;
using DTO;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaDatos.Repositorios;
using ExcepcionesPropias;


namespace LogicaAplicacion.CasosDeUso
{
    public class EditarEmpleado: IEditarEmpleado
    {
        private IRepositorioEmpleados RepoEmpleados { get; set; }
        private IRepositorioAuditorias RepoAuditorias { get; set; }

        public EditarEmpleado(IRepositorioEmpleados repo, IRepositorioAuditorias repoAuditorias)
        {
            RepoEmpleados = repo;
            RepoAuditorias = repoAuditorias;
        }

        public void Editar(EmpleadoDTO dto, string usuarioEditor)
        {
            var empleadoExistente = RepoEmpleados.FindById(dto.Id);

            if (empleadoExistente == null)
                throw new DatosInvalidosException("Empleado no encontrado.");

            
            if (empleadoExistente.Email.Valor != dto.Email)
            {
                if (RepoEmpleados.ExisteEmail(dto.Email))
                    throw new EmailInvalidoException("Ya existe un empleado con ese email.");
            }

          
            if (RolesMapper.MapearDesdeDTO(dto.Rol) == Rol.Cliente)
                    throw new RolInvalidoException("No se puede asignar el rol 'Cliente' a un empleado.");

           
            EmpleadosMapper.MapearDatosEnEmpleadoExistente(empleadoExistente, dto);
            empleadoExistente.Validar();

           
            RepoEmpleados.Update(empleadoExistente);

           
         
        }
        public EmpleadoDTO ObtenerEmpleadoPorId(int id)
        {
            var empleado = RepoEmpleados.FindById(id);
            if (empleado == null)
                return null;

            return EmpleadosMapper.ToEmpleadoDTO(empleado);  

    }
}
}