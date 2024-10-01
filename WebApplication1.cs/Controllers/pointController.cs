using Microsoft.AspNetCore.Mvc;
using WebApplication1;
using WebApplication1.Services;

[ApiController]
[Route("api/[controller]")]
public class PointController : ControllerBase
{
    private readonly IPointService _pointService;

    public PointController(IPointService pointService)
    {
        _pointService = pointService ?? throw new ArgumentNullException(nameof(pointService));
    }

    [HttpGet]
    public ActionResult<List<Point>> GetAll()
    {
        var response = _pointService.GetAll();

        if (response == null)
        {
            return BadRequest(response.Message);
        }

        return Ok(response.Data);
    }

    [HttpGet("{id}")]
    public ActionResult<Point> GetById(long id)
    {
        var point = _pointService.GetById(id);
        if (point == null)
        {
            return NotFound();
        }
        return point;
    }

    [HttpPost]
    public IActionResult InsertPoint(Point point)
    {
        if (string.IsNullOrEmpty(point.WKT))
        {
            return BadRequest(new { message = "WKT is required." });
        }

        var createdPoint = _pointService.Add(point);
        return Ok(new { message = "Point inserted successfully", point = createdPoint });
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Point point)
    {
        if (point == null)
        {
            return BadRequest(new { message = "Point data is required" });
        }

        if (id != point.id)
        {
            return BadRequest(new { message = "ID in URL and Point data must match" });
        }

        if (string.IsNullOrEmpty(point.WKT))
        {
            return BadRequest(new { message = "WKT is required." });
        }

        var result = _pointService.Update(id, point);
        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }
        return Ok(new { message = result.Message });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var result = _pointService.Delete(id);
        if (!result.Success)
        {
            return NotFound(new { message = result.Message });
        }
        return Ok(new { message = result.Message });
    }
}