using Microsoft.AspNetCore.Mvc;
using ProjetoCoffeeShoopSaoPaulo.Bilioteca.Filters;
using ProjetoCoffeeShoopSaoPaulo.Models.Usuario;
using ProjetoCoffeeShoopSaoPaulo.Utils;
using ProjetoCoffeeShoopSaoPauloDTO.Usuario;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPaulo.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            this._service = service;
        }

        [Login]
        public IActionResult Index()
        {
            var lista = _service.ListarUsuario(null);
            var listaModel = new List<Usuario>();

            foreach (var dto in lista) listaModel.Add((Usuario)dto);

            return View(listaModel);
        }

        [Login]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Usuario request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = new UsuarioDTO();

                    dto.Nome = request.Nome;
                    dto.Email = request.Email;
                    dto.Senha = CriptografarSenha.codificarSenha(request.Senha);

                    _service.CadastrarUsuario(dto);
                    TempData["Mensagem"] = "Usuário Cadastrado com sucesso!";

                }
                catch (System.Exception ex)
                {
                    TempData["Mensagem"] = "Não foi possível cadastrar usuário!";
                }

                return RedirectToAction("Index");
            }
            else { return View(); }
        }

        [Login]
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var usuarioDto = _service.ListarUsuario(id);
            return View((Usuario)usuarioDto[0]);
        }

        [Login]
        [HttpPost]
        public IActionResult Editar([FromForm] Usuario request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = new UsuarioDTO();

                    dto.Id = request.Id;
                    dto.Nome = request.Nome;
                    dto.Email = request.Email;
                    dto.Senha = CriptografarSenha.codificarSenha(request.Senha);

                    _service.AtualizarUsuario(dto);
                    TempData["Mensagem"] = "Usuário Atualizado com sucesso!";

                }
                catch (System.Exception ex)
                {
                    TempData["Mensagem"] = "Não foi possível atualizar usuário!";
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(request);
            }
        }

        // TODO: Alterar para HttpDelete
        [Login]
        [HttpGet]
        public IActionResult Deletar(int id)
        {
            try
            {

                _service.DeletarUsuario(id);
                TempData["Mensagem"] = "Usuário deletado com sucesso!";

            }
            catch (System.Exception ex)
            {
                TempData["Mensagem"] = "Não foi possível deletar usuário!";
            }

            return RedirectToAction("Index", "Usuario");
        }
    }
}
