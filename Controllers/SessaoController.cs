using AutoMapper;
using FilmesLista.Data;
using FilmesLista.Data.Dtos;
using FilmesLista.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesLista.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
            
        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoID), new { Id = sessao.Id }, sessao);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoID(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(sessaoDto);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaSessao([FromQuery] int? cineID = null)
        {
            List<Sessao> sessoes;
            if (cineID == null)
            {
                sessoes = _context.Sessoes.ToList();
            }
            else
            {
                sessoes = _context.Sessoes.Where(sessoes => sessoes.CinemaId == cineID).ToList();
            }
            if (sessoes != null)
            {
                List<ReadSessaoDto> sessoesDto = _mapper.Map<List<ReadSessaoDto>>(sessoes).ToList();
                return Ok(sessoesDto);
            }
            return NotFound();
        }
    }
}
