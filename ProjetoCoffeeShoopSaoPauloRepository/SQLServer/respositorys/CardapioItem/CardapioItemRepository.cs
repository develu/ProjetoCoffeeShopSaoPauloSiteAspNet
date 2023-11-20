using ProjetoCoffeeShoopSaoPauloRepository.interfaces.CardapioItem;
using ProjetoCoffeeShopSaoPauloDTO.CardapioItem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoCoffeeShoopSaoPauloRepository.SQLServer.respositorys.CardapioItem
{
    public class CardapioItemRepository : ICardapioItemRepository
    {
        private string conexao = Config.connectionString();

        public List<CardapioItemDTO> ListarCardapioItem(int IdCardapioItem = 0)
        {
            var lst = new List<CardapioItemDTO>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand("sp_selectCardapioItem", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (IdCardapioItem != 0)
                    {
                        cmd.Parameters.AddWithValue("@IdItem", IdCardapioItem);
                    }

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var dto = new CardapioItemDTO();
                            dto.Id = (int)reader["Id"];
                            dto.Nome = reader["Nome"].ToString();
                            dto.Descricao = reader["Descricao"].ToString();
                            dto.Foto = reader["Foto"].ToString();
                            dto.DataCadastro = (DateTime)reader["Data_cadastro"];
                            dto.NomeCategoria = reader["NomeCategoria"].ToString();

                            lst.Add(dto);
                        }
                    }

                }
            }

            return lst;
        }

        public void PostCardapioItem(CadastrarCardapioItemDTO cardapioItemDTO)
        {
            string sp = "sp_insert_CardapioItem";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@v_Nome", cardapioItemDTO.Nome);
                    cmd.Parameters.AddWithValue("@v_Descricao", cardapioItemDTO.Descricao);
                    cmd.Parameters.AddWithValue("@v_Foto", cardapioItemDTO.Foto);
                    cmd.Parameters.AddWithValue("@v_IdCategoria", cardapioItemDTO.IdCategoria);

                    conn.Open();

                    cmd.ExecuteScalar();

                }
            }
        }

        public void UpdateCardapioItem(UpdateItemCardapioDTO cardapioItemDto, int id)
        {
            string sp = "sp_update_CardapioItem";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@v_Id", id);
                    cmd.Parameters.AddWithValue("@v_Nome", cardapioItemDto.Nome);
                    cmd.Parameters.AddWithValue("@v_Descricao", cardapioItemDto.Descricao);
                    cmd.Parameters.AddWithValue("@v_Foto", cardapioItemDto.Foto);
                    cmd.Parameters.AddWithValue("@v_IdCategoria", cardapioItemDto.IdCategoria);

                    conn.Open();

                    cmd.ExecuteScalar();

                }
            }

        }

        public void DeleteCardapioItem(int id)
        {
            string sp = "sp_delete_CardapioItem";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@v_Id", id);

                    conn.Open();

                    cmd.ExecuteScalar();
                }
            }
        }

        public UpdateItemCardapioDTO GetItemCardapioById(int id)
        {

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand("sp_selectCardapioItem", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdItem", id);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            var dto = new UpdateItemCardapioDTO();
                            dto.Id = (int)reader["Id"];
                            dto.Nome = reader["Nome"].ToString();
                            dto.Descricao = reader["Descricao"].ToString();
                            dto.Foto = reader["Foto"].ToString();
                            dto.NomeCategoria = reader["NomeCategoria"].ToString();
                            dto.IdCategoria = Convert.ToInt32(reader["IdCategoria"].ToString());

                            return dto;
                        }
                    }

                }
            }

            return null;
        }

        public void PostCardapioItem(CardapioItemDTO cardapioItemDTO)
        {
            throw new NotImplementedException();
        }

        public List<CardapioItemDTO> ListarCardapioItemByIdCategoria(int idCategoria)
        {
            var lst = new List<CardapioItemDTO>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand("sp_selectCardapioItem_by_idcategoria", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var dto = new CardapioItemDTO();
                            dto.Id = (int)reader["Id"];
                            dto.Nome = reader["Nome"].ToString();
                            dto.Descricao = reader["Descricao"].ToString();
                            dto.Foto = reader["Foto"].ToString();
                            dto.DataCadastro = (DateTime)reader["Data_cadastro"];
                            dto.NomeCategoria = reader["NomeCategoria"].ToString();

                            lst.Add(dto);
                        }
                    }

                }
            }

            return lst;
        }
    }
}
