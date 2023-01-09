using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RXCrud.Domain.Entities;

namespace RXCrud.Data.Configuration
{
    public class CidadeConfig : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao).IsRequired();
            builder.Property(c => c.IdEstado).IsRequired();
            builder.HasOne(c => c.Estado).WithOne(e => e.Cidade).HasForeignKey<Cidade>(c => c.IdEstado).OnDelete(DeleteBehavior.Restrict);
        }
    }
}