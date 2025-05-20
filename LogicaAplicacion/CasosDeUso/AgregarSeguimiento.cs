using DTO;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesPropias;


namespace LogicaAplicacion.CasosDeUso 
{
    public class AgregarSeguimiento : IAgregarSeguimiento
    {
        private IRepositorioSeguimientos RepoSeguimientos;
        private IRepositorioEnvios RepoEnvios;
        private IRepositorioEmpleados RepoEmpleados;

        public AgregarSeguimiento(IRepositorioSeguimientos repoSeguimientos, IRepositorioEnvios repoEnvios, IRepositorioEmpleados repoEmpleados)
        {
            RepoSeguimientos = repoSeguimientos;
            RepoEnvios = repoEnvios;
            RepoEmpleados = repoEmpleados;
        }
        public void Agregar(AltaSeguimientoDTO dto)
        {
            var envio = RepoEnvios.FindById(dto.EnvioId)
                ?? throw new EnvioInvalidoException("Envío no encontrado.");

            var empleado = RepoEmpleados.BuscarPorEmail(dto.EmailEmpleado)
                ?? throw new EmpleadoInvalidoException("No se encontró el empleado seleccionado.");

            var seguimiento = new Seguimiento(envio, empleado, dto.Comentario);

            RepoSeguimientos.Add(seguimiento);
        }

    }
}
