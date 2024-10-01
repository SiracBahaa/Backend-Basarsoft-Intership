using WebApplication1;
using WebApplication1.cs.Context;
using WebApplication1.cs;
using WebApplication1.Services;

public class PointService : IPointService
{
    private readonly IUnitOfWork _unitOfWork;

    public PointService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Response<List<Point>> GetAll()
    {
        var points = _unitOfWork.Points.GetAll().ToList();

        if (points == null || points.Count == 0)
        {
            return new Response<List<Point>>("No points found.", false, null);
        }

        return new Response<List<Point>>("Points retrieved successfully.", true, points);
    }

    public Point GetById(long id)
    {
        return _unitOfWork.Points.GetById(id);
    }

    public Point Add(Point point)
    {
        _unitOfWork.Points.Add(point);
        _unitOfWork.CommitAsync().Wait();
        return point;
    }

    public Response<bool> Update(long id, Point updatedPoint)
    {
        var point = _unitOfWork.Points.GetById(id);
        if (point == null)
        {
            return new Response<bool>("Point not found with specified ID.", false, false);
        }

        point.WKT = updatedPoint.WKT;
        point.Name = updatedPoint.Name;

        _unitOfWork.Points.Update(point);
        _unitOfWork.CommitAsync().Wait();

        return new Response<bool>("Point is updated", true, true);
    }

    public Response<bool> Delete(long id)
    {
        var point = _unitOfWork.Points.GetById(id);
        if (point == null)
        {
            return new Response<bool>("Point not found with specified ID.", false, false);
        }

        _unitOfWork.Points.Delete(point);
        _unitOfWork.CommitAsync().Wait();

        return new Response<bool>("Point is deleted with specified ID.", true, true);
    }
}