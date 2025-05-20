using ExcepcionesPropias;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DireccionPostal { get; set; }
        public Ubicacion Ubicacion { get; set; }

     
        public Agencia() { }
        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new AgenciaInvalidaException("El nombre de la agencia es obligatorio.");

            if (string.IsNullOrWhiteSpace(DireccionPostal))
                throw new AgenciaInvalidaException("La dirección postal de la agencia es obligatoria.");

            if (Ubicacion == null)
                throw new AgenciaInvalidaException("La ubicación de la agencia es obligatoria.");
        }
    }

}