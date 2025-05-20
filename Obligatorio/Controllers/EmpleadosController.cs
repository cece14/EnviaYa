using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;
public class EmpleadosController : Controller
{
    public IAltaEmpleado CuAltaEmpleado { get; set; }
    public IObtenerEmpleados CuListaEmpleado { get; set; }
    public IEliminarEmpleado CuEliminarEmpleado { get; set; }
    public IEditarEmpleado CuEditarEmpleado { get; set; }

    public IRegistrarAuditoria CuRegistrarAuditoria { get; set; }

    public EmpleadosController(IAltaEmpleado cuAltaEmpleado, IObtenerEmpleados cuListaEmpleado, IEliminarEmpleado cuEliminarEmpleado, IEditarEmpleado cuEditarEmpleado, IRegistrarAuditoria cuRegistrarAuditoria)
    {
        CuAltaEmpleado = cuAltaEmpleado;
        CuListaEmpleado = cuListaEmpleado;
        CuEliminarEmpleado = cuEliminarEmpleado;
        CuEditarEmpleado = cuEditarEmpleado;
        CuRegistrarAuditoria = cuRegistrarAuditoria;
    }

    // GET: EmpleadosController
    public ActionResult Index()
    {
        if (HttpContext.Session.GetString("rol") != "0")
            return RedirectToAction("Login", "Usuarios");

        var lista = CuListaEmpleado.ObtenerTodos();

        var vm = new AltaEmpleadoViewModel
        {
            Empleados = lista
        };

        return View(vm);
    }

    // GET: EmpleadosController/Details/5
    public ActionResult Details(int id)
    {
        if (HttpContext.Session.GetString("rol") != "0")
            return RedirectToAction("Login", "Usuarios");

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        if (HttpContext.Session.GetString("rol") != "0")
            return RedirectToAction("Login", "Usuarios");

        var emp = CuEliminarEmpleado.Buscar(id);
        if (emp == null)
        {
            TempData["Error"] = "El empleado no existe o ya fue eliminado.";
            return RedirectToAction("Index");
        }

        var usuarioEmail = HttpContext.Session.GetString("correo");

        CuEliminarEmpleado.Eliminar(id, usuarioEmail);


        var auditoria = new Auditoria
        {
            FechaHora = DateTime.Now,
            Accion = $"Eliminación de empleado: {emp.Nombre} {emp.Apellido}",
            UsuarioEmail = usuarioEmail,
            EmpleadoId = emp.Id
        };

        CuRegistrarAuditoria.Ejecutar(auditoria);

        TempData["Success"] = $"Empleado '{emp.Nombre} {emp.Apellido}' eliminado correctamente.";
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Create()
    {
        if (HttpContext.Session.GetString("rol") != "0")
            return RedirectToAction("Login", "Usuarios");

        var vm = new AltaEmpleadoViewModel();
        return View(vm);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(AltaEmpleadoViewModel vm)
    {
        if (HttpContext.Session.GetString("rol") != "0")
            return RedirectToAction("Login", "Usuarios");

        if (!ModelState.IsValid)
            return View(vm);

        try
        {
            var usuarioEmail = HttpContext.Session.GetString("correo");
            CuAltaEmpleado.EjecutarAlta(vm.DTO, usuarioEmail);
            var auditoria = new Auditoria
            {
                FechaHora = DateTime.Now,
                Accion = $"Alta de empleado: {vm.DTO.Nombre} {vm.DTO.Apellido}",
                UsuarioEmail = usuarioEmail,
                EmpleadoId = 0
            };
            CuRegistrarAuditoria.Ejecutar(auditoria);

            return RedirectToAction("Index");
        }
        catch (EmailInvalidoException ex)
        {
            ViewBag.MensajeError = ex.Message;
            return View(vm);
        }
        catch (RolInvalidoException ex)
        {
            ViewBag.MensajeError = ex.Message;
            return View(vm);
        }
        catch (DatosInvalidosException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(vm);
        }
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        if (HttpContext.Session.GetString("rol") != "0")
            return RedirectToAction("Login", "Usuarios");

        var emp = CuListaEmpleado.FindById(id);
        if (emp == null)
        {
            TempData["Error"] = "El empleado no existe.";
            return RedirectToAction("Index");
        }

        var empleadoDTO = EmpleadosMapper.ToEditarEmpleadoDTO(emp);
        var viewModel = new EditarEmpleadoViewModel
        {
            DTO = empleadoDTO
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EditarEmpleadoViewModel viewModel)
    {
        if (HttpContext.Session.GetString("rol") != "0")
            return RedirectToAction("Login", "Usuarios");

        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        try
        {
            var dtoParcial = viewModel.DTO;

            var original = CuListaEmpleado.FindById(dtoParcial.Id);
            if (original == null)
            {
                TempData["Error"] = "Empleado no encontrado.";
                return RedirectToAction("Index");
            }

            var dtoCompleto = EmpleadosMapper.MapearEmpleadoParaEdicion(dtoParcial, original);
            var usuarioEditor = HttpContext.Session.GetString("correo");
            CuEditarEmpleado.Editar(dtoCompleto, usuarioEditor);


            var auditoria = new Auditoria
            {
                FechaHora = DateTime.Now,
                Accion = $"Modificación de empleado: {dtoCompleto.Nombre} {dtoCompleto.Apellido}",
                UsuarioEmail = usuarioEditor,
                EmpleadoId = dtoCompleto.Id
            };
            CuRegistrarAuditoria.Ejecutar(auditoria);

            TempData["Success"] = "Empleado actualizado correctamente";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al actualizar el empleado: {ex.Message}";
            return View(viewModel);
        }
    }


}

