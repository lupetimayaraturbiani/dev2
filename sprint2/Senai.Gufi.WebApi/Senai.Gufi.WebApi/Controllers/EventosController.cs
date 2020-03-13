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
    public class EventosController : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        public EventosController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _eventoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Evento novoEvento)
        {
            if (novoEvento != null)
            {
                _eventoRepository.Cadastrar(novoEvento);

                return StatusCode(201);
            }

            return BadRequest("Não foi possível cadastrar seu evento, verifique os campos preenchidos e tente novamente");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento eventoAtualizado)
        {
            if (eventoAtualizado == null)
            {
                return NotFound("Não possível atualizar esse evento pois ele não existe.");
            }

            try
            {
                _eventoRepository.Atualizar(id, eventoAtualizado);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível atualizar o evento.");
            }

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

            if (eventoBuscado != null)
            {
                _eventoRepository.Deletar(id);

                return Ok("O evento foi deletado com sucesso!");
            }

            return NotFound("O evento não foi deletado posi ele não existe.");
        }
    }
}