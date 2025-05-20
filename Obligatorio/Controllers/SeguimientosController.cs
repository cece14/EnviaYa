using DTO;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;

namespace Obligatorio.Controllers
{
    public class SeguimientosController : Controller
    {
        private readonly IAgregarSeguimiento agregarSeguimiento;
        private readonly IObtenerEnvios obtenerEnvios;
        private readonly IObtenerSeguimientos obtenerSeguimientos;

        public SeguimientosController(
            IAgregarSeguimiento AgregarSeguimiento,
            IObtenerEnvios ObtenerEnvios,
            IObtenerSeguimientos ObtenerSeguimientos)
        {
            agregarSeguimiento = AgregarSeguimiento;
            obtenerEnvios = ObtenerEnvios;
            obtenerSeguimientos = ObtenerSeguimientos;
        }

        [HttpGet]
        public IActionResult Crear(int envioId)
        {
            var envioDTO = obtenerEnvios.ObtenerPorId(envioId);
            if (envioDTO == null)
            {
                TempData["Error"] = "Envío no encontrado.";
                return RedirectToAction("Index", "Envios");
            }

            var viewModel = new AltaSeguimientoViewModel
            {
                DTO = new AltaSeguimientoDTO
                {
                    EnvioId = envioDTO.Id
                },
                NombreCliente = envioDTO.ClienteEmail,
                DireccionPostal = envioDTO.DireccionPostal,
                SeguimientosAnteriores = obtenerSeguimientos.ObtenerSeguimientosPorEnvio(envioDTO.Id)
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Crear(AltaSeguimientoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var envioDTO = obtenerEnvios.ObtenerPorId(vm.DTO.EnvioId);
                if (envioDTO != null)
                {
                    vm.NombreCliente = envioDTO.ClienteEmail;
                    vm.DireccionPostal = envioDTO.DireccionPostal;
                    vm.SeguimientosAnteriores = obtenerSeguimientos.ObtenerSeguimientosPorEnvio(envioDTO.Id);
                }

                TempData["Error"] = "El formulario tiene errores.";
                return View(vm);
            }

            try
            {
                // 👇 Usamos el valor que guardaste en sesión al loguearte
                vm.DTO.EmailEmpleado = HttpContext.Session.GetString("correo");

                agregarSeguimiento.Agregar(vm.DTO);

                TempData["Success"] = "Comentario agregado correctamente.";
                return RedirectToAction("Index", "Envios");
            }
            catch (Exception ex)
            {
                var envioDTO = obtenerEnvios.ObtenerPorId(vm.DTO.EnvioId);
                if (envioDTO != null)
                {
                    vm.NombreCliente = envioDTO.ClienteEmail;
                    vm.DireccionPostal = envioDTO.DireccionPostal;
                    vm.SeguimientosAnteriores = obtenerSeguimientos.ObtenerSeguimientosPorEnvio(envioDTO.Id);
                }

                TempData["Error"] = ex.Message;
                return View(vm);
            }
        }
    }
}