using ProjetoCoffeeShopSaoPauloDTO.CardapioItem;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPauloServices.interfaces
{
    public interface ICardapioItemService
    {
        List<CardapioItemDTO> GetListaCardapioItem(int IdCardapioItem = 0);
        void PostCardapioItem(CadastrarCardapioItemDTO cardapioItemDto);
        void UpdateCardapioItem(UpdateItemCardapioDTO cardapioItemDto, int id);
        void DeleteCardapioItem(int id);
        UpdateItemCardapioDTO GetItemCardapioById(int id);
        List<CardapioItemDTO> ListarCardapioItemByIdCategoria(int idCategoria);
    }
}
