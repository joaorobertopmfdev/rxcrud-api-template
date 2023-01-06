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
    public class CidadeService : ICidadeService
    {
        private readonly IMapper _mapper;
        private readonly ICidadeRepository _CidadeRepository;

        public CidadeService(IMapper mapper, ICidadeRepository CidadeRepository)
        {
            _mapper = mapper;
            _CidadeRepository = CidadeRepository;
        }

        public void Criar(CidadeDto CidadeDto)
            => _CidadeRepository.Criar(_mapper.Map<Cidade>(CidadeDto));

        public void Atualizar(CidadeDto CidadeDto)
            => _CidadeRepository.Atualizar(_mapper.Map<Cidade>(CidadeDto));

        public void Remover(CidadeDto CidadeDto)
            => _CidadeRepository.Remover(_mapper.Map<Cidade>(CidadeDto));

        public IQueryable<CidadeDto> ObterTodos()
            => _CidadeRepository.ObterTodos().ProjectTo<CidadeDto>(_mapper.ConfigurationProvider);

        public CidadeDto PesquisarPorId(Guid id)
            => _mapper.Map<CidadeDto>(_CidadeRepository.PesquisarPorId(id));
    }
}