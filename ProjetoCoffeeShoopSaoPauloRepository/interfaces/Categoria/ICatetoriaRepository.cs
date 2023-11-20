using ProjetoCoffeeShoopSaoPauloDTO.Categoria;
using ProjetoCoffeeShopSaoPauloDTO.Categoria;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPauloRepository.interfaces.Categoria
{
    public interface ICatetoriaRepository
    {
        List<CategoriaDTO> GetCategorias();

        void PostCategoria(CadastrarCategoriaDTO dto);

        void UpdateCategoria(AtualizarCategoriaDTO dto);

        void DeleteCategoria(int IdCategoria);

        CategoriaDTO GetCategoriaById(int id);
    }
}
