using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class RegistrarAuditoria : IRegistrarAuditoria
    {
        private readonly IRepositorioAuditorias RepoAuditorias;

        public RegistrarAuditoria(IRepositorioAuditorias repo)
        {
            RepoAuditorias = repo;
        }

        public void Ejecutar(Auditoria auditoria)
        {
            RepoAuditorias.Add(auditoria);
            RepoAuditorias.SaveChanges();
        }

    }
}
