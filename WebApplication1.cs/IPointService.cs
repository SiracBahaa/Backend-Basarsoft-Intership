using WebApplication1.cs;

namespace WebApplication1.Services
{
    public interface IPointService
    {
        Response<List<Point>> GetAll();
        Point GetById(long id);
        Point Add(Point point);
        Response<bool> Update(long id, Point updatedPoint);
        Response<bool> Delete(long id);
    }
}
