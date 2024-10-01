namespace WebApplication1.cs
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
