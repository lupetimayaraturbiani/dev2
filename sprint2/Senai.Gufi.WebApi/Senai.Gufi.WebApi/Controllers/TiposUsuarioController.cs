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
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _tipoUsuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            if (novoTipoUsuario != null)
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
                return StatusCode(201);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            if (tipoUsuarioAtualizado != null)
            {
                try
                {
                    _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                    return NoContent();
                }
                catch (Exception)
                {
                    return BadRequest("Não foi possível atualizar o tipo de usuario.");
                }
            }

            return NotFound("Tipo Usuario não encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
            {
                _tipoUsuarioRepository.Deletar(id);

                return Ok("Tipo Usuario deletado com sucesso!");
            }

            return NotFound("Tipo Usuario não encontrado");
        }
    }
}