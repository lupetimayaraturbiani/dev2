using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.DatabaseFirst.Domains;
using Senai.Inlock.WebApi.DatabaseFirst.Interfaces;
using Senai.Inlock.WebApi.DatabaseFirst.Repositories;

namespace Senai.Inlock.WebApi.DatabaseFirst.Controllers
{
    public class TipoUsuarioController : Controller
    {

        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public List<TipoUsuario> Listar()
        {
            return _tipoUsuarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipoUsuario)
        {
            if (novoTipoUsuario != null)
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

                return StatusCode(201);
            }

            return BadRequest("Os campos não foram preenchidos corretamente");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }
    }
}