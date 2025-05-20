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
    public class RepositorioSeguimientos : IRepositorioSeguimientos
    {
        public LogisticaContext Contexto { get; set; }

        public RepositorioSeguimientos(LogisticaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Seguimiento seguimiento)
        {
            Contexto.Seguimientos.Add(seguimiento);
            Contexto.SaveChanges();
        }

        public List<Seguimiento> ObtenerPorEnvioId(int envioId)
        {
            return Contexto.Seguimientos
                .Include(s => s.Empleado)
                .Where(s => s.Envio.Id == envioId)
                .OrderByDescending(s => s.Fecha)
                .ToList();
        }

   

    }
}
