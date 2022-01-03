using AutoMapper;
using FilmesLista.Data.Dtos;
using FilmesLista.Models;

namespace FilmesLista.Profiles
{

    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
