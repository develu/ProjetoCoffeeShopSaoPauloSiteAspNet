using Microsoft.AspNetCore.Mvc;
using ProjetoCoffeeShoopSaoPaulo.Models.Categoria;
using ProjetoCoffeeShoopSaoPaulo.Models.ItemCardapio;
using ProjetoCoffeeShoopSaoPaulo.Utils;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPaulo.Controllers
{
    public class CardapioController : Controller
    {
        private ICategoriaService _categoriaService;
        private ICardapioItemService _cardapioItemService;

        public CardapioController(ICategoriaService service, ICardapioItemService cardapioItemService)
        {
            this._categoriaService = service;
            this._cardapioItemService = cardapioItemService;
        }
        public IActionResult Index()
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

        public IActionResult ItensCadardapio(int idCategoria)
        {
            try
            {
                var lstDto = _cardapioItemService.ListarCardapioItemByIdCategoria(idCategoria);
                
                var lstModel = new List<ItemCardapioModel>();

                foreach (var item in lstDto)
                {
                    lstModel.Add((ItemCardapioModel)item);
                }

                TempData["nome_categoria"] = _categoriaService.GetCategoriaById(idCategoria).Nome;

                return View(lstModel);

            }
            catch (System.Exception ex)
            {

                throw;
            }

            return View();

        }
        public IActionResult Doces()
        {
            return View();
        }
        public IActionResult Salgados()
        {
            return View();
        }
        public IActionResult BebidasQuentes()
        {
            return View();
        }
        public IActionResult BebidasGeladas()
        {
            return View();
        }
    }

}
