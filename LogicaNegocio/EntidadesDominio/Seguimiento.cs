using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    
        public class Seguimiento
        {
                public int Id { get; set; }
              
                public string Comentario { get; set; }         
                public DateTime Fecha { get; set; }       
                public Envio Envio { get; set; }            
                public Empleado Empleado { get; set; }
                public int EmpleadoId { get; set; }
                public int EnvioId { get; set; }
        public Seguimiento(Envio envio, Empleado empleado, string comentario)
        {
            Envio = envio;
            Empleado = empleado;
            Comentario = comentario;
            Fecha = DateTime.Now;
            Validar();
        }


        public Seguimiento() { }
        public void Validar()
        {
            if (Envio == null)
                throw new EnvioInvalidoException("El envío no puede ser nulo.");

            if (Envio.EstadoActual == Estado.FINALIZADO)
                throw new EnvioInvalidoException("No se puede comentar un envío que ya fue finalizado.");

            if (Empleado == null)
                throw new EmpleadoInvalidoException("El empleado no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(Comentario))
                throw new Exception("El comentario no puede estar vacío.");
        }
    }




    }

