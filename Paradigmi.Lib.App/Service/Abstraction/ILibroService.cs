using Paradigmi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Service
{
    public interface ILibroService
    {
        bool AggiungiLibro(string nome, string autore, string editore, DateTime dataPubblicazione, HashSet<Categoria> categorie);
        bool EliminaLibro(int id);
        public bool ModificaLibro(int id, string nome, string autore, string editore, DateTime data, HashSet<Categoria> categorie);
        IEnumerable<Libro> GetLibri(string? nome, string? autore, string? editore, DateTime? data, string? categoria, int pageNum, int pageSize, out int totalNum);
    }
}
