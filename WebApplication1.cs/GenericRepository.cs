using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApplication1.cs.Context;

namespace WebApplication1.cs
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }


        public IEnumerable<T> GetAll() 
        {
            return _dbSet.ToList();
        }

        public T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity) 
        { 
            _dbSet.Update(entity);
        }

        public void Delete(T entity) 
        {
            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
