using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Models
{
    /// <summary>
    /// Classe che rappresenta l'oggetto Categoria
    /// </summary>
    public class Categoria
    {
        public string Nome { get; set; } = string.Empty;
        public ICollection<Libro> Libri { get; set; } = new List<Libro>();
    }
}
