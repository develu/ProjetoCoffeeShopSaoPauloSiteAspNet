using System;
using System.IO;

namespace ProjetoCoffeeShopSaoPauloSite.Utils
{
    public static class DirectoryHelper
    {
          
        public static void Create(String path)
        {
            var dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists) dirInfo.Create();

        }

    }
}

