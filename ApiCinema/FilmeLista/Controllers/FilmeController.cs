using AutoMapper;
using FilmesLista.Data;
using FilmesLista.Data.Dtos;
using FilmesLista.Models;
using FilmesLista.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesLista.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _service;


        public FilmeController(FilmeService service)
        {
            _service = service;
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult addFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _service.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmeId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "regular, admin", Policy = "IdadeMinima")]
        public IActionResult RecuperaFilmes([FromQuery] int? classEtaria = null)
        {
            List<ReadFilmeDto> readDto = _service.RecuperaFilmes(classEtaria);
            if (readDto == null) return NotFound();
            return Ok(readDto);


        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmeId(int id)
        {
            ReadFilmeDto readDto = _service.RecuperaPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeNovoDto)
        {
            Result resultado = _service.AtualizaFilme(id, filmeNovoDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = _service.DeletaFilme(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
