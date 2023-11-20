using Microsoft.Extensions.DependencyInjection;
using ProjetoCoffeeShoopSaoPauloServices.interfaces;
using ProjetoCoffeeShoopSaoPauloServices.services;
using ProjetoCoffeeShopSaoPauloServices.interfaces.config;
using ProjetoCoffeeShopSaoPauloServices.services.config;

namespace ProjetoCoffeeShoopSaoPauloInjection.ExtensaoService
{
    public static class ExtensaoServices
    {
        public static IServiceCollection RegistrarServices(this IServiceCollection servicos)
        {
            servicos.AddScoped<ICardapioItemService, CardapioItemService>();
            servicos.AddScoped<ILoginService, LoginService>();
            servicos.AddScoped<IUsuarioService, UsuarioService>();
            servicos.AddScoped<ICategoriaService, CategoriaService>();
            servicos.AddSingleton<IAppSettings, AppSettings>();
            return servicos;
        }
    }
}
