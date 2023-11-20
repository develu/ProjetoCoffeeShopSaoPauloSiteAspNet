using System;

namespace ProjetoCoffeeShoopSaoPaulo.Models.Categoria
{
    public class CategoriaModel
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
