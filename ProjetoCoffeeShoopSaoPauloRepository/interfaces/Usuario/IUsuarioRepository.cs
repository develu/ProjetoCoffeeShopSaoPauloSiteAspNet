using ProjetoCoffeeShoopSaoPauloDTO.Usuario;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPauloRepository.interfaces.Usuario
{
   public interface IUsuarioRepository
    {
        List<UsuarioDTO> ListarUsuario(int? Id);
        void CadastrarUsuario(UsuarioDTO usuario);
        void AtualizarUsuario(UsuarioDTO usuario);
        void DeletarUsuario(int Id);
    }
}
