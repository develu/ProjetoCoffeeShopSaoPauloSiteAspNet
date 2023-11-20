using System.ComponentModel.DataAnnotations;

namespace ProjetoCoffeeShoopSaoPaulo.Models.FaleConosco
{
    public class FaleConosco
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo 'Nome' deve conter no máximo 50 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório")]
        [MaxLength(70, ErrorMessage = "O campo 'E-mail' deve conter no máximo 70 caracteres!")]
        [EmailAddress(ErrorMessage = "O campo E-mail é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Assunto' é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo 'Assunto' deve conter no máximo 70 caracteres!")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "O campo 'Mensagem' é obrigatório")]
        [MaxLength(2000, ErrorMessage = "O campo 'Mensagem' deve conter no máximo 2000 caracteres!")]
        public string Mensagem { get; set; }
    }
}
