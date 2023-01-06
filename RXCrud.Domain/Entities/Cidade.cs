using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXCrud.Domain.Entities
{
    public class Cidade : Entity
    {
        public Cidade(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }
        public string Descricao { get; set; }
    }
}