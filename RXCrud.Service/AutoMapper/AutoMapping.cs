using AutoMapper;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;

namespace RXCrud.Service.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Cidade, CidadeDto>()
                .ReverseMap();

            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();

            CreateMap<Estado, EstadoDto>()
                .ReverseMap();
        }
    }
}