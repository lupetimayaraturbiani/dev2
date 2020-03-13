using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Instituicao iAtualizada)
        {
            Instituicao iBuscada = BuscarPorId(id);

            iBuscada.Cnpj = iAtualizada.Cnpj;
            iBuscada.NomeFantasia = iAtualizada.NomeFantasia;
            iBuscada.Endereco = iAtualizada.Endereco;
            iBuscada.Evento = iAtualizada.Evento;

            ctx.Instituicao.Update(iBuscada);
            ctx.SaveChanges();

        }

        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id);
        }

        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicao.Add(novaInstituicao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Instituicao.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
