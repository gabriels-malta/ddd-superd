using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SD.Domain.Entities;

namespace SD.Persistence.Configurations
{
    public class LancamentoConfiguration : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ContaId)
                .IsRequired();

            builder.Property(x => x.Valor)
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasColumnType("smallint")
                .IsRequired();
        }
    }
}
