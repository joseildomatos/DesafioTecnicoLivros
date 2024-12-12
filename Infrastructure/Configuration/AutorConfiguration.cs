using Desafio.Spassu.TJRJ.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Desafio.Spassu.TJRJ.Infrastructure.Configuration
{
    public class AutorConfiguration : EntityTypeConfiguration<Autor>
    {
        public AutorConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }    
}
