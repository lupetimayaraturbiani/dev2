using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// listar todos os usuarios
        /// </summary>
        /// <returns></returns>
        List<Usuarios> Listar();

    }
}
