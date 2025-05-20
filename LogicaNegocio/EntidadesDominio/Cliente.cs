using LogicaNegocio.ValueObjects;
using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace LogicaNegocio.EntidadesDominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Email Email { get; set; }
        
        public List<Envio> Envios { get; set; } = new();

        public Cliente() { }

        public Cliente(string nombre, string apellido, string documento, string telefono, string direccion, Email email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
           
    }
}
}
