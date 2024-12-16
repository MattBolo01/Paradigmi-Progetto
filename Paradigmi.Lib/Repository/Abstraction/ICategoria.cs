using Paradigmi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Repository.Abstraction
{
/// <summary>
/// Interfaccia per la repository Categoria
/// </summary>
    public interface ICategoria : IRepository<Categoria>
    {
        IEnumerable<Libro> GetLibri(string Nome);
        Categoria Get(string Nome);
    }
}
