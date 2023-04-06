using Microsoft.AspNetCore.Mvc;

namespace Controle_de_contatos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
