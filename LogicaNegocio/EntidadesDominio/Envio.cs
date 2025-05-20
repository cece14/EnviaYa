using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public abstract class Envio
    {
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
      
        public DateTime FechaEntrega { get; set; }
        public bool SeRetiraEnAgencia { get; set; }
        public int? AgenciaDeRetiroId { get; set; }          
        public Agencia? AgenciaDeRetiro { get; set; }         
        public double Peso { get; set; }
        public Estado EstadoActual { get; set; }
        public Cliente Cliente { get; set; }
        public List<Seguimiento> Seguimientos { get; set; } = new();

        public string NroTracking { get; set; }
        public abstract double CalcularEficiencia();
        public virtual void Validar()
        {
            
        }


        public virtual void ValidarFinalizacion(DateTime fechaEntrega)
        {
            ValidarEstadoFinalizado();
            ValidarFechaEntrega(fechaEntrega);
        }

        private void ValidarEstadoFinalizado()
        {
            if (EstadoActual == Estado.FINALIZADO)
                throw new EnvioInvalidoException("El envío ya fue finalizado.");
        }

        private void ValidarFechaEntrega(DateTime fechaEntrega)
        {
            if (fechaEntrega < FechaSalida)
                throw new DatosInvalidosException("La fecha de entrega no puede ser anterior a la fecha de salida.");
        }
    }
}


