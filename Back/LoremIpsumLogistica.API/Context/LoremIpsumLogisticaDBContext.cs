using LoremIpsumLogistica.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LoremIpsumLogistica.API.Context
{
    public class LoremIpsumLogisticaDBContext : DbContext
    {
        public LoremIpsumLogisticaDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cadastro>()
            .HasMany(c => c.Enderecos)
            .WithOne(e => e.Cadastro)
            .HasForeignKey(e => e.CadastroId)
            .OnDelete(DeleteBehavior.Cascade); // Exclui os Endereços ao excluir um Cadastro

            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Cadastro>()
                .HasKey(c => c.Id);
        }
    }
}