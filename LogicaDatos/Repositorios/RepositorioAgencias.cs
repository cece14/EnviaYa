using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaDatos.Repositorios
{
    public class RepositorioAgencias : IRepositorioAgencias
    {
        public LogisticaContext Contexto { get; set; }

        public RepositorioAgencias(LogisticaContext ctx)
        {
            Contexto = ctx;
        }
        public Agencia FindById(int id)
        {
            return Contexto.Agencias.Find(id);
        }
        public List<Agencia> FindAll()
        {
            return Contexto.Agencias.ToList();
        }
    }
}
