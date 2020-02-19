using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.filme.webapi.Domains;
using senai.filme.webapi.Interfaces;
using senai.filme.webapi.Repositories;

namespace senai.filme.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _generoRepository { get; set; }

        public GenerosController()
        {
            _generoRepository = new GeneroRepository();

        }

        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            return _generoRepository.Listar();
        }

        [HttpPost]
        public bool Post(GeneroDomain genero)
        {
           return  _generoRepository.Cadastrar("Terror");
        }

        [HttpPut]
        public IActionResult Put(string Nome, int IdGenero)
        {
            _generoRepository.Atualizar("Romance", 3);
            return StatusCode(200);
        }

        [HttpDelete]
        public IActionResult Delete(int IdGenero)
        {
            _generoRepository.Deletar(4);
            return StatusCode(200);
        }
        [HttpGet ("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado");
            }

            return Ok(generoBuscado);
        }

    }
}