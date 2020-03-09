using Senai.Inlock.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DatabaseFirst.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();

        void Cadastrar(Usuarios novoUsuario);

        Usuarios BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, Usuarios usuarioAtualizado);

    }
}
