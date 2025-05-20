using DTO;
using ExcepcionesPropias;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;

public class UsuariosController : Controller
{
    public ILoginUsuario CuLoginUsuario { get; set; }
    public ILogoutUsuario CuLogoutUsuario { get; set; }
    public IObtenerEmpleadoPorUsuario ObtenerEmpleadoPorUsuario { get; set; }

    public UsuariosController(ILoginUsuario cuLoginUsuario, IObtenerEmpleadoPorUsuario obtenerEmpleadoPorUsuario, ILogoutUsuario cuLogoutUsuario)
    {
        CuLoginUsuario = cuLoginUsuario;
        ObtenerEmpleadoPorUsuario = obtenerEmpleadoPorUsuario;
        CuLogoutUsuario = cuLogoutUsuario;
    }
    [HttpGet] 
    public IActionResult Login()
    {
        return View(); 
    }

    [HttpPost]
    public IActionResult Login(LoginDTO usu)
    {
        try
        {
            ListadoUsuariosDTO logueado = CuLoginUsuario.Login(usu.Email, usu.Password);

            if (logueado == null)
            {
                ViewBag.Error = "Usuario no encontrado o credenciales incorrectas.";
                return View(usu);
            }

            if (logueado.Rol == Rol.Cliente)
            {
                ViewBag.Error = "El acceso está restringido para usuarios con rol 'Cliente'.";
                return View(usu);
            }

            if (string.IsNullOrEmpty(logueado.Email) || string.IsNullOrEmpty(logueado.Nombre) || string.IsNullOrEmpty(logueado.Apellido))
            {
                ViewBag.Error = "El usuario no tiene nombre, apellido o email.";
                return View(usu);
            }

         
            string emailEmpleado = ObtenerEmpleadoPorUsuario.ObtenerEmailEmpleadoPorEmailUsuario(logueado.Email);

            if (string.IsNullOrEmpty(emailEmpleado))
            {
                ViewBag.Error = "Este usuario no está asociado a ningún empleado.";
                return View(usu);
            }

            HttpContext.Session.SetString("correo", emailEmpleado);
            HttpContext.Session.SetString("nombreUsuario", logueado.Nombre);
            HttpContext.Session.SetString("apellidoUsuario", logueado.Apellido);
            HttpContext.Session.SetString("rol", ((int)logueado.Rol).ToString()); 

            return RedirectToAction("Index", "Home");
        }
        catch (UsuarioInvalidoException ex)
        {
            ViewBag.Error = ex.Message;
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Ocurrió un error inesperado: {ex.Message}";
        }

        return View(usu);
    }
    public ActionResult Perfil()
    {
        // Obtener los valores de la sesión
        string nombreUsuario = HttpContext.Session.GetString("nombreUsuario");
        string apellidoUsuario = HttpContext.Session.GetString("apellidoUsuario");

        // Comprobar si los valores son nulos o vacíos
        if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(apellidoUsuario))
        {
            ViewBag.Error = "No se pudo cargar la información del usuario. Por favor, inicie sesión nuevamente.";
            return RedirectToAction("Login");
        }

       
        var viewModel = new UsuarioViewModel
        {
            NombreUsuario = nombreUsuario,
            ApellidoUsuario = apellidoUsuario
        };

        
        return View(viewModel);
    }


    [HttpPost]
    public IActionResult Logout()
    {
        CuLogoutUsuario.Ejecutar();
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}

