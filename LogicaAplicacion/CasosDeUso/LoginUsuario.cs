using DTO.Mappers;
using DTO;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;

namespace LogicaAplicacion.CasosDeUso
{
    public class LoginUsuario : ILoginUsuario
    {
        public IRepositorioUsuarios Repo { get; set; }

        public LoginUsuario(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public ListadoUsuariosDTO Login(string email, string password)
        {
            Usuario usu = Repo.Login(email, password);
            return UsuariosMapper.ToDTO(usu);
        }
    }
}

