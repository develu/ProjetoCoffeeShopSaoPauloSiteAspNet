using System.ComponentModel.DataAnnotations;

namespace ProjetoCoffeeShoopSaoPaulo.Models.Usuario.request
{
    public class UsuarioRequest
    {
        
        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo 'E-mail' é Inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' é obrigatório!")]
        public string Senha { get; set; }

    }
}
