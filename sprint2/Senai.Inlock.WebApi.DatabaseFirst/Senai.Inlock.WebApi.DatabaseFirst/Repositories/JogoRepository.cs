using Senai.Inlock.WebApi.DatabaseFirst.Domains;
using Senai.Inlock.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DatabaseFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);
            ctx.SaveChanges();
        }

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }
    }
}
