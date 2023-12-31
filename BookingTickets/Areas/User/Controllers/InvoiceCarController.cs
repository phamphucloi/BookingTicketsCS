﻿using BookingTickets.Interfaces;
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
        try
        {
            return Ok(_invoiceCarService.GetAll());
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
            return Ok(_invoiceCarService.GetById(id));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("getByIdAccount/{idAccount}")]
    [Produces("application/json")]
    public IActionResult GetByIdAccount(int idAccount)
    {
        try
        {
            if (_invoiceCarService.GetByIdAccount(idAccount).Count == 0)
            {
                return Ok();
            }

            return Ok(_invoiceCarService.GetByIdAccount(idAccount));

        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("inprogess/{idAccount}")]
    [Produces("application/json")]
    public IActionResult InProgess(int idAccount)
    {
        try
        {
            //if (_invoiceCarService.InProgess(idAccount).Count == 0)
            //{
            //    return Ok();
            //}

            return Ok(_invoiceCarService.InProgess(idAccount));

        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("completed/{idAccount}")]
    [Produces("application/json")]
    public IActionResult Completed(int idAccount)
    {
        try
        {
            if (_invoiceCarService.Complete(idAccount).Count == 0)
            {
                return Ok();
            }

            return Ok(_invoiceCarService.Complete(idAccount));

        }
        catch
        {
            return BadRequest();
        }
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

    [HttpPut("update")]
    [Consumes("application/json")]
    public IActionResult Update([FromBody] InvoiceCar invoiceCar)
    {
        try
        {
            return Ok(_invoiceCarService.Update(invoiceCar));
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
            return Ok(_invoiceCarService.Delete(id));
        }
        catch
        {
            return BadRequest();
        }
    }

}
