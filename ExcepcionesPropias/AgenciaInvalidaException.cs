using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class AgenciaInvalidaException : Exception
    {
        public AgenciaInvalidaException(string mensaje) : base(mensaje) { }
    
}
}
