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
    public class EnderecoController : ControllerBase
    {
        EnderecoService _service;
        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaEndereco()
        {
            List<ReadEnderecoDto> readDto = _service.RecuperaEndereco();
            return readDto;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoId(int id)
        {
            ReadEnderecoDto readDto = _service.RecuperaEnderecoId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPost]
        public IActionResult addEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _service.AddEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecoId), new { Id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoNovoDto)
        {
            Result resultado = _service.AtualizaEndereco(id, enderecoNovoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result resultado = _service.DeletaEndereco(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
