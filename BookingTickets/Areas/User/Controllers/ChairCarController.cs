using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Areas.User.Controllers;
[Area("user")]
[Route("user/api/chairCar")]
public class ChairCarController : Controller
{
    private readonly IChairCarService _IChairCarService;

    public ChairCarController(IChairCarService iChairCarService)
    {
        _IChairCarService = iChairCarService;
    }

    [HttpGet("index")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public IActionResult Index()
    {
        try
        {
            return Ok(_IChairCarService.GetAll());
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("getById/{id}")]
    [Produces("application/json")]
    public IActionResult GetById(int id)
    {
        try
        {
            return Ok(_IChairCarService.GetById(id));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("create")]
    [Produces("application/json")]
    public IActionResult Create([FromBody] ChairCar chairCar)
    {
        try
        {
            return Ok(_IChairCarService.Create(chairCar));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut("update")]
    [Produces("application/json")]
    public IActionResult Update([FromBody] ChairCar chairCar)
    {
        try
        {
            return Ok(_IChairCarService.Update(chairCar));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete/{id}")]
    [Produces("application/json")]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(_IChairCarService.Delete(id));
        }
        catch
        {
            return BadRequest();
        }
    }
}
