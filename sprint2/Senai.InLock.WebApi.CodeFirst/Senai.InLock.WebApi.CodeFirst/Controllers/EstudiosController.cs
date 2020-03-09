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
    public class EstudiosController : Controller
    {
        private IEstudioRepository _estudioRepository;

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public List<Estudios> Get()
        {
            return _estudioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_estudioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Estudios novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudios estudioAtualizado)
        {
            if (estudioAtualizado != null)
            {
                try
                {
                    _estudioRepository.Atualizar(id, estudioAtualizado);

                    return NoContent();
                }
                catch (Exception e)
                { 
                    return BadRequest("Não foi possível atualizar o estudio pois ele não existe");
                }
            }

            return NotFound("Estudio não encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Estudios estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado != null)
            {
                _estudioRepository.Deletar(id);

                return Ok($"O Estudio {id} foi deletado com sucesso");
            }

            return NotFound("Estudio não encontrado");

        }
    }
}