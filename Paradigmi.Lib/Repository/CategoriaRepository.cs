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
    /// Repository per la casse Categoria
    /// </summary>
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
    {
        public CategoriaRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Restituisce la lista di libri che appartengono ad una categoria specifica
        /// </summary>
        /// <param name="Nome">Nome della categoria</param>
        /// <returns>Lista di libri appartenenti dalla categoria</returns>
        public IEnumerable<Libro> GetLibri(string Nome)
        {
            return _ctx.Libri
                .Where(w => w.Categorie.Any(c => c.Nome.ToLower().Trim() == Nome.ToLower().Trim()))
                .ToList();
        }

        /// <summary>
        /// Overload della classe get generale per evitare nomi con capitalizzazione diverse
        /// </summary>
        /// <param name="nome">Nome della categoria</param>
        /// <returns>Nome della categoria</returns>
        public Categoria Get(string nome)
        {
            var categoria = _ctx.Categorie.FirstOrDefault(n => n.Nome.ToLower().Trim() == nome.ToLower().Trim());
            if (categoria != null)
                return _ctx.Categorie.Find(categoria.Nome);
            else
                return null;

        }
    }
}
