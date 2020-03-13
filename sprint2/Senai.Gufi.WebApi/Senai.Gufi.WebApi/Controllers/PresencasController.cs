using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase
    {
        private IPresencaRepository _presencaRepository;

        public PresencasController()
        {
            _presencaRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_presencaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _presencaRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Presenca novaPresenca)
        {
            if (novaPresenca != null)
            {
                _presencaRepository.Cadastrar(novaPresenca);

                return StatusCode(201);
            }

            return NotFound("Não foi possível cadastrar essa presença pois não foi encontrada");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca presencaAtualizada)
        {
            if (presencaAtualizada == null)
            {
                return NotFound("A preença não foi atualizada pois ela não existe");
            }

            try
            {
                _presencaRepository.Atualizar(id, presencaAtualizada);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest("A presença não pôde ser atualizada.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Presenca presencaBuscada = _presencaRepository.BuscarPorId(id);

            if (presencaBuscada != null)
            {
                _presencaRepository.Deletar(id);

                return Ok("A presença  foi deleta com sucesso!");
            }

            return NotFound("A presença não foi deletada pois ela não existe.");
        }



    }
}