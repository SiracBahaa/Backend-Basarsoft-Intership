namespace WebApplication1.cs
{
    public interface IUnitOfWork
    {
        IGenericRepository<Point> Points { get; }
        Task<int> CommitAsync();
        void Rollback();
    }
}
