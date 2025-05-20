using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class EnvioInvalidoException : Exception
    {
        public EnvioInvalidoException(string mensaje) : base(mensaje) { }
    }
}
