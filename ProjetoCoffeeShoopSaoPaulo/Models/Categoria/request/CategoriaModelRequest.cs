using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCoffeeShopSaoPauloSite.Models.Categoria.request
{
    public class CategoriaModelRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(150, ErrorMessage = "O campo Descrição deve conter no máximo 150 caracteres!")]
        [Required(ErrorMessage = "A Descrição é obrigatória!")]
        public string Descricao { get; set; }

        public IFormFile Foto { get; set; }

        public bool updateFoto { get; set; } = false;

        public string old_foto { get; set; }

        public bool? hasFoto { get; set; } = false;


    }
}
