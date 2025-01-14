﻿using RXCrud.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RXCrud.Domain.Dto
{
    [DisplayName("Estado")]
    public class EstadoDto
    {
        public EstadoDto()
            => Id = Guid.NewGuid();

        public EstadoDto(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo 'Descrição' obrigatório.")]
        public string Descricao { get; set; }
    }
}