using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
   public class EmpleadoInvalidoException : Exception
    {
        public EmpleadoInvalidoException(string mensaje) : base(mensaje) { }
    }
}
