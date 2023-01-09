using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Services;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.NUnitTest.Common;
using RXCrud.Service.Services;
using RXCrud.Domain.Dto;
using System;

namespace RxCrud.NUnitTest.Services
{
    public class CidadeServiceTest
    {
        private IMapper _mapper;
        private Cidade _cidade;
        private ICidadeService _cidadeService;
        private Mock<ICidadeRepository> _mockCidadeRepository;

        public CidadeServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _cidade = new Cidade("Cidade Teste", Guid.NewGuid());
            _mockCidadeRepository = new Mock<ICidadeRepository>();
            _cidadeService = new CidadeService(_mapper, _mockCidadeRepository.Object);
        }

        [Test]
        public void CriarTest()
            => Assert.DoesNotThrow(() => _cidadeService.Criar(new CidadeDto("Cidade Teste Create", Guid.NewGuid())));

        [Test]
        public void AtualizarTest()
            => Assert.DoesNotThrow(() => _cidadeService.Atualizar(new CidadeDto("Cidade Teste Update", Guid.NewGuid())));

        [Test]
        public void RemoverTest()
            => Assert.DoesNotThrow(() => _cidadeService.Remover(new CidadeDto("Cidade Teste Remove", Guid.NewGuid())));

        [Test]
        public void ObterTodosTest()
        {
            IList<Cidade> cidadeList = new List<Cidade>();
            cidadeList.Add(_cidade);

            _mockCidadeRepository.Setup(r => r.ObterTodos()).Returns(cidadeList.AsQueryable());
            Assert.IsNotNull(_cidadeService.ObterTodos());
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            _mockCidadeRepository.Setup(r => r.PesquisarPorId(_cidade.Id)).Returns(_cidade);
            Assert.IsNotNull(_cidadeService.PesquisarPorId(_cidade.Id));
        }
    }
}