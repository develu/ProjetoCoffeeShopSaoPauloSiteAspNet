using ProjetoCoffeeShoopSaoPauloDTO.Usuario;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPauloServices.interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> ListarUsuario(int? Id);
        void CadastrarUsuario(UsuarioDTO usuario);
        void AtualizarUsuario(UsuarioDTO usuario);
        void DeletarUsuario(int Id);
    }
}
