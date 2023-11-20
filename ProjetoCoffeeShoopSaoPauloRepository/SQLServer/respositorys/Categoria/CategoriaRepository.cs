using ProjetoCoffeeShoopSaoPauloDTO.Categoria;
using ProjetoCoffeeShoopSaoPauloRepository.interfaces.Categoria;
using ProjetoCoffeeShopSaoPauloDTO.Categoria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoCoffeeShoopSaoPauloRepository.SQLServer.respositorys.Categoria
{
    public class CategoriaRepository : ICatetoriaRepository
    {
        private static string conexao = Config.connectionString();

        public List<CategoriaDTO> GetCategorias()
        {

            string sp = "sp_sel_categoria";

            var lstCategoria = new List<CategoriaDTO>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dto = new CategoriaDTO();

                            dto.IdCategoria = Convert.ToInt32(reader["Id"].ToString());
                            dto.Nome = reader["Nome"].ToString();
                            dto.Foto = reader["Foto"].ToString();
                            dto.Descricao = reader["Descricao"].ToString();
                            dto.DataCadastro = Convert.ToDateTime(reader["Data_cadastro"].ToString());

                            lstCategoria.Add(dto);

                        }
                    }

                }

                return lstCategoria;

            }

        }

        public void PostCategoria(CadastrarCategoriaDTO dto)
        {
            string sp = "sp_insert_categoria";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@v_Nome", dto.Nome);
                    cmd.Parameters.AddWithValue("@v_Foto", dto.Foto);
                    cmd.Parameters.AddWithValue("@v_Descricao", dto.Descricao);

                    cmd.ExecuteScalar();

                }
            }

        }

        public void UpdateCategoria(AtualizarCategoriaDTO dto)
        {
            string sp = "sp_update_categoria";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@v_Id", dto.IdCategoria);
                    cmd.Parameters.AddWithValue("@v_Nome", dto.Nome);
                    cmd.Parameters.AddWithValue("@v_Foto", dto.Foto);
                    cmd.Parameters.AddWithValue("@v_Descricao", dto.Descricao);

                    cmd.ExecuteScalar();

                }
            }
        }

        public void DeleteCategoria(int IdCategoria)
        {
            string sp = "sp_delete_categoria";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@v_Id", IdCategoria);


                    cmd.ExecuteScalar();

                }
            }
        }

        public CategoriaDTO GetCategoriaById(int id)
        {

            string sp = "sp_sel_categoria";

            var categoria = new CategoriaDTO();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@v_Id", id);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dto = new CategoriaDTO();

                            dto.IdCategoria = Convert.ToInt32(reader["Id"].ToString());
                            dto.Nome = reader["Nome"].ToString();
                            dto.Descricao = reader["Descricao"].ToString();
                            dto.Foto = reader["Foto"].ToString();
                            dto.DataCadastro = Convert.ToDateTime(reader["Data_cadastro"].ToString());

                            categoria = dto;

                        }
                    }

                }


            }
            return categoria;
        }
    }
}
