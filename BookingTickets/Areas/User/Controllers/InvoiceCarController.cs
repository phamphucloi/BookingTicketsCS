using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Areas.User.Controllers;
[Area("user")]
[Route("user/api/invoiceCar")]
public class InvoiceCarController : Controller
{

    private readonly IInvoiceCarService _invoiceCarService;

    public InvoiceCarController(IInvoiceCarService invoiceCarService)
    {
        _invoiceCarService = invoiceCarService;
    }

    [HttpGet("index")]
    [Produces("application/json")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("create")]
    [Consumes("application/json")]
    public IActionResult Create([FromBody] InvoiceCar invoiceCar)
    {
        try
        {
            return Ok(_invoiceCarService.Add(invoiceCar));
        }
        catch
        {
            return BadRequest();
        }
    }

}
