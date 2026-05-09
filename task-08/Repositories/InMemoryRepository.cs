using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Interfaces;
using RepositoryPatternApp.Models;

namespace RepositoryPatternApp.Repositories
{
    // Generic implementation using the IEntity constraint so we know objects have an Id property
    public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T entity)
        {
            _items.Add(entity);
        }

        public T? Get(int id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        public void Update(T entity)
        {
            var existingItem = Get(entity.Id);
            if (existingItem != null)
            {
                var index = _items.IndexOf(existingItem);
                _items[index] = entity;
            }
        }

        public void Delete(int id)
        {
            var existingItem = Get(id);
            if (existingItem != null)
            {
                _items.Remove(existingItem);
            }
        }
    }
}
