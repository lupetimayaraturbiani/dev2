using senai.filme.webapi.Domains;
using senai.filme.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filme.webapi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source=DEV601\\SQLEXPRESS;initial catalog=Filmes;user id=sa;pwd=sa@132;";

        public List<FilmeDomain> ListarFilmes()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme, Titulo FROM Filmes";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32((rdr[0])),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        filmes.Add(filme);

                    }

                }

            }
            return filmes;
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryPorId = "SELECT IdFilme, Titulo FROM Filmes WHERE IdFilme = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryPorId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),


                            Titulo = rdr["Titulo"].ToString()

                        };

                        return filme;
                    }

                    return null;

                }
            }
        }

        public void CadastrarFilme(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryCadastrar = "INSERT INTO Filmes(Titulo) VALUES (@Titulo)";


                SqlCommand cmd = new SqlCommand(queryCadastrar, con);

                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarFilme(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtualizar = "UPDATE Filmes SET Titulo = @Titulo WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@ID", filme.IdFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarFilme(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDeletar = "DELETE FROM Filmes WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
