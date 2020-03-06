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

        public Estudios BuscarPorId(int id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            ctx.Estudios.Add(novoEstudio);
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
            return ctx.Estudios.ToList();
        }
    }
}
