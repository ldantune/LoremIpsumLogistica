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

            modelBuilder.Entity<Cadastro>()
                .Property(e => e.Nome)
                .HasMaxLength(500)
                .IsRequired(true);
            
            modelBuilder.Entity<Cadastro>()
                .Property(e => e.DataNascimento)
                .HasMaxLength(20)
                .IsRequired(true);
            
            modelBuilder.Entity<Cadastro>()
                .Property(e => e.Sexo)
                .HasMaxLength(20)
                .IsRequired(true);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .HasMaxLength(10)
                .IsRequired(true);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Logradouro)
                .HasMaxLength(500)
                .IsRequired(true);
            
            modelBuilder.Entity<Endereco>()
                .Property(e => e.Numero)
                .HasMaxLength(250)
                .IsRequired(true);
            
            modelBuilder.Entity<Endereco>()
                .Property(e => e.Complemento)
                .HasMaxLength(500)
                .IsRequired(false);
            
            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro)
                .HasMaxLength(500)
                .IsRequired(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade)
                .HasMaxLength(500)
                .IsRequired(true);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.UF)
                .HasMaxLength(500)
                .IsRequired(true);
        }
    }
}