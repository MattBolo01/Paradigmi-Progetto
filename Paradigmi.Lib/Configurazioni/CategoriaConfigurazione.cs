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
    /// Classe per la configurazione della classe Categoria
    /// </summary>
    public class CategoriaConfigurazione : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorie");
            builder.HasKey(k => k.Nome);
            builder.Property(p => p.Nome)
                .HasMaxLength(50);
        }
    }
}
