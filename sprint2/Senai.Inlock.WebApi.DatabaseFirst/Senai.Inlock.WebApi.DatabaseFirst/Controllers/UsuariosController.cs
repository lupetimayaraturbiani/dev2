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
    public class UsuariosController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public List<Usuarios> Get()
        {
            return _usuarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            if (novoUsuario != null)
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }

            return BadRequest("Os campos não foram preenchidos corretamente");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }
    }
}