using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LogicaDatos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes

    {

        public LogisticaContext Contexto { get; set; }

        public RepositorioClientes(LogisticaContext ctx)
        {
            Contexto = ctx;
        }

        public Cliente BuscarPorEmail(string email)
        {
            return Contexto.Clientes
              
               .FirstOrDefault(c => c.Email.Valor == email);
        }

        public void Add(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> FindAll()
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            var cliente = Contexto.Clientes.Find(id);
            if (cliente != null)
            {
                Contexto.Clientes.Remove(cliente);
                Contexto.SaveChanges();
            }
        }
    }
}
