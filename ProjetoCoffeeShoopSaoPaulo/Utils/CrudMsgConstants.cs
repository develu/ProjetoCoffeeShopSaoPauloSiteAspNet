namespace ProjetoCoffeeShopSaoPauloSite.Utils
{
    public static class CrudMsgConstants
    {
        public static string MsgInsertSuccess(string obj)
        {
            return $"{obj} cadastrado com sucesso!";
        }

        public static string MsgInsertError(string obj)
        {
            return $"erro para cadastrar {obj}!";
        }

        public static string MsgUpdateSuccess(string obj)
        {
            return $"{obj} atualizado com sucesso!";
        }

        public static string MsgUpdateError(string obj)
        {
            return $"erro para atualizar {obj}!";
        }

        public static string MsgDeleteSuccess(string obj)
        {
            return $"{obj} deletado com sucesso!";
        }

        public static string MsgDeleteError(string obj)
        {
            return $"erro para deletar {obj}!";
        }

        public static string ErrorLoadList(string obj)
        {
            return $"erro para carregar lista de {obj}!";
        }

    }

}
