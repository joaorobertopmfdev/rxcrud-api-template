﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Exception;
using RXCrud.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace RXCrud.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
            => _estadoService = estadoService;

        /// <summary>
        /// Consulta
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet]
        [EnableQuery()]
        [ProducesResponseType(typeof(IQueryable<EstadoDto>), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Get()
            => Ok(_estadoService.ObterTodos());

        /// <summary>
        /// Consulta por id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EstadoDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult PorId(Guid id)
        {
            EstadoDto Estado = _estadoService.PesquisarPorId(id);
            if (Estado == null)
            {
                return NotFound();
            }

            return Ok(Estado);
        }

        /// <summary>
        /// Criar
        /// </summary>
        /// <param name="Estado"></param>
        /// <response code="200">Criado com sucesso.</response>
        /// <response code="400">Não foi possível criar.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Post(EstadoDto Estado)
        {
            if (!ModelState.IsValid)
            {
                throw new RXCrudException("Os dados para criação são inválidos.");
            }

            _estadoService.Criar(Estado);
            return Ok();
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="Estado"></param>
        /// <response code="200">Atualizado com sucesso.</response>
        /// <response code="400">Não foi possível atualizar.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Put(EstadoDto Estado)
        {
            if (!ModelState.IsValid)
            {
                throw new RXCrudException("Os dados para atualização são inválidos.");
            }

            if ((Estado.Id.ToString().Equals("")) || (_estadoService.PesquisarPorId(Estado.Id) == null))
            {
                return NotFound();
            }

            _estadoService.Atualizar(Estado);
            return Ok();
        }

        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Exclusão realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a exclusão.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EstadoDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Delete(Guid id)
        {
            EstadoDto Estado = _estadoService.PesquisarPorId(id);
            if (Estado == null)
            {
                return NotFound();
            }

            _estadoService.Remover(Estado);
            return Ok();
        }
    }
}