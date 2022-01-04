using AutoMapper;
using FilmesLista.Data;
using FilmesLista.Models;
using FilmesLista.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesLista.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _service;

        public CinemaController(CinemaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult RecuperaCinema([FromQuery] string? nomeFilme = null)
        {
            List<ReadCinemaDto> readDto = _service.RecuperaCinema(nomeFilme);
            if (readDto == null) return NotFound(); 
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaId(int id)
        {
            ReadCinemaDto readDto = _service.RecuperaCinemaID(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPost]
        public IActionResult addCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _service.AddCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemaId), new { Id = readDto.Id }, readDto);
                
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaNovoDto)
        {
            Result resultado = _service.AtualizaCinema(id, cinemaNovoDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _service.DeletaCinema(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
