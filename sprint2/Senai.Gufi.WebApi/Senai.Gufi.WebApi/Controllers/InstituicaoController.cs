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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_instituicaoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _instituicaoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Instituicao novaInstituicao)
        {
            if (novaInstituicao == null)
            {
                return BadRequest("Não foi possíve criar a Instituição");
            }

            _instituicaoRepository.Cadastrar(novaInstituicao);
            return StatusCode(201);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Instituicao iAtualizada)
        {
            if (iAtualizada != null)
            {
                try
                {
                    _instituicaoRepository.Atualizar(id, iAtualizada);

                    return NoContent();
                }
                catch (Exception)
                {
                    return BadRequest("Não foi possível atualizar a instituição");
                }
            }

            return NotFound("A Instituição não foi atualizada pois o identificador não foi encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Instituicao iBuscada = _instituicaoRepository.BuscarPorId(id);

            if (iBuscada != null)
            {
                _instituicaoRepository.Deletar(id);
                return Ok("Instituição deletada com sucesso!");
            }

            return NotFound("A Instituição não foi encontrada, verifique o identificador na URL.");

        }
        
        

        }
    }