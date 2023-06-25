using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Services;

public class TimeServiceImpl : ITimeService
{
    private readonly DatabaseContext _databaseContext;

    public TimeServiceImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(Time time)
    {
        try
        {
            _databaseContext.Times.Add(time);
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
            _databaseContext.Times.Remove(_databaseContext.Times.FirstOrDefault(acc => acc.Id == id)!);
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
            return _databaseContext.Times.AsNoTracking().Where(acc => acc.Id == id)!.Select(acc => new
            {
                Id = acc.Id,

                CreateAt = acc.CreateAt,
                UpdateAt = acc.UpdateAt
            }).FirstOrDefault()!;
        }
        catch
        {
            return null!;
        }
    }

    public bool Update(Time time)
    {
        try
        {
            _databaseContext.Times.Entry(time).State = EntityState.Modified;
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
