using System.Collections.Generic;

namespace RepositoryPatternApp.Interfaces
{
    // Generic interface 
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T? Get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(int id);
    }
}
