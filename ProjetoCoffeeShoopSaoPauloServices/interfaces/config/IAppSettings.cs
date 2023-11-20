namespace ProjetoCoffeeShopSaoPauloServices.interfaces.config
{
    public interface IAppSettings
    {
        string Environment { get; }
        string SendMailPassword { get; }

    }
}
