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

    }
}