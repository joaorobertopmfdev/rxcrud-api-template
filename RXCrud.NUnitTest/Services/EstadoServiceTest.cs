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

namespace RxCrud.NUnitTest.Services
{
    public class EstadoServiceTest
    {
        private IMapper _mapper;
        private Estado _estado;
        private IEstadoService _estadoService;
        private Mock<IEstadoRepository> _mockEstadoRepository;

        public EstadoServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _estado = new Estado("Estado Teste");
            _mockEstadoRepository = new Mock<IEstadoRepository>();
            _estadoService = new EstadoService(_mapper, _mockEstadoRepository.Object);
        }

        [Test]
        public void CriarTest()
            => Assert.DoesNotThrow(() => _estadoService.Criar(new EstadoDto("Estado Teste Create")));

        [Test]
        public void AtualizarTest()
            => Assert.DoesNotThrow(() => _estadoService.Atualizar(new EstadoDto("Estado Teste Update")));

        [Test]
        public void RemoverTest()
            => Assert.DoesNotThrow(() => _estadoService.Remover(new EstadoDto("Estado Teste Remove")));

        [Test]
        public void ObterTodosTest()
        {
            IList<Estado> estadoList = new List<Estado>();
            estadoList.Add(_estado);

            _mockEstadoRepository.Setup(r => r.ObterTodos()).Returns(estadoList.AsQueryable());
            Assert.IsNotNull(_estadoService.ObterTodos());
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorId(_estado.Id)).Returns(_estado);
            Assert.IsNotNull(_estadoService.PesquisarPorId(_estado.Id));
        }
    }
}