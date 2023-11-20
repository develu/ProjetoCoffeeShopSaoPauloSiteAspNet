using ProjetoCoffeeShoopSaoPauloRepository.interfaces.Login;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoCoffeeShoopSaoPauloRepository.SQLServer.respositorys.Login
{
    public class LoginRepository : ILoginRepository
    {
        private string conexao = Config.connectionString();
        public string login(string email, string senha)
        {
            string response = null;

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand("sp_login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {                           
                            response = reader["nome"].ToString();
                        }
                           
                    }
                }
            }

            return response;

        }
    }
}
