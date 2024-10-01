using Microsoft.EntityFrameworkCore;
using WebApplication1.cs.Context;

namespace WebApplication1.cs
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRepository<Point> _points;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Point> Points => _points ??= new GenericRepository<Point>(_context);

        public async Task<int> CommitAsync() 
        {
            return await _context.SaveChangesAsync();
        }

        //Yapılmış olan ancak veritabanına kaydedilmemiş değişiklikleri iptal eder.
        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
