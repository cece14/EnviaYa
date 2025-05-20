using DTO;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;

namespace Obligatorio.Controllers
{
    public class EnviosController : Controller
    {
        public IAltaEnvio CuAltaEnvio { get; set; }
        public IObtenerEnvios CuObtenerEnvios { get; set; }
        public IObtenerAgencias CuObtenerAgencias { get; set; }

        public IFinalizarEnvio CuFinalizarEnvio { get; set; }

        public EnviosController(
            IAltaEnvio cuAltaEnvio,
            IObtenerEnvios cuObtenerEnvios,
            IObtenerAgencias cuObtenerAgencias,
            IFinalizarEnvio cuFinalizarEnvio)
        {
            CuAltaEnvio = cuAltaEnvio;
            CuObtenerEnvios = cuObtenerEnvios;
            CuObtenerAgencias = cuObtenerAgencias;
            CuFinalizarEnvio = cuFinalizarEnvio;
        }

        // GET: Envios
        [HttpGet]
        public IActionResult Index(bool soloEnProceso = false)
        {
            var lista = soloEnProceso
                ? CuObtenerEnvios.ObtenerEnProceso()
                : CuObtenerEnvios.ObtenerTodos();

            var vm = new AltaEnvioViewModel
            {
                Envios = lista,
                SoloEnProceso = soloEnProceso 
            };

            return View(vm);
        }

        // GET: Envios/Create
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new AltaEnvioViewModel
            {
                DTO = new AltaEnvioDTO(),
                Agencias = CuObtenerAgencias.ObtenerTodas()
            };
            return View(vm);
        }

        // POST: Envios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AltaEnvioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Agencias = CuObtenerAgencias.ObtenerTodas();
                return View(vm);
            }

            try
            {
                CuAltaEnvio.Alta(vm.DTO);
                TempData["Success"] = "Envío registrado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                vm.Agencias = CuObtenerAgencias.ObtenerTodas();
                return View(vm);
            }
        }
        [HttpGet]
        public IActionResult Finalizar(int id)
        {
            var envio = CuObtenerEnvios.ObtenerPorId(id); 
            if (envio == null)
            {
                TempData["Error"] = "Envío no encontrado.";
                return RedirectToAction("Index");
            }

            var dto = new FinalizarEnvioDTO
            {
                Id = envio.Id,
                FechaEntrega = DateTime.Today,
                NombreCliente = envio.EmailCliente,
                Direccion = envio.DireccionPostal
            };

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Finalizar(FinalizarEnvioDTO dto)
        {
            if (dto.FechaEntrega == default)
            {
                TempData["Error"] = "Debes ingresar una fecha válida.";

                var envio = CuObtenerEnvios.ObtenerPorId(dto.Id);
                dto.NombreCliente = envio?.EmailCliente;
                dto.Direccion = envio?.DireccionPostal;

                return View(dto);
            }

            try
            {
                CuFinalizarEnvio.Finalizar(dto.Id, dto.FechaEntrega.Value);
                TempData["Success"] = "Envío finalizado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

                var envio = CuObtenerEnvios.ObtenerPorId(dto.Id);
                dto.NombreCliente = envio?.EmailCliente;
                dto.Direccion = envio?.DireccionPostal;

                return View(dto);
            }
        }

        [HttpGet]
        public IActionResult Historial() 
        {
            var lista = CuObtenerEnvios.ObtenerTodos();
            var vm = new AltaEnvioViewModel { Envios = lista };
            return View("Historial", vm);
        }


    }
    }

