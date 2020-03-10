using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;
using Senai.Senatur.WebApi.DatabaseFirst.Repositories;

namespace Senai.Senatur.WebApi.DatabaseFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacoteRepository _pacotesRepository;

        public PacotesController()
        {
            _pacotesRepository = new PacoteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacotesRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            _pacotesRepository.Cadastrar(novoPacote);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_pacotesRepository.BuscarPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            _pacotesRepository.Atualizar(id, pacoteAtualizado);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pacotesRepository.Deletar(id);

            return Ok("O pacote foi deletado com sucesso");
        }
    }
}