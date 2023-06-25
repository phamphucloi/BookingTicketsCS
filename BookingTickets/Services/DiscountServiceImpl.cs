using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Services;

public class DiscountServiceImpl : IDiscountService
{
    private readonly DatabaseContext _databaseContext;

    public DiscountServiceImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(Discount dis)
    {
        try
        {
            _databaseContext.Discounts.Add(dis);
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
            _databaseContext.Discounts.Remove(_databaseContext.Discounts.FirstOrDefault(acc => acc.Id == id)!);
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
            return _databaseContext.Discounts.AsNoTracking().Where(acc => acc.Id == id)!.Select(acc => new
            {
                Id = acc.Id,

                Status = acc.Status,
                CreateAt = acc.CreateAt,
                UpdateAt = acc.UpdateAt
            }).FirstOrDefault()!;
        }
        catch
        {
            return null!;
        }
    }

    public bool Update(Discount dis)
    {
        try
        {
            _databaseContext.Discounts.Entry(dis).State = EntityState.Modified;
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
