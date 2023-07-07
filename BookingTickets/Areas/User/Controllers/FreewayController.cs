using BookingTickets.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Areas.User.Controllers;
[Area("user")]
[Route("user/api/freeway")]
public class FreewayController : Controller
{

    private readonly IFreewayService _freewayService;

    public FreewayController(IFreewayService freewayService)
    {
        _freewayService = freewayService;
    }

    [HttpGet("getAll")]
    [Produces("application/json")]
    public IActionResult Index()
    {
        try
        {
            return Ok(_freewayService.GetAll());
        }
        catch
        {
            return BadRequest();
        }
    }
}
