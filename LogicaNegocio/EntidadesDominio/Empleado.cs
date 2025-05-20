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
    public  class  Empleado 
    {
        [Key]
        public int Id { get; set; }
        public Email Email { get; set; } //Value Object 
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Rol Rol { get; set; }
        public Usuario Usuario { get; private set; }

        public string Telefono { get; set; }

        public Empleado() { }

        public Empleado(string nombre, string apellido, Email email, string password, Rol rol, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Telefono = telefono;
            Rol = rol;
            Validar();

           
        }

        
        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new EmpleadoInvalidoException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(Apellido))
                throw new EmpleadoInvalidoException("El apellido es obligatorio.");

            if (Email == null || string.IsNullOrWhiteSpace(Email.Valor))
                throw new EmpleadoInvalidoException("El email es obligatorio.");

            if (string.IsNullOrWhiteSpace(Password))
                throw new EmpleadoInvalidoException("La contraseña es obligatoria.");

            if (Password.Length < 8)
                throw new EmpleadoInvalidoException("La contraseña debe tener al menos 8 caracteres.");

            if (!Password.Any(char.IsUpper))
                throw new EmpleadoInvalidoException("La contraseña debe contener al menos una letra mayúscula.");

            if (!Password.Any(char.IsLower))
                throw new EmpleadoInvalidoException("La contraseña debe contener al menos una letra minúscula.");

            if (!Password.Any(char.IsDigit))
                throw new EmpleadoInvalidoException("La contraseña debe contener al menos un número.");

            if (string.IsNullOrWhiteSpace(Telefono))
                throw new EmpleadoInvalidoException("El teléfono es obligatorio.");
            if (Rol == Rol.Cliente)
                throw new RolInvalidoException("No se puede asignar el rol 'Cliente' a un empleado.");


        }
    }
}
