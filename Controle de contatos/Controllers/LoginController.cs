using Controle_de_contatos.Helper;
using Controle_de_contatos.Models;
using Controle_de_contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_contatos.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Entrar (LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida";
                    }
                    TempData["MensagemErro"] = $"Login ou senha inválidos";

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao fazer o login {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
