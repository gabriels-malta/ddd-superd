using Microsoft.EntityFrameworkCore;
using SD.Domain.Entities;
using SD.Persistence.Configurations;

namespace SD.Persistence.Context
{
    public class SDContext : DbContext
    {
        public SDContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaCorrenteConfiguration());
            modelBuilder.ApplyConfiguration(new LancamentoConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(SDContext).Assembly);
        }
    }
}
