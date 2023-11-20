using ProjetoCoffeeShoopSaoPauloRepository.interfaces.Login;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;

namespace ProjetoCoffeeShoopSaoPauloServices.services
{

    public class LoginService : ILoginService
    {
        private ILoginRepository _repository;

        public LoginService(ILoginRepository repository)
        {
            this._repository = repository;
        }
        public string login(string email, string senha)
        {
            return _repository.login(email, senha);
        }
    }
}
