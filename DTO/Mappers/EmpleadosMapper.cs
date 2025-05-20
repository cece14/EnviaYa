    using LogicaNegocio.EntidadesDominio;
    using DTO.Mappers;
    using LogicaNegocio.ValueObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    namespace DTO.Mappers
    {
        public static class EmpleadosMapper
        {
        public static Empleado ToEmpleado(EmpleadoDTO dto)
        {
            return new Empleado(
                dto.Nombre,
                dto.Apellido,
                new Email(dto.Email),
                dto.Password,
                RolesMapper.MapearDesdeDTO(dto.Rol),
                dto.Telefono
            );
        }
        public static EmpleadoDTO MapearEmpleadoParaEdicion(EditarEmpleadoDTO dtoParcial, Empleado original)
        {
            return new EmpleadoDTO
            {
                Id = original.Id,
                Nombre = dtoParcial.Nombre,
                Apellido = dtoParcial.Apellido,
                Email = dtoParcial.Email,
                Telefono = dtoParcial.Telefono,
                Rol = dtoParcial.Rol, 
                Password = original.Password
            };
        }

        public static EditarEmpleadoDTO ToEditarEmpleadoDTO(Empleado emp)
            {
                return new EditarEmpleadoDTO
                {
                    Id = emp.Id,
                    Nombre = emp.Nombre,
                    Apellido = emp.Apellido,
                    Email = emp.Email.Valor,  
                    Telefono = emp.Telefono,
                    Rol = RolesMapper.MapearADTO(emp.Rol)
                };
            }
        public static void MapearDatosEnEmpleadoExistente(Empleado destino, EmpleadoDTO dto)
        {
            destino.Nombre = dto.Nombre;
            destino.Apellido = dto.Apellido;
            destino.Email = new Email(dto.Email);
            destino.Telefono = dto.Telefono;
            destino.Rol = RolesMapper.MapearDesdeDTO(dto.Rol); // Si no estás usando Enum.Parse acá
        }
    
    public static List<EmpleadoDTO> ToDTOs(IEnumerable<Empleado> empleados)
        {
            List<EmpleadoDTO> lista = new List<EmpleadoDTO>();

            foreach (Empleado e in empleados)
            {
                lista.Add(ToEmpleadoDTO(e));
            }

            return lista;
        }

        public static Empleado ToEmpleado(AltaEmpleadoDTO dto)
        {
            return new Empleado(
                dto.Nombre,
                dto.Apellido,
                new Email(dto.Email),
                dto.Password,
                RolesMapper.MapearDesdeDTO(dto.Rol),
                dto.Telefono
            );
        }

        public static EmpleadoDTO ToEmpleadoDTO(Empleado emp)
        {
            return new EmpleadoDTO
            {
                Id = emp.Id,
                Nombre = emp.Nombre,
                Apellido = emp.Apellido,
                Email = emp.Email.Valor,
                Telefono = emp.Telefono,
                FechaAlta = emp.Usuario?.FechaAlta ?? DateTime.MinValue,
                Password = emp.Password,
                Rol = RolesMapper.MapearADTO(emp.Rol)
            };
        }
    }
    }

