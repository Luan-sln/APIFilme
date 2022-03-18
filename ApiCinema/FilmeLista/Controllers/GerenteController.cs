using AutoMapper;
using FilmesLista.Data;
using FilmesLista.Data.Dtos;
using FilmesLista.Models;
using FilmesLista.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesLista.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _service;
        public GerenteController(GerenteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readDto = _service.AddGerente(gerenteDto);
            return CreatedAtAction(nameof(RecuperaGerenteId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerenteId(int id)
        {
            ReadGerenteDto readDto = _service.RecuperaGerenteId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<ReadGerenteDto> RecuperaGerente()
        {
            List<ReadGerenteDto> readDto = _service.RecuperaGerente();
            return readDto;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            Result resultado = _service.DeletaGerente(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
