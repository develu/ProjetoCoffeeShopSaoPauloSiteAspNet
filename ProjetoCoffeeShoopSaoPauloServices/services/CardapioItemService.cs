using ProjetoCoffeeShoopSaoPauloRepository.interfaces.CardapioItem;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;
using ProjetoCoffeeShopSaoPauloDTO.CardapioItem;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPauloServices.services
{
    public class CardapioItemService : ICardapioItemService
    {
        private ICardapioItemRepository _repository;

        public CardapioItemService(ICardapioItemRepository repository)
        {
            _repository = repository;
        }
      
        public List<CardapioItemDTO> GetListaCardapioItem(int IdCardapioItem = 0)
        {            
            return _repository.ListarCardapioItem();
        }

        public void PostCardapioItem(CadastrarCardapioItemDTO cardapioItemDto)
        {
            _repository.PostCardapioItem(cardapioItemDto);
        }

        public void UpdateCardapioItem(UpdateItemCardapioDTO cardapioItemDto, int id)
        {
            _repository.UpdateCardapioItem(cardapioItemDto, id);
        }

        public void DeleteCardapioItem(int id)
        {
            _repository.DeleteCardapioItem(id);
        }

        public UpdateItemCardapioDTO GetItemCardapioById(int id)
        {
            return _repository.GetItemCardapioById(id);
        }

        public List<CardapioItemDTO> ListarCardapioItemByIdCategoria(int idCategoria)
        {
            return _repository.ListarCardapioItemByIdCategoria(idCategoria);
        }
    }
}
