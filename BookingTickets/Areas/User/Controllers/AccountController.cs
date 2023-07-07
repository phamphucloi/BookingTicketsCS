using BookingTickets.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Areas.User.Controllers;
[Area("user")]
[Route("user/api/account")]
public class AccountController : Controller
{

    private readonly IAccountServive _IAccountService;

    public AccountController(IAccountServive iAccountService)
    {
        _IAccountService = iAccountService;
    }

    [HttpGet("getAll")]
    [Produces("application/json")]
    public IActionResult Index()
    {
        try
        {
            return Ok(_IAccountService.GetAll());
        }
        catch
        {
            return BadRequest();
        }
    }
}
