using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Services;

public class InvoiceCarImpl : IInvoiceCarService
{
    private readonly DatabaseContext _databaseContext;

    public InvoiceCarImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(InvoiceCar invoiceCar)
    {
        try
        {
            _databaseContext.InvoiceCars.Add(invoiceCar);
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            _databaseContext.InvoiceCars.Remove(_databaseContext.InvoiceCars.FirstOrDefault(a=>a.Id == id)!);
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public dynamic GetAll()
    {
        try
        {
            return _databaseContext.InvoiceCars.Select(a => new
            {
                Id = a.Id,
                Date = a.Date,
                Note = a.Note,
                Total = a.Total,
                IdAccount = a.IdAccount,
                CreateAt = a.CreateAt,
                UpdateAt = a.UpdateAt,
            }).ToList()!;
        }
        catch
        {
            return null!;
        }
    }

    public dynamic GetById(int id)
    {
        try
        {
            return _databaseContext.InvoiceCars.AsNoTracking().Where(a=>a.Id == id).Select(a => new
            {
                Id = a.Id,
                Date = a.Date,
                Note = a.Note,
                Total = a.Total,
                IdAccount = a.IdAccount,
                CreateAt = a.CreateAt,
                UpdateAt = a.UpdateAt,
            }).FirstOrDefault()!;
        }
        catch
        {
            return null!;
        }
    }

    public bool Update(InvoiceCar invoiceCar)
    {
        try
        {
            _databaseContext.InvoiceCars.Entry(invoiceCar).State = EntityState.Modified;
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
