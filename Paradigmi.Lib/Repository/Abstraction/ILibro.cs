using Paradigmi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Repository.Abstraction
{
    /// <summary>
    /// Interfaccia per la repository Libro
    /// </summary>
    public interface ILibro : IRepository<Libro>
    {
        IEnumerable<Categoria> GetCategorie(int Id);
        IEnumerable<Libro> GetLibri(string? nome, string? autore, string? editore, DateTime? dataPubblicazione, string? categoria, int pageNum, int pageSize, out int totalNum);
    }
}
