using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioAuditorias : IRepositorioAuditorias
    {
        public LogisticaContext Auditoria;

        public RepositorioAuditorias(LogisticaContext context)
        {
            Auditoria = context;
        }

        public void Add(Auditoria auditoria)
        {
            Auditoria.Auditorias.Add(auditoria);
        }

        public void SaveChanges()
        {
            Auditoria.SaveChanges();
        }

        public IEnumerable<Auditoria> FindAll()
        {
            return Auditoria.Auditorias.ToList();
        }

        public Auditoria FindById(int id)
        {
            return Auditoria.Auditorias.Find(id);
        }
    }
}
    

