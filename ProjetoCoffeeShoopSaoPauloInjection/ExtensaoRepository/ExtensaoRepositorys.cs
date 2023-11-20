using Microsoft.Extensions.DependencyInjection;
using ProjetoCoffeeShoopSaoPauloRepository.interfaces.CardapioItem;
using ProjetoCoffeeShoopSaoPauloRepository.interfaces.Categoria;
using ProjetoCoffeeShoopSaoPauloRepository.interfaces.Login;
using ProjetoCoffeeShoopSaoPauloRepository.interfaces.Usuario;
using ProjetoCoffeeShoopSaoPauloRepository.SQLServer.respositorys.CardapioItem;
using ProjetoCoffeeShoopSaoPauloRepository.SQLServer.respositorys.Categoria;
using ProjetoCoffeeShoopSaoPauloRepository.SQLServer.respositorys.Login;
using ProjetoCoffeeShoopSaoPauloRepository.SQLServer.respositorys.Usuario;

namespace ProjetoCoffeeShoopSaoPauloInjection.ExtensaoRepository
{
    public static class ExtensaoRepositorys
    {
        public static IServiceCollection RegistrarRepository(this IServiceCollection servicos)
        {
            servicos.AddScoped<ICardapioItemRepository, CardapioItemRepository>();
            servicos.AddScoped<ILoginRepository, LoginRepository>();
            servicos.AddScoped<IUsuarioRepository, UsuarioRepository>();
            servicos.AddScoped<ICatetoriaRepository, CategoriaRepository>();

            return servicos;
        }
    }
}
