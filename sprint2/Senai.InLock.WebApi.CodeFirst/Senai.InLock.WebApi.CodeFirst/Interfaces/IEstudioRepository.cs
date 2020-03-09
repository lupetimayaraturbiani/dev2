
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.CodeFirst.Interfaces
{
    interface IEstudioRepository
    {
        Estudios BuscarPorId(int id);

        void Cadastrar(Estudios novoEstudio);

        List<Estudios> Listar();

        void Atualizar(int id, Estudios estudioAtualizado);

        void Deletar(int id);
    }
}
