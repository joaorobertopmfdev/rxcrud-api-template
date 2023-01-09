using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXCrud.Domain.Entities
{
    public class Cidade : Entity
    {
        public Cidade(string descricao, Guid idEstado)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            IdEstado = idEstado;
        }

        public string Descricao { get; set; }

        public Guid IdEstado { get; set; }

        public Estado Estado { get; set; }
    }
}