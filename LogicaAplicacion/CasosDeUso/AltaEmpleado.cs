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
    public class AltaEmpleado : IAltaEmpleado
    {
        private IRepositorioEmpleados RepoEmpleados { get; set; }
         private IRepositorioUsuarios RepoUsuarios { get; set; }
        private IRepositorioAuditorias RepoAuditorias { get; set; }

        public AltaEmpleado(IRepositorioEmpleados repo, IRepositorioAuditorias repoAuditorias, IRepositorioUsuarios repositorioUsuarios)
        {
            RepoEmpleados = repo;
            RepoAuditorias = repoAuditorias;
            RepoUsuarios = repositorioUsuarios;
        }



        public void EjecutarAlta(AltaEmpleadoDTO dto, string usuarioEmail)
        {
            if (RepoEmpleados.ExisteEmail(dto.Email))
                throw new EmailInvalidoException($"El email '{dto.Email}' ya está registrado en el sistema.");

            var empleado = EmpleadosMapper.ToEmpleado(dto); 

            RepoEmpleados.Add(empleado);

            var usuario = UsuariosMapper.CrearDesdeEmpleadoYDTO(empleado, dto);
            RepoUsuarios.Add(usuario);

            
                
            
        }
    }
}
