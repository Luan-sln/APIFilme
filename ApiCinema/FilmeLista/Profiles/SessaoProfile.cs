using AutoMapper;
using FilmesLista.Data.Dtos;
using FilmesLista.Models;

namespace FilmesLista.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
                //.ForMember(dto => dto.HorarioDeInicio, opts => opts
                //.MapFrom(dto =>
                //dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao*(-1))));
            CreateMap<UpdateSessaoDto, Sessao>();
        }
    }
}
