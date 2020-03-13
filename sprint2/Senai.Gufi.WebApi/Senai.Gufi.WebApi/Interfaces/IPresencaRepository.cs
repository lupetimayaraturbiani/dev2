using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> Listar();

        Presenca BuscarPorId(int id);

        void Cadastrar(Presenca novaPresenca);

        void Atualizar(int id, Presenca presencaAtualizada);

        void Deletar(int id);
    }
}
