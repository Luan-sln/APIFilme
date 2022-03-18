using AutoMapper;
using FilmesLista.Data;
using FilmesLista.Data.Dtos;
using FilmesLista.Models;
using FluentResults;

namespace FilmesLista.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AddSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessaoID(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return sessaoDto;
            }
            return null;
        }

        public Result AtualizaSessao(int id, UpdateSessaoDto sessaoDto)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return Result.Fail("Sessão não encontrada");
            }
            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();
            return Result.Ok();
        }

        public List<ReadSessaoDto> RecuperaSessao(int? cineID)
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
                return sessoesDto;
            }
            return null;
        }
    }
}
