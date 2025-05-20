using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class FinalizarEnvio : IFinalizarEnvio
    {
        private IRepositorioEnvios Repo;

        public FinalizarEnvio(IRepositorioEnvios repo)
        {
            Repo = repo;
        }
        public void Finalizar(int id, DateTime fechaEntrega)
        {
            var envio = Repo.FindById(id) ?? throw new EnvioInvalidoException("Envío no encontrado.");

            envio.ValidarFinalizacion(fechaEntrega);

            envio.FechaEntrega = fechaEntrega;
            envio.EstadoActual = Estado.FINALIZADO;

            if (envio is EnvioUrgente envioUrgente)
            {
                envioUrgente.CalcularEficiencia();
            }

            Repo.Update(envio);
        }
    }
}