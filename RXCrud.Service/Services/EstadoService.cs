using AutoMapper;
using AutoMapper.QueryableExtensions;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace RXCrud.Service.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _EstadoRepository;

        public EstadoService(IMapper mapper, IEstadoRepository EstadoRepository)
        {
            _mapper = mapper;
            _EstadoRepository = EstadoRepository;
        }

        public void Criar(EstadoDto EstadoDto)
            => _EstadoRepository.Criar(_mapper.Map<Estado>(EstadoDto));

        public void Atualizar(EstadoDto EstadoDto)
            => _EstadoRepository.Atualizar(_mapper.Map<Estado>(EstadoDto));

        public void Remover(EstadoDto EstadoDto)
            => _EstadoRepository.Remover(_mapper.Map<Estado>(EstadoDto));

        public IQueryable<EstadoDto> ObterTodos()
            => _EstadoRepository.ObterTodos().ProjectTo<EstadoDto>(_mapper.ConfigurationProvider);

        public EstadoDto PesquisarPorId(Guid id)
            => _mapper.Map<EstadoDto>(_EstadoRepository.PesquisarPorId(id));
    }
}