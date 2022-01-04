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
    public class SessaoController : ControllerBase
    {
        private SessaoService _service;
        public SessaoController(SessaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = _service.AddSessao(sessaoDto);
            return CreatedAtAction(nameof(RecuperaSessaoID), new { Id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Result resultado = _service.AtualizaSessao(id, sessaoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoID(int id)
        {
            ReadSessaoDto readDto = _service.RecuperaSessaoID(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaSessao([FromQuery] int? cineID = null)
        {
            List<ReadSessaoDto> readDto = _service.RecuperaSessao(cineID);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
    }
}
