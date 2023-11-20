using ProjetoCoffeeShoopSaoPauloDTO.Usuario;
using ProjetoCoffeeShoopSaoPauloRepository.interfaces.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoCoffeeShoopSaoPauloRepository.SQLServer.respositorys.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string conexao = Config.connectionString();
        public List<UsuarioDTO> ListarUsuario(int? Id)
        {
            var lista = new List<UsuarioDTO>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand("sp_sel_usuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (Id != null)
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                    }

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new UsuarioDTO();

                            usuario.Id = (int)reader["id"];
                            usuario.Nome = reader["nome"].ToString();
                            usuario.Email = reader["email"].ToString();
                            usuario.Senha = reader["senha"].ToString();
                            usuario.DataCriacao = Convert.ToDateTime(reader["data_criacao"].ToString());

                            lista.Add(usuario);
                        }
                    }
                }
            }

            return lista;
        }

        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            string sp = "sp_insert_usuario";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }
        public void AtualizarUsuario(UsuarioDTO usuario)
        {
            string sp = "sp_update_usuario";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", usuario.Id);
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void DeletarUsuario(int Id)
        {
            string sp = "sp_del_usuario";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", Id);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
