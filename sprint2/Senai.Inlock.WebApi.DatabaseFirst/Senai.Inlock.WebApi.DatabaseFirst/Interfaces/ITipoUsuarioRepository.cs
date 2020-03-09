using Senai.Inlock.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DatabaseFirst.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario novoTipoUsuario);

        TipoUsuario BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, TipoUsuario tipoAtualizado);
    }
}
