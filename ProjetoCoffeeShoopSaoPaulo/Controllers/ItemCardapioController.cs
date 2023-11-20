using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using ProjetoCoffeeShoopSaoPaulo.Bilioteca.Filters;
using ProjetoCoffeeShoopSaoPaulo.Models.Categoria;
using ProjetoCoffeeShoopSaoPaulo.Models.ItemCardapio;
using ProjetoCoffeeShoopSaoPaulo.Models.ItemCardapio.request;
using ProjetoCoffeeShoopSaoPaulo.Utils;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;
using ProjetoCoffeeShopSaoPauloDTO.CardapioItem;
using ProjetoCoffeeShopSaoPauloSite.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjetoCoffeeShoopSaoPaulo.Controllers
{

    [Login]
    public class ItemCardapioController : Controller
    {

        private ICardapioItemService _service;
        private ICategoriaService _serviceCatetoria;

        string[] imageTypes = new string[]{
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
            };

        public ItemCardapioController(ICardapioItemService service, ICategoriaService serviceCatetoria)
        {
            this._service = service;
            this._serviceCatetoria = serviceCatetoria;
        }

        public IActionResult Index()
        {
            try
            {
                var lstDto = _service.GetListaCardapioItem();
                var lstModel = new List<ItemCardapioModel>();

                foreach (var item in lstDto)
                {
                    lstModel.Add((ItemCardapioModel)item);
                }

                return View(lstModel);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = CrudMsgConstants.ErrorLoadList("Itens do cardápio!");
                return View();
            }

        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            TempData["lstCategoria"] = _carregarCategorias();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] ItemCardapioRequest itemCardapio)
        {

            string nomeCategoria = _serviceCatetoria.GetCategoriaById(itemCardapio.idCategoria).Nome;
            string fileName = $"{itemCardapio.Nome}_{nomeCategoria}_{DateTime.Now.ToString().Replace("/", "_").Replace(":", "_")}.png";
            _validarFoto(itemCardapio.Foto);

            if (ModelState.IsValid)
            {
                try
                {
                    HelperFile.SaveFotoItem(nomeCategoria, itemCardapio.Foto, fileName);

                    var dto = new CadastrarCardapioItemDTO();
                    dto.Nome = itemCardapio.Nome;
                    dto.Descricao = itemCardapio.Descricao;
                    dto.Foto = fileName;
                    dto.IdCategoria = itemCardapio.idCategoria;

                    _service.PostCardapioItem(dto);

                    TempData["Mensagem"] = "Item do Cardápio Cadastrado com sucesso!";

                }
                catch (System.Exception ex)
                {
                    TempData["Mensagem"] = "Não foi possível Cadastrar Item do Cardápio!";
                }
            }
            else
            {
                TempData["lstCategoria"] = _carregarCategorias();
                return View();
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var dto = _service.GetItemCardapioById(id);

            var requestModel = new ItemCardapioRequest()
            {
                Id = id,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                idCategoria = dto.IdCategoria,
                Foto = null

            };

            string foto = null;

            if (dto.Foto == "") {
                foto = ConfigConstants.GetImgError();
                requestModel.hasFoto = false;
            }
            else
            {
                foto = $"{ConfigConstants.GetPathItemCardapioCategoria()}{dto.NomeCategoria}/{dto.Foto}";
                requestModel.hasFoto = true;

            }

            TempData["old_foto"] = foto;

            TempData["lstCategoria"] = _carregarCategorias();

            return View(requestModel);
        }

        [HttpPost]
        public IActionResult Editar([FromForm] ItemCardapioRequest itemCardapio)
        {
            var categoria = _serviceCatetoria.GetCategoriaById(itemCardapio.idCategoria);           

            string fileName = null;

            if (itemCardapio.updateFoto) _validarFoto(itemCardapio.Foto);         
            
            if (ModelState.IsValid)
            {
                try
                {

                    if (itemCardapio.updateFoto)
                    {
                        
                        fileName = $"{itemCardapio.Nome}_{categoria.Nome}_{DateTime.Now.ToString().Replace("/", "_").Replace(":", "_")}.png";

                        if (itemCardapio.hasFoto != null && itemCardapio.hasFoto == true)
                        {
                            HelperFile.DeleteFotoItem(itemCardapio.old_foto);
                        }

                    }

                    if (itemCardapio.updateFoto) HelperFile.SaveFotoItem(categoria.Nome, itemCardapio.Foto, fileName);

                    if (categoria.IdCategoria != itemCardapio.IdOldCategoria) {
                        var oldCategoria = _serviceCatetoria.GetCategoriaById(itemCardapio.IdOldCategoria);
                        string pathFile = HelperFile.GetPathFotoItemCardapio($@"{itemCardapio.old_foto.Substring(itemCardapio.old_foto.LastIndexOf("/") + 1, itemCardapio.old_foto.Length - (itemCardapio.old_foto.LastIndexOf("/") + 1))}", oldCategoria.Nome);
                        byte[] OldImagem = System.IO.File.ReadAllBytes(pathFile);
                        var stream = new MemoryStream(OldImagem);
                        IFormFile file = new FormFile(stream, 0, OldImagem.Length, "temp_name", "tem_fileName");

                        fileName = $"{itemCardapio.Nome}_{categoria.Nome}_{DateTime.Now.ToString().Replace("/", "_").Replace(":", "_")}.png";

                        HelperFile.SaveFotoItem(categoria.Nome, file, fileName);
                        HelperFile.DeleteFotoItem(itemCardapio.old_foto);
                        
                        
                    }

                    var dto = new UpdateItemCardapioDTO();
                    dto.Nome = itemCardapio.Nome;
                    dto.Descricao = itemCardapio.Descricao;
                    dto.Foto = fileName;
                    dto.IdCategoria = itemCardapio.idCategoria;

                    _service.UpdateCardapioItem(dto, itemCardapio.Id);

                    TempData["Mensagem"] = "Item do Cardápio Atualizado com sucesso!";

                }
                catch (System.Exception ex)
                {
                    TempData["Mensagem"] = "Não foi possível Atualizar Item do Cardápio!";
                }
            }
            else
            {
                var dto = _service.GetItemCardapioById(itemCardapio.Id);        

                string foto = null;

                if (dto.Foto == "")
                {
                    foto = ConfigConstants.GetImgError();
                }
                else
                {
                    foto = $"{ConfigConstants.GetPathItemCardapioCategoria()}{dto.NomeCategoria}/{dto.Foto}";
                    itemCardapio.hasFoto = true;

                }
                TempData["old_foto"] = foto;


                TempData["lstCategoria"] = _carregarCategorias();
                return View(itemCardapio);
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _service.GetItemCardapioById(id);                

                _service.DeleteCardapioItem(id);

                if (!string.IsNullOrEmpty(item.Foto))
                {
                    
                    string fileName  = $"{ConfigConstants.GetPathItemCardapioCategoria()}{item.NomeCategoria}/{item.Foto}";
                    HelperFile.DeleteFotoItem(fileName);
                }

                TempData["Mensagem"] = CrudMsgConstants.MsgDeleteSuccess("Item do Cardápio!");
            }
            catch (Exception)
            {
                TempData["Mensagem"] = CrudMsgConstants.MsgDeleteError("Item do Cardápio!");
            }

            return RedirectToAction("index");
        }

        private List<CategoriaModel> _carregarCategorias()
        {

            var lstCategoriasDto = _serviceCatetoria.GetCategorias();

            var lstCategoriaModel = new List<CategoriaModel>();

            foreach (var categoriaDto in lstCategoriasDto)
            {
                var categoriaModel = new CategoriaModel();

                categoriaModel.IdCategoria = categoriaDto.IdCategoria;
                categoriaModel.Nome = categoriaDto.Nome;
                categoriaModel.Descricao = categoriaDto.Descricao;
                categoriaModel.DataCadastro = categoriaDto.DataCadastro;

                lstCategoriaModel.Add(categoriaModel);

            }

            return lstCategoriaModel;

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
