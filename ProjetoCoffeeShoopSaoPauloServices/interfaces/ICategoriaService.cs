using ProjetoCoffeeShoopSaoPauloDTO.Categoria;
using ProjetoCoffeeShopSaoPauloDTO.Categoria;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPauloServices.interfaces
{
    public interface ICategoriaService
    {
        List<CategoriaDTO> GetCategorias();

        void PostCategoria(CadastrarCategoriaDTO dto);

        void UpdateCategoria(AtualizarCategoriaDTO dto);

        void DeleteCategoria(int IdCategoria);

        CategoriaDTO GetCategoriaById(int id);

    }
}
