using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SD.Domain.Entities;

namespace SD.Persistence.Configurations
{
    public class ContaCorrenteConfiguration : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ClienteId)
                .IsRequired();

            builder.Property(x => x.Saldo)
                .HasColumnType("decimal")
                .IsRequired();
        }
    }
}
