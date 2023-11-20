using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCoffeeShoopSaoPaulo.Bilioteca.Filters;
using ProjetoCoffeeShoopSaoPaulo.Models.Usuario.request;
using ProjetoCoffeeShoopSaoPaulo.Utils;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;

namespace ProjetoCoffeeShoopSaoPaulo.Controllers
{
    public class AdminController : Controller
    {

        private ILoginService _service;
        public AdminController(ILoginService service)
        {
            this._service = service;
        }

        [Login]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([FromForm] UsuarioRequest usuario)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    string responseLogin = _service.login(usuario.Email, CriptografarSenha.codificarSenha(usuario.Senha));

                    if (responseLogin == null)
                    {
                        ViewBag.Mensagem = "Os dados informados são Invalidos!";
                        return View();
                    }
                    else
                    {
                        HttpContext.Session.SetString("Login", "true");
                        HttpContext.Session.SetString("User", responseLogin);

                        return RedirectToAction("Index", "Admin");
                    }
                }
                catch (System.Exception ex)
                {
                    ViewBag.Mensagem = "Erro para se conectar com o servidor!";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("login", "Admin");
        }

    }
}
