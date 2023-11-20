using ProjetoCoffeeShoopSaoPauloDTO.Usuario;
using ProjetoCoffeeShoopSaoPauloRepository.interfaces.Usuario;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;
using System.Collections.Generic;

namespace ProjetoCoffeeShoopSaoPauloServices.services
{
    public class UsuarioService : IUsuarioService
    {

        private IUsuarioRepository _respository;
        public UsuarioService(IUsuarioRepository repository)
        {
            this._respository = repository;
        }
        public List<UsuarioDTO> ListarUsuario(int? Id) => _respository.ListarUsuario(Id);
       
        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            _respository.CadastrarUsuario(usuario);
        }
        public void AtualizarUsuario(UsuarioDTO usuario)
        {
            _respository.AtualizarUsuario(usuario);
        }
      
        public void DeletarUsuario(int Id)
        {
            _respository.DeletarUsuario(Id);
        }

     
    }
}
