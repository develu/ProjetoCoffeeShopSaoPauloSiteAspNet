using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCoffeeShoopSaoPaulo.Bilioteca.Filters;
using ProjetoCoffeeShoopSaoPaulo.Models.Categoria;
using ProjetoCoffeeShoopSaoPaulo.Utils;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;
using ProjetoCoffeeShopSaoPauloDTO.Categoria;
using ProjetoCoffeeShopSaoPauloSite.Models.Categoria.request;
using ProjetoCoffeeShopSaoPauloSite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoCoffeeShopSaoPauloSite.Controllers
{
    [Login]
    public class CategoriaController : Controller
    {

        private ICategoriaService _categoriaService;

        string[] imageTypes = new string[]{
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
            };

        public CategoriaController(ICategoriaService categoriaService)
        {
            this._categoriaService = categoriaService;
        }

        public IActionResult Index()
        {

            try
            {
                var lstCategoriasDto = _categoriaService.GetCategorias();
                var lstCategoriasModel = new List<CategoriaModel>();

                foreach (var dto in lstCategoriasDto)
                {
                    lstCategoriasModel.Add(new CategoriaModel()
                    {
                        IdCategoria = dto.IdCategoria,
                        Nome = dto.Nome,
                        Descricao = dto.Descricao,
                        Foto = $"{ConfigConstants.GetPathCategoria()}{dto.Foto}",
                        DataCadastro = dto.DataCadastro
                    });

                }
                return View(lstCategoriasModel);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = CrudMsgConstants.ErrorLoadList("Categorias!");
                return View();
            }

        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar([FromForm] CategoriaModelRequest request)
        {   
            string fileName = $"{request.Nome}_{DateTime.Now.ToString().Replace("/", "_").Replace(":", "_")}.png";
            _validarFoto(request.Foto);

            if (ModelState.IsValid)
            {
                try
                {

                    HelperFile.SaveFotoCategoria(request.Foto, fileName);

                    var dtoCategoria = new CadastrarCategoriaDTO();

                    dtoCategoria.Nome = request.Nome;
                    dtoCategoria.Descricao = request.Descricao;
                    dtoCategoria.Foto = fileName;

                    _categoriaService.PostCategoria(dtoCategoria);

                    TempData["Mensagem"] = CrudMsgConstants.MsgInsertSuccess("Categoria");
                }
                catch (System.Exception ex)
                {
                    TempData["Mensagem"] = CrudMsgConstants.MsgInsertError("Categoria");
                }

                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }

        }



        [HttpGet]
        [Route("Editar/{IdCategoria}")]
        public IActionResult Editar(int IdCategoria)
        {

            var dto = _categoriaService.GetCategoriaById(IdCategoria);

            var modelRequest = new CategoriaModelRequest()
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Foto = null
            };

            TempData["id_categoria"] = dto.IdCategoria;

            string foto = null;

            if (dto.Foto == "")
            {
                foto = ConfigConstants.GetImgError();
                modelRequest.hasFoto = false;
            }
            else
            {
                foto = $"{ConfigConstants.GetPathCategoria()}{dto.Foto}";
                modelRequest.hasFoto = true;

            }

            TempData["old_foto"] = foto;

            return View(modelRequest);
        }

        [HttpPost]
        [Route("Editar/{IdCategoria}")]
        public IActionResult Editar([FromForm] CategoriaModelRequest request, int IdCategoria)
        {
            string fileName = null;

            if (request.updateFoto) _validarFoto(request.Foto);

            if (ModelState.IsValid)
            {
                try
                {

                    if (request.updateFoto)
                    {
                        fileName = $"{request.Nome}_{DateTime.Now.ToString().Replace("/", "_").Replace(":", "_")}.png";

                        if (request.hasFoto != null && request.hasFoto == true)
                        {
                            HelperFile.DeleteFotoCategoria(request.old_foto);
                        }

                    }

                    if (request.updateFoto) HelperFile.SaveFotoCategoria(request.Foto, fileName);

                    var dtoCategoria = new AtualizarCategoriaDTO();

                    dtoCategoria.IdCategoria = IdCategoria;
                    dtoCategoria.Nome = request.Nome;
                    dtoCategoria.Foto = fileName;
                    dtoCategoria.Descricao = request.Descricao;

                    _categoriaService.UpdateCategoria(dtoCategoria);

                    TempData["Mensagem"] = CrudMsgConstants.MsgUpdateSuccess("Categoria");
                }
                catch (System.Exception ex)
                {
                    TempData["Mensagem"] = CrudMsgConstants.MsgUpdateError("Categoria");
                }

                return RedirectToAction("Index");
            }

            else
            {
                var dto = _categoriaService.GetCategoriaById(IdCategoria);

                string foto = null;

                if (dto.Foto == "")
                {
                    foto = ConfigConstants.GetImgError();
                    request.hasFoto = false;
                }
                else
                {
                    foto = $"{ConfigConstants.GetPathCategoria()}{dto.Foto}";
                    request.hasFoto = true;

                }

                TempData["old_foto"] = foto;

                TempData["id_categoria"] = IdCategoria;

                return View(request);
            }
        }

        [HttpGet]
        [Route("Delete/{IdCategoria}")]
        public IActionResult Delete(int IdCategoria)
        {

            try
            {
                var item = _categoriaService.GetCategoriaById(IdCategoria);
                
                _categoriaService.DeleteCategoria(IdCategoria);
                TempData["Mensagem"] = CrudMsgConstants.MsgDeleteSuccess("Categoria");

                if (!string.IsNullOrEmpty(item.Foto))
                {

                    string fileName = $"{ConfigConstants.GetPathCategoria()}{item.Foto}";

                    HelperFile.DeleteFotoItem(fileName);
                }

            }
            catch (System.Exception ex)
            {
                TempData["Mensagem"] = CrudMsgConstants.MsgDeleteError("Categoria");
            }

            return RedirectToAction("Index");

        }


        private void _validarFoto(IFormFile foto)
        {
            if (foto == null || foto.Length == 0)
            {
                ModelState.AddModelError("Foto", "Este campo é obrigatório");
            }
            else if (!imageTypes.Contains(foto.ContentType))
            {
                ModelState.AddModelError("Foto", "Escolha uma imagem JPG ou PNG.");
            }
        }

    }
}
