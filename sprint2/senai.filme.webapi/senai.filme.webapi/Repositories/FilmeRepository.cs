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
        GeneroRepository _generoRepository = new GeneroRepository();

        private string StringConexao = "Data Source=DEV601\\SQLEXPRESS;initial catalog=Filmes;user id=sa;pwd=sa@132;";

        public List<FilmeDomain> ListarFilmes()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme, Titulo, Generos.IdGenero, Generos.Nome FROM Filmes " +
                                "INNER JOIN Generos ON Generos.IdGenero = Filmes.IdGenero";

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
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        filme.Genero = _generoRepository.BuscarPorId(filme.IdGenero);

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
                string queryPorId = "SELECT IdFilme, Titulo, IdGenero FROM Filmes WHERE IdFilme = @ID";

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
                            IdFilme = Convert.ToInt32((rdr[0])),


                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero = Convert.ToInt32((rdr[2])),

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

        public void DeletarFilme(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDeletar = "DELETE FROM Filmes WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", Id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
