using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class EnvioEstandar : Envio
    {
        public EnvioEstandar(Cliente cliente, Agencia agencia, string nroTracking, double peso, DateTime fechaSalida)
        {
            Cliente = cliente;
            AgenciaDeRetiro = agencia;
            NroTracking = nroTracking;
            Peso = peso;
            FechaSalida = fechaSalida;
            EstadoActual = Estado.EN_PROCESO;
        }
        public EnvioEstandar() { }
        public override double CalcularEficiencia()
        {
            return 0; 
        }

        public override void Validar()
        {
            base.Validar();

            if (AgenciaDeRetiro == null)
                throw new AgenciaInvalidaException("Debe seleccionar una agencia para un envío estándar.");

            AgenciaDeRetiro.Validar(); 
    }
}
}