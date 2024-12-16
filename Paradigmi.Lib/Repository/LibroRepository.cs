using Microsoft.EntityFrameworkCore;
using Paradigmi.Lib.Contesto;
using Paradigmi.Lib.Models;
using Paradigmi.Lib.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Repository
{
    /// <summary>
    /// Repository per la casse Libro
    /// </summary>
    public class LibroRepository : GenericRepository<Libro>, ILibro
    {
        public LibroRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Restituisce la lista di categorie che appartengono a quel libro
        /// </summary>
        /// <param name="id">Id del libro</param>
        /// <returns>La lista di categorie</returns>
        public IEnumerable<Categoria> GetCategorie(int Id)
        {
            return _ctx.Libri
                .Where(w => w.IdLibro == Id).SelectMany(c => c.Categorie).ToList();
        }

        /// <summary>
        /// Restituisce la collezione dei libri che rispettano i criteri passati
        /// </summary>
        /// <returns>Lista dei libri</returns>
        public IEnumerable<Libro> GetLibri(string? nome, string? autore, string? editore, DateTime? dataPubblicazione, string? categoria, int pageNum, int pageSize, out int totalNum)
        {
            var query = _ctx.Set<Libro>().Include(c => c.Categorie).AsQueryable();
            if (!string.IsNullOrEmpty(nome))
                query = query.Where(x => x.Nome.ToLower().Trim().Contains(nome.ToLower().Trim()));
            if (!string.IsNullOrEmpty(autore))
                query = query.Where(x => x.Autore.ToLower().Trim().Contains(autore.ToLower().Trim()));
            if (dataPubblicazione != null)
                query = query.Where(x => x.DataPubblicazione.Date.Equals(dataPubblicazione.Value.Date));
            if (!string.IsNullOrEmpty(editore))
                query = query.Where(x => x.Editore.ToLower().Trim().Contains(editore.ToLower().Trim()));
            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(x => x.Categorie.Any(c => c.Nome.ToLower().Trim().Equals(categoria.ToLower().Trim())));
            totalNum = query.Count();
            return query.Skip(pageNum * pageSize).Take(pageSize).ToList();
        }
    }
}
