using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.CodeFirst.Interfaces;
using Senai.Inlock.WebApi.CodeFirst.Repositories;

using Senai.InLock.WebApi.CodeFirst.Domains;

namespace Senai.Inlock.WebApi.CodeFirst.Controllers
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogos jogoAtualizado)
        {
            if (jogoAtualizado != null)
            {
                try
                {
                    _jogoRepository.Atualizar(id, jogoAtualizado);

                    return NoContent();
                }
                catch (Exception e)
                {
                    return BadRequest("Não foi possível atualizar o jogo pois ele não existe");
                }
            }

            return NotFound("Jogo não encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Jogos jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                _jogoRepository.Deletar(id);

                return Ok($"O Jogo {id} foi deletado com sucesso");
            }

            return NotFound("Jogo não encontrado");
        }
    }
}