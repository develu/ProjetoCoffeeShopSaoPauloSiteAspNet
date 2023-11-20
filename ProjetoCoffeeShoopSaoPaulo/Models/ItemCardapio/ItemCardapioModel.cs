using ProjetoCoffeeShoopSaoPaulo.Utils;
using ProjetoCoffeeShopSaoPauloDTO.CardapioItem;
using System;

namespace ProjetoCoffeeShoopSaoPaulo.Models.ItemCardapio
{
    public class ItemCardapioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeCategoria { get; set; }

        public static explicit operator ItemCardapioModel(CardapioItemDTO dto)
        {            
            return new ItemCardapioModel()
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Foto = dto.Foto == "" ? ConfigConstants.GetImgError() : $"{ConfigConstants.GetPathItemCardapioCategoria()}{dto.NomeCategoria}/{dto.Foto}",
                DataCadastro = dto.DataCadastro,
                NomeCategoria = dto.NomeCategoria
            };
        }
    }
}
