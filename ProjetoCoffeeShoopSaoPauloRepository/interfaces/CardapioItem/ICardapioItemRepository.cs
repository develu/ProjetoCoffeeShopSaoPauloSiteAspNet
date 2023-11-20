using ProjetoCoffeeShopSaoPauloDTO.CardapioItem;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPauloRepository.interfaces.CardapioItem
{
    public interface ICardapioItemRepository
    {
        List<CardapioItemDTO> ListarCardapioItem(int IdCardapioItem = 0);
        void PostCardapioItem(CadastrarCardapioItemDTO cardapioItemDTO);
        void UpdateCardapioItem(UpdateItemCardapioDTO cardapioItemDto, int id);
        void DeleteCardapioItem(int id);
        UpdateItemCardapioDTO GetItemCardapioById(int id);
        List<CardapioItemDTO> ListarCardapioItemByIdCategoria(int idCategoria);
    }
}
