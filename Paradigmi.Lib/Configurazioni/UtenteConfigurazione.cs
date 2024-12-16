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
    /// Classe per la configurazione della classe utente
    /// </summary>
    public class UtenteConfigurazione : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utenti");
            builder.HasKey(k => k.IdUtente);
            builder.Property(p => p.Nome)
                .HasMaxLength(50);
            builder.Property(p => p.Cognome)
                .HasMaxLength(50);
            builder.Property(p => p.Email)
                .HasMaxLength(50);
            builder.Property(p => p.Password)
                .HasMaxLength(50);
        }
    }
}
