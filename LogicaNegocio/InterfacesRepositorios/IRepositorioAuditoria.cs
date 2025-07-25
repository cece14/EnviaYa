﻿using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAuditorias
    {

        void Add(Auditoria auditoria);
        void SaveChanges();
        IEnumerable<Auditoria> FindAll();
        Auditoria FindById(int id);
    }
}
