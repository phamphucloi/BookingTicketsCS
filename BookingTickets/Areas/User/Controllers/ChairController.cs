using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Areas.User.Controllers;
[Area("user")]
[Route("user/api/chair")]
public class ChairController : Controller
{
    private readonly IChairService _IChairService;

    public ChairController(IChairService iChairService)
    {
        _IChairService = iChairService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("getAll")]
    [Produces("application/json")]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_IChairService.GetAll());
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("creation")]
    [Consumes("application/json")]
    public IActionResult Creation([FromBody] Chair chair)
    {
        try
        {
            return Ok(_IChairService.Add(chair));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut("update")]
    [Consumes("application/json")]
    public IActionResult Update([FromBody] Chair chair)
    {
        try
        {
            return Ok(_IChairService.Update(chair));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete/{id}")]
    [Consumes("application/json")]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(_IChairService.Delete(id));
        }
        catch
        {
            return BadRequest();
        }
    }



}
