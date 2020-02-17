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
        public IActionResult Post(GeneroDomain genero)
        {
            _generoRepository.Cadastrar(genero);

            return StatusCode(201);
        }
    }
}