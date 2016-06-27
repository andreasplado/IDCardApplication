using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEFRepository<T> : IDisposable
            where T : class
    {
        // Get all records in table.
        // Saa kõik anmed tabelist.
        List<T> All { get; }

        // Get all records with filter.
        //Saa kõik kirjed filtriga.
        List<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        T GetById(params object[] id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(params object[] id);

        void SaveChanges();
    }
}
