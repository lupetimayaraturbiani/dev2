using senai.filme.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filme.webapi.Interfaces
{
    interface IFilmeRepository
    {
       
        /// Método Listar
        List<FilmeDomain> ListarFilmes();

        /// Método Listar por Id
        FilmeDomain BuscarPorId(int id);

        void CadastrarFilme(FilmeDomain filme);

        void AtualizarFilme(FilmeDomain filme);

        void DeletarFilme(FilmeDomain filme);
    }
}
