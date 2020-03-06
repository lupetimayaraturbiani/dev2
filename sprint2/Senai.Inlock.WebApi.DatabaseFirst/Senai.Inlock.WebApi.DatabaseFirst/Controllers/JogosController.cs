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
    [Route("api/[controller]")]

    [Produces("application/json")]

    [ApiController]
    public class JogosController : Controller
    {
        private IJogoRepository _jogoRepository;

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public List<Jogos> Get()
        {
            return _jogoRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);

            if (novoJogo == null)
            {
                return BadRequest("Os campos não foram preenchidos corretamente");
            }

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jogoRepository.BuscarPorId(id));
        }
    }
}