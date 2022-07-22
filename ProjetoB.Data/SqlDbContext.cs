using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoB.Domain.Model;

namespace ProjetoB.Data
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }

        public SqlDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().Property(p => p.Nome).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Status).IsRequired();
        }
    }
}

