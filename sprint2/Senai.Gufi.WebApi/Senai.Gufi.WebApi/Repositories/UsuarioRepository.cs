using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;
            usuarioBuscado.Genero = usuarioAtualizado.Genero;
            usuarioBuscado.DataNascimento = usuarioAtualizado.DataNascimento;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            usuarioBuscado.Presenca = usuarioAtualizado.Presenca;

            ctx.Usuario.Update(usuarioBuscado);
            ctx.SaveChanges();

        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuario.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}
