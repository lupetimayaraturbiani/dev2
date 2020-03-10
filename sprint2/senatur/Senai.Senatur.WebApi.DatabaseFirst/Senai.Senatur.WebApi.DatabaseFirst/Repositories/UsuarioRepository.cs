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

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
