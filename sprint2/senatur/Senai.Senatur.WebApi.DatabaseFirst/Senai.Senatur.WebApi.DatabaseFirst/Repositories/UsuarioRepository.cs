using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SenaturContext ctx = new SenaturContext();

        public Usuarios BuscarPorEmailSenha(string Email, string Senha)
        {
            Usuarios usuarioLogado = ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
            return usuarioLogado;
            
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }
    }
}
