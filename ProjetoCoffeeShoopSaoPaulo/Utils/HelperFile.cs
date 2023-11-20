using Microsoft.AspNetCore.Http;
using ProjetoCoffeeShoopSaoPaulo.Utils;
using System;
using System.IO;

namespace ProjetoCoffeeShopSaoPauloSite.Utils
{
    public static class HelperFile
    {
        public static void SaveFotoItem(string categoria, IFormFile file, string nameFile)
        {

            var filePath = $"{Directory.GetCurrentDirectory()}/wwwroot{ConfigConstants.GetPathItemCardapioCategoria()}{categoria}".Replace("\\", "/");

            DirectoryHelper.Create(filePath);

            using (var fs = new FileStream($"{filePath}/{nameFile}", FileMode.CreateNew)) file.CopyTo(fs);

        }

        public static void SaveFotoCategoria(IFormFile file, string nameFile)
        {

            var filePath = $"{Directory.GetCurrentDirectory()}/wwwroot{ConfigConstants.GetPathCategoria()}".Replace("\\", "/");

            DirectoryHelper.Create(filePath);

            using (var fs = new FileStream($"{filePath}{nameFile}", FileMode.CreateNew)) file.CopyTo(fs);

        }

        public static void DeleteFotoItem(string oldFile)
        {

            var filePath = $"{Directory.GetCurrentDirectory()}/wwwroot".Replace("\\", "/");

            oldFile = $"{filePath}/{oldFile}";

            if (File.Exists(oldFile))
            {
                try
                {
                    File.Delete(oldFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            }
            else
            {
                Console.WriteLine("Specified file doesn't exist");
            }
        }

        public static void DeleteFotoCategoria(string oldFile)
        {

            var filePath = $"{Directory.GetCurrentDirectory()}/wwwroot".Replace("\\", "/");

            oldFile = $"{filePath}/{oldFile}";

            if (File.Exists(oldFile))
            {
                try
                {
                    File.Delete(oldFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            }
            else
            {
                Console.WriteLine("Specified file doesn't exist");
            }
        }

        public static string GetPathFotoItemCardapio(string nameFile, string categoria)
        {
            var path = $"{Directory.GetCurrentDirectory()}/wwwroot{ConfigConstants.GetPathItemCardapioCategoria()}{categoria}/{nameFile}";
            path = path.Replace("\\", "/");
            return path;
        }
    }
}
