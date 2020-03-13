using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {

        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Presenca presencaAtualizada)
        {
            Presenca presencaBuscada = BuscarPorId(id);

            presencaBuscada.Situacao = presencaAtualizada.Situacao;
            presencaBuscada.IdEvento = presencaAtualizada.IdEvento;
            presencaBuscada.IdUsuario = presencaAtualizada.IdUsuario;

            ctx.Presenca.Update(presencaBuscada);
            ctx.SaveChanges();
        }

        public Presenca BuscarPorId(int id)
        {
            return ctx.Presenca.FirstOrDefault(p => p.IdPresenca == id);
        }

        public void Cadastrar(Presenca novaPresenca)
        {
            ctx.Presenca.Add(novaPresenca);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Presenca.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Presenca> Listar()
        {
            return ctx.Presenca.ToList();
        }
    }
}
