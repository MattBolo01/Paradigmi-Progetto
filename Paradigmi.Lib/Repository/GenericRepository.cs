using Microsoft.EntityFrameworkCore;
using Paradigmi.Lib.Contesto;
using Paradigmi.Lib.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Repository
{
    /// <summary>
    /// Repository generale per le repository libro, utente e categoria
    /// </summary>
    /// <typeparam name="T">Libro, Utente , Categoria</typeparam>
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected MyDbContext _ctx;

        public GenericRepository(MyDbContext context)
        {
            _ctx = context;//Importo dal db
        }
        public void Aggiungi(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void Modifica<T>(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public T Get(object id)
        {
            return _ctx.Set<T>().Find(id);
        }
        public void Elimina(object id)
        {
            var entity = Get(id);
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();//salvatggio sul db
        }
    }
}
