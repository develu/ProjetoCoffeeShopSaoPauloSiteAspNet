
using Microsoft.Extensions.Configuration;
using ProjetoCoffeeShopSaoPauloServices.interfaces.config;
using System.IO;


namespace ProjetoCoffeeShopSaoPauloServices.services.config
{
    public class AppSettings : IAppSettings
    {
        public string Environment { get; set; }

        public string SendMailPassword { get; set; }

        public static IConfigurationRoot Configuration { get; private set; }

        public AppSettings()
        {
            IConfigurationBuilder config = new ConfigurationBuilder();
            
            config.AddJsonFile(Directory.GetCurrentDirectory() + "\\AppSettings.json", false);

            var root = config.Build();
            
            root.Bind(this);
        }

    }
}
