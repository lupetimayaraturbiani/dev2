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
    public class FilmesController : ControllerBase
    {

        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();

        }

        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRepository.ListarFilmes();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FilmeDomain filmeBuscado = new FilmeDomain();

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum filme encontrado");
            }

            return Ok(filmeBuscado);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.CadastrarFilme(novoFilme);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put(FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filmeAtualizado.IdFilme);

            if (filmeBuscado != null)
            {
                try
                {
                    _filmeRepository.AtualizarFilme(filmeAtualizado);

                    return NoContent();

                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }

            return NotFound("Não rolou mudar isso não parceiro");
        }

        [HttpDelete]
        public IActionResult DeletarFilme(FilmeDomain filme)
        {
            _filmeRepository.DeletarFilme(FilmeDomain filme.IdFilme);

            return Ok("Filme deletado");
        }


       

    }
}