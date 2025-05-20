using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class EnvioUrgente : Envio
    {
        public string DireccionPostal { get; private set; }
        public bool EntregaEficiente { get; private set; }

        public EnvioUrgente(Cliente cliente, string direccionPostal, string nroTracking, double peso, DateTime fechaSalida)
        {
            Cliente = cliente;
            DireccionPostal = direccionPostal;
            NroTracking = nroTracking;
            Peso = peso;
            FechaSalida = fechaSalida;
            EstadoActual = Estado.EN_PROCESO;
        }
        public EnvioUrgente() { }

        public override void Validar()
        {
            base.Validar();
            if (string.IsNullOrWhiteSpace(DireccionPostal))
                throw new DatosInvalidosException("Debe ingresar dirección postal en un envío urgente.");

            if (AgenciaDeRetiro != null)
                throw new AgenciaInvalidaException("No debe seleccionar agencia en un envío urgente.");
        }

        public override double CalcularEficiencia()
        {
            if (FechaEntrega == DateTime.MinValue)
            {
                EntregaEficiente = false;
                return 0;
            }

            double horas = (FechaEntrega - FechaSalida).TotalHours;
            EntregaEficiente = horas <= 24;

            return EntregaEficiente ? 100 : 0;
        }
    }
}