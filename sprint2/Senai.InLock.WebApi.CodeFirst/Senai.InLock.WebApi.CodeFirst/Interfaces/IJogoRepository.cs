
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.CodeFirst.Interfaces
{
    interface IJogoRepository
    {
        List<Jogos> Listar();

        void Cadastrar(Jogos novoJogo);

        Jogos BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, Jogos jogoAtualizado);
    }
}
