using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class RolesMapper
    {
        public static Rol MapearDesdeDTO(RolDTO dto)
        {
            return dto switch
            {
                RolDTO.Administrador => Rol.Administrador,
                RolDTO.Funcionario => Rol.Funcionario,
                RolDTO.Cliente => Rol.Cliente,
                _ => throw new ArgumentOutOfRangeException(nameof(dto), "RolDTO inválido")
            };
        }

        public static RolDTO MapearADTO(Rol rol)
        {
            return rol switch
            {
                Rol.Administrador => RolDTO.Administrador,
                Rol.Funcionario => RolDTO.Funcionario,
                Rol.Cliente => RolDTO.Cliente,
                _ => throw new ArgumentOutOfRangeException(nameof(rol), "Rol inválido")
            };
        }
    }
}

