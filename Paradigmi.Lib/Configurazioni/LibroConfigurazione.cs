using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Models.Configurazioni
{
    /// <summary>
    /// Classe per la configurazione della classe Libro
    /// </summary>
    public class LibroConfigurazione : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libri");
            builder.HasKey(p => p.IdLibro);
            builder.HasMany(p => p.Categorie).WithMany(p => p.Libri)
                .UsingEntity(
                "LibriCategorie",
                l => l.HasOne(typeof(Categoria)).WithMany().HasForeignKey("NomeCategoria").HasPrincipalKey(nameof(Categoria.Nome)),
                r => r.HasOne(typeof(Libro)).WithMany().HasForeignKey("IdLibro").HasPrincipalKey(nameof(Libro.IdLibro)),
                j => j.HasKey("IdLibro", "NomeCategoria"));
            builder.Property(p => p.Nome)
                .HasMaxLength(50);
            builder.Property(p => p.Autore)
                .HasMaxLength(50);
            builder.Property(p => p.Editore)
            .HasMaxLength(50);

        }
    }
}
