using ProjetoCoffeeShoopSaoPauloDTO.Usuario;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCoffeeShoopSaoPaulo.Models.Usuario
{
    public class Usuario
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo 'E-mail' é Inválido!")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo Senha é obrigatório!")]
        public string Senha { get; set; }

        [DisplayName("Data de Cadastro")]
        public DateTime DataCriacao { get; set; }

        public static explicit operator Usuario(UsuarioDTO dto)
        {
            return new Usuario()
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                DataCriacao = dto.DataCriacao
            };
        }

    }
}
