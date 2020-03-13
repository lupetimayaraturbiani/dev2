using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> Listar();

        Instituicao BuscarPorId(int id);

        void Cadastrar(Instituicao novaInstituicao);

        void Atualizar(int id, Instituicao iAtualizada);

        void Deletar(int id);
    }
}
