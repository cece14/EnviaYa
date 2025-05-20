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
    public class RepositorioEnvios : IRepositorioEnvios
    {
        public LogisticaContext Contexto { get; set; }

        public RepositorioEnvios(LogisticaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Envio envio)
        {
            Contexto.Envios.Add(envio);
            Contexto.SaveChanges();
        }

        
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Envio FindById(int id)
        {
            return Contexto.Envios
                .Include(e => e.Cliente)
                .Include(e => e.AgenciaDeRetiro)
                .FirstOrDefault(e => e.Id == id);
        }
        public void Update(Envio e)
        {
            Contexto.Envios.Update(e);
            Contexto.SaveChanges();
        }

        public List<Envio> ObtenerTodosConSeguimientos()
        {
            return Contexto.Envios
                .Include(e => e.Seguimientos.OrderByDescending(s => s.Fecha))
                .Include(e => e.Cliente) 
                .ToList();
        }

        public IEnumerable<Envio> FindAll()
        {
            return Contexto.Envios
                .Include(e => e.Cliente)
                .Include(e => e.AgenciaDeRetiro)
                .ToList(); // SIN FILTRO
        }

        public IEnumerable<Envio> FindEnProceso()
        {
            return Contexto.Envios
                .Include(e => e.Cliente)
                .Include(e => e.AgenciaDeRetiro)
                .Include(e => e.Seguimientos.OrderByDescending(s => s.Fecha)) 
                .Where(e => e.EstadoActual == Estado.EN_PROCESO)
                .ToList();
        }
        public Envio BuscarPorNroTracking(string nroTracking)
        {
            return Contexto.Envios
                .Include(e => e.Cliente)
                .Include(e => e.AgenciaDeRetiro)
                .FirstOrDefault(e => e.NroTracking == nroTracking);
        }
    }

}
