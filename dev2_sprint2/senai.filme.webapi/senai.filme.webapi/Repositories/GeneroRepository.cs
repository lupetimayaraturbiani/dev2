using senai.filme.webapi.Domains;
using senai.filme.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filme.webapi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source=DEV601\\SQLEXPRESS;initial catalog=Filmes;user id=sa;pwd=sa@132;";


        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdGenero, Nome FROM Generos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32((rdr[0])),
                            Nome = rdr["Nome"].ToString()
                        };

                        generos.Add(genero);

                    }
                }
            }

            return generos;
        }
        public bool Cadastrar(string Nome)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"INSERT INTO Generos (Nome) VALUES ('{Nome}')";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32((rdr[0])),
                            Nome = rdr["Nome"].ToString()
                        };

                    }
                }
            }
            return true;
        }

        public void Atualizar(string Nome, int IdGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"UPDATE Generos SET Nome=('{Nome}') WHERE IdGenero=('{IdGenero}')";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32((rdr[0])),
                            Nome = rdr["Nome"].ToString()
                        };

                    }
                }
            }

        }

        public void Deletar(int IdGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"DELETE FROM Generos WHERE IdGenero={IdGenero}";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                   }
                }
            }

        public GeneroDomain BuscarPorId(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdGenero"
            }
        }
    }

    }
    }


