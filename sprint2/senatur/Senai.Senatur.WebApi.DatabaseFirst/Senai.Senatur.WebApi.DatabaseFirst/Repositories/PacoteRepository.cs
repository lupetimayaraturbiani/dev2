using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        SenaturContext ctx = new SenaturContext();

        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = BuscarPorId(id);

            pacoteAtualizado.NomePacote = pacoteBuscado.NomePacote;
            pacoteAtualizado.Descricao = pacoteBuscado.Descricao;
            pacoteAtualizado.DataIda = pacoteBuscado.DataIda;
            pacoteAtualizado.DataVolta = pacoteBuscado.DataVolta;
            pacoteAtualizado.Valor = pacoteBuscado.Valor;
            pacoteAtualizado.Ativo = pacoteBuscado.Ativo;
            pacoteAtualizado.NomeCidade = pacoteBuscado.Ativo;

            ctx.Pacotes.Update(pacoteBuscado);
            ctx.SaveChanges();

        }

        public Pacotes BuscarPorId(int id)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        public void Cadastrar(Pacotes novoPacote)
        {
            ctx.Pacotes.Add(novoPacote);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {

        }

        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }

    }
}
