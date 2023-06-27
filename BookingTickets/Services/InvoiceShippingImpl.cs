using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Services;

public class InvoiceShippingImpl : IinvoiceShippingService
{
    private readonly DatabaseContext _databaseContext;

    public InvoiceShippingImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(InvoiceShipping inoivce)
    {
        try
        {
            _databaseContext.InvoiceShippings.Add(inoivce);
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
            _databaseContext.InvoiceShippings.Remove(_databaseContext.InvoiceShippings.FirstOrDefault(acc => acc.Id == id)!);
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public dynamic GetById(int id)
    {
        try
        {
            return _databaseContext.InvoiceShippings.AsNoTracking().Where(acc => acc.Id == id)!.Select(acc => new
            {
                Id = acc.Id,
                RecipientName = acc.RecipientName,
                RecipientPhone = acc.RecipientPhone,
                RecipientAddress = acc.RecipientAddress,
                DeliveryName = acc.DeliveryName,
                DeliveryPhone = acc.DeliveryPhone,
                DeliveryAddress = acc.DeliveryAddress,
                IdAccount = acc.IdAccount,
                IdShipping = acc.IdShipping,
                CreateAt = acc.CreateAt,
                UpdateAt = acc.UpdateAt
            }).FirstOrDefault()!;
        }
        catch
        {
            return null!;
        }
    }

    public dynamic GetAllInvoice()
    {
        return _databaseContext.InvoiceShippings.Select(acc => new
        {
            Id = acc.Id,
            RecipientName = acc.RecipientName,
            RecipientPhone = acc.RecipientPhone,
            RecipientAddress = acc.RecipientAddress,
            DeliveryName = acc.DeliveryName,
            DeliveryPhone = acc.DeliveryPhone,
            DeliveryAddress = acc.DeliveryAddress,
            IdAccount = acc.IdAccount,
            IdShipping = acc.IdShipping,
            CreateAt = acc.CreateAt,
            UpdateAt = acc.UpdateAt
        }).ToList();
    }

    public bool Update(InvoiceShipping invoice)
    {
        try
        {
            _databaseContext.InvoiceShippings.Entry(invoice).State = EntityState.Modified;
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
