using Microsoft.EntityFrameworkCore;
using Paradigmi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Contesto
{
    /// <summary>
    /// Classe che rappresenta la connessione con il db
    /// </summary>
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Libro> Libri { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        /// <summary>
        /// Estrai tutti i model e esegue la configurazione
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
