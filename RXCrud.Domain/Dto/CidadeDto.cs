using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RXCrud.Domain.Dto
{
    [DisplayName("Cidade")]
    public class CidadeDto
    {
        public CidadeDto()
            => Id = Guid.NewGuid();

        public CidadeDto(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo 'Descrição' obrigatório.")]
        public string Descricao { get; set; }

    }
}