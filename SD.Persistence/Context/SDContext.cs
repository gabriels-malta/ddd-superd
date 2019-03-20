using Microsoft.EntityFrameworkCore;
using SD.Domain.Entities;

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SDContext).Assembly);
        }
    }
}
