using System;

namespace ProjetoCoffeeShoopSaoPauloDTO.Categoria
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
