using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Mappers;
using DTO;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaDatos.Repositorios;
using ExcepcionesPropias;

namespace LogicaAplicacion.CasosDeUso
{
    public class AltaEnvio : IAltaEnvio
    {
        private IRepositorioClientes RepoClientes { get; set; }
        private IRepositorioAgencias RepoAgencias { get; set; }
        private IRepositorioEnvios RepoEnvios { get; set; }


        public AltaEnvio(IRepositorioClientes clientes, IRepositorioAgencias agencias, IRepositorioEnvios envios)
        {
            RepoClientes = clientes;
            RepoAgencias = agencias;
            RepoEnvios = envios;
        }
        public void Alta(AltaEnvioDTO dto)
        {
            Cliente cliente = RepoClientes.BuscarPorEmail(dto.EmailCliente)
                ?? throw new DatosInvalidosException("Cliente no encontrado.");

            dto.DireccionPostal = dto.DireccionPostal?.Trim();

            if (dto.AgenciaId == 0)
                dto.AgenciaId = null;

            Agencia agencia = null;

            if (dto.AgenciaId != null)
            {
                agencia = RepoAgencias.FindById(dto.AgenciaId.Value)
                    ?? throw new AgenciaInvalidaException("Agencia no encontrada.");
            }

            string nroTracking = GenerarNumeroTrackingRandom();

            var envio = EnviosMapper.FromDTO(dto, cliente, agencia, nroTracking);

            envio.Validar(); 

            RepoEnvios.Add(envio);
        }
    


        private string GenerarNumeroTrackingRandom()
        {
            var random = new Random();
            string numeroTracking = "TRK" + random.Next(10000000, 99999999).ToString();
            return numeroTracking;
        }

    }
}
