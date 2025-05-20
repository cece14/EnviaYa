using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    { 

    public LogisticaContext Contexto { get; set; }

    public RepositorioUsuarios(LogisticaContext ctx)
    {
        Contexto = ctx;
    }
        public void Add(Usuario obj)
        {
            if (obj == null)
            {
                throw new UsuarioInvalidoException("No se proporciona información del usuario.");
            }

            obj.Validar(); 
            
            Usuario usuarioExistente = BuscarPorEmail(obj.Email.Valor);
            if (usuarioExistente != null)
            {
                throw new UsuarioInvalidoException("Ya existe un usuario registrado con este correo electrónico.");
            }

            Contexto.Usuarios.Add(obj);
            Contexto.SaveChanges();
        }
        public Empleado BuscarPorEmailUsuario(string emailUsuario)
        {
            return Contexto.Empleados
                .Include(e => e.Usuario)
                .FirstOrDefault(e => e.Usuario != null && e.Usuario.Email.Valor == emailUsuario);
        }
        public Usuario BuscarPorEmail(string mail)
        {
            return Contexto.Usuarios
                .Where(usu => usu.Email.Valor == mail)
                .SingleOrDefault();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }
        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string password)
        {
            Usuario buscado = Contexto.Usuarios
                .Where(usu => usu.Email.Valor == email && usu.Password == password)
                .SingleOrDefault();
            if (buscado == null)
            {
                throw new UsuarioInvalidoException("El usuario o contraseña no son válidos");
            }
            return buscado;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }


        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
