using ProjetoCoffeeShoopSaoPauloDTO.Categoria;
using ProjetoCoffeeShoopSaoPauloRepository.interfaces.Categoria;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;
using ProjetoCoffeeShopSaoPauloDTO.Categoria;
using System;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPauloServices.services
{
    public class CategoriaService : ICategoriaService
    {
        private ICatetoriaRepository _categoriaRepository;

        public CategoriaService(ICatetoriaRepository categoriaRepository)
        {
            this._categoriaRepository = categoriaRepository;
        }

        public List<CategoriaDTO> GetCategorias()
        {
            return _categoriaRepository.GetCategorias();
        }

        public void PostCategoria(CadastrarCategoriaDTO dto)
        {
            _categoriaRepository.PostCategoria(dto);
        }

        public void UpdateCategoria(AtualizarCategoriaDTO dto)
        {
            _categoriaRepository.UpdateCategoria(dto);
        }

        public void DeleteCategoria(int IdCategoria)
        {
            _categoriaRepository.DeleteCategoria(IdCategoria);
        }

        public CategoriaDTO GetCategoriaById(int id)
        {
            return _categoriaRepository.GetCategoriaById(id);
        }
    }
}

