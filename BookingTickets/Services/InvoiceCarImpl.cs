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

    public dynamic Complete(int idAccount)
    {
        try
        {
            //return _databaseContext.InvoiceCars.Where(i => i.IdAccount == idAccount && i.Sta == "Completed").Select(i => new
            //{
            //    Id = i.Id,
            //    Date = i.Date,
            //    Note = i.Note,
            //    Total = i.Total,
            //    IdAccount = i.IdAccount,
            //    Status = i.Status,
            //    CreateAt = i.CreateAt,
            //    UpdateAt = i.UpdateAt,
            //    FullName = i.IdAccountNavigation.FullName
            //}).OrderByDescending(i=>i.Id).ToList()!;
            return 123;
        }
        catch
        {
            return null!;
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

    public dynamic GetByIdAccount(int idAccount)
    {
        try
        {
            return _databaseContext.InvoiceCars.Where(i => i.IdAccount == idAccount).Select(i => new
            {
                Id = i.Id,
                Date = i.Date,
                Note = i.Note,
                Total = i.Total,
                IdAccount = i.IdAccount,
                CreateAt = i.CreateAt,
                UpdateAt = i.UpdateAt,
                FullName = i.IdAccountNavigation.FullName
            }).ToList()!;
        }
        catch
        {
            return null!;
        }
    }

    public dynamic InProgess(int idAccount)
    {
        try
        {
            //return _databaseContext.InvoiceCars.Where(i => i.IdAccount == idAccount).Select(i => new
            //{
            //    Id = i.Id,
            //    Date = i.Date,
            //    Note = i.Note,
            //    Total = i.Total,
            //    IdAccount = i.IdAccount,
            //    CreateAt = i.CreateAt,
            //    UpdateAt = i.UpdateAt,
            //    FullName = i.IdAccountNavigation.FullName,
            //    WorkDay = _databaseContext.WorkSchedules.Where(i => i.IdAccount == idAccount && i.IdCar == 1).Select(i => new
            //    {
            //        Id = i.Id,
            //        Line = i.IdTimeLineNavigation.Line
            //    }).FirstOrDefault()!
            //}).ToList()!;
            return 1;
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
