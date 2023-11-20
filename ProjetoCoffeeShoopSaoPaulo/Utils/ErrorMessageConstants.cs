namespace ProjetoCoffeeShopSaoPauloSite.Utils
{
    public static class ErrorMessageConstants
    {
        public static string MsgErrorMaxLenght(string campo, int tamanho)
        {
            return $"O campo {campo} deve conter no máximo {tamanho} caracteres!";
        }

        public static string MsgErrorRequired(string campo)
        {
            return $"O campo {campo} é obrigatório!";
        }
    }
}
