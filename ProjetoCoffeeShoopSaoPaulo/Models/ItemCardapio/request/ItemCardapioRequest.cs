using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCoffeeShoopSaoPaulo.Models.ItemCardapio.request
{
    public class ItemCardapioRequest
    {
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [MaxLength(45)]
        public string Nome { get; set; }

        [MaxLength(100)]
        [Required]
        public string Descricao { get; set; }

        public IFormFile Foto { get; set; }

        [Required(ErrorMessage = "O campo Categoria é obrigatório!")]
        public int idCategoria { get; set; }

        public bool updateFoto { get; set; } = false;

        public string old_foto { get; set; }

        public bool? hasFoto { get; set; } = false;

        public int IdOldCategoria { get; set; }
    }
}
