using System;

namespace ProjetoCoffeeShopSaoPauloDTO.CardapioItem
{
    public class CardapioItemDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public DateTime DataCadastro { get; set; }        
        public string NomeCategoria { get; set; }
        public int IdCategoria { get; set; }

    }
}
