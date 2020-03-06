using Senai.Inlock.WebApi.DatabaseFirst.Domains;
using Senai.Inlock.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DatabaseFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Estudios estudioAtualizado)
        {
           var estudioBuscado = BuscarPorId(id);
            // Buscar quem eu quero

            // Atualizar as props
        // estudio buscado <- estudioAtualizado
            if (estudioBuscado != null)
            {
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
                estudioBuscado.Jogos = estudioAtualizado.Jogos;
        // Atualizar no banco
                ctx.Estudios.Update(estudioBuscado);
        // Salvo as alterações
                ctx.SaveChanges();
            }

            
        }

        public Estudios BuscarPorId(int id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            ctx.Estudios.Add(novoEstudio);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Estudios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
            return ctx.Estudios.ToList();
        }
    }
}
