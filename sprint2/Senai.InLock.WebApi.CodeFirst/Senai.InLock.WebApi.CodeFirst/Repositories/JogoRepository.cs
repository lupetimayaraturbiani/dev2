
using Senai.Inlock.WebApi.CodeFirst.Interfaces;
using Senai.InLock.WebApi.CodeFirst.Context;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.CodeFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Jogos jogoAtualizado)
        {
            var jogoBuscado = BuscarPorId(id);

            if (jogoBuscado != null)
            {
                jogoBuscado.NomeJogo = jogoAtualizado.NomeJogo;
                jogoBuscado.Descricao = jogoAtualizado.Descricao;
                jogoBuscado.Valor = jogoAtualizado.Valor;
                jogoBuscado.IdEstudio = jogoAtualizado.IdEstudio;
                ctx.Jogos.Update(jogoBuscado);
                ctx.SaveChanges();
            }

        }

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Jogos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }
    }
}
