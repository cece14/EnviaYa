﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IFinalizarEnvio
    {
        void Finalizar(int id, DateTime fechaEntrega);
    }
}
