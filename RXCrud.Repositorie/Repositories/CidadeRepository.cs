using RXCrud.Data.Common;
using RXCrud.Data.Context;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Data;

namespace RXCrud.Data.Repositories
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(RXCrudContext context) : base(context)
        {
        }
    }
}