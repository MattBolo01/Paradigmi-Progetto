using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Repository.Abstraction
{
    /// <summary>
    /// Interfaccia per la generalizazione delle repository
    /// </summary>
    public interface IRepository<T> where T : class
    {
        void Aggiungi(T entity);
        void Modifica<T>(T entity);
        T Get(object id);
        void Elimina(object id);
        void SaveChanges();
    }
}
