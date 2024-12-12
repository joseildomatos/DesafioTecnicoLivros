using Desafio.Spassu.TJRJ.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Spassu.TJRJ.Infrastructure.Context;

public class AppDbContext : DbContext
{ 

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<LivroAssunto> LivroAssunto { get; set; }
    public DbSet<LivroAutor> LivroAutor { get; set; }

    public DbSet<Livro> Livro { get; set; } = null!;
    public DbSet<Assunto> Assunto { get; set; }
    public DbSet<Autor> Autor { get; set; }
    public DbSet<RelatorioLivros> RelatorioLivros  { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var stringConection = "Server=DESKTOP-FVM3OH2;Initial Catalog=DesafioTecnicoSpassuTJRJ;Integrated Security=SSPI;Encrypt=false;Persist Security Info=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(stringConection);
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<RelatorioLivros>()
            .ToView("VW_RELATORIO_LIVROS")
            .HasKey(t => t.AutorId);
    }

}

 
