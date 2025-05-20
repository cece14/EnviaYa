using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class Ubicacion
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public Ubicacion(double latitud, double longitud)
        {
            if (latitud < -90 || latitud > 90)
                throw new ArgumentOutOfRangeException(nameof(latitud), "La latitud debe estar entre -90 y 90.");

            if (longitud < -180 || longitud > 180)
                throw new ArgumentOutOfRangeException(nameof(longitud), "La longitud debe estar entre -180 y 180.");

            Latitud = latitud;
            Longitud = longitud;
        }
    }
}
