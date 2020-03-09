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
    public class TipoUsuarioController : Controller
    {

        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public List<TipoUsuario> Listar()
        {
            return _tipoUsuarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipoUsuario)
        {
            if (novoTipoUsuario != null)
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

                return StatusCode(201);
            }

            return BadRequest("Os campos não foram preenchidos corretamente");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoAtualizado)
        {
            if (tipoAtualizado != null)
            {
                _tipoUsuarioRepository.Atualizar(id, tipoAtualizado);
                return NoContent();
            }

            return NotFound();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuario tipoBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoBuscado != null)
            {
                _tipoUsuarioRepository.Deletar(id);

                return Ok($"O Tipo de Usuário {id} foi deletado com sucesso");
            }

            return NotFound("Tipo de Usuário não encontrado");
        }
    }
}