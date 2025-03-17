using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>()
            .ForMember(dto => dto.Filme, opt => opt.MapFrom(sessao => sessao.Filme.Titulo))
            .ForMember(dto => dto.Cinema, opt => opt.MapFrom(sessao => sessao.Cinema.Nome));
    }
}
