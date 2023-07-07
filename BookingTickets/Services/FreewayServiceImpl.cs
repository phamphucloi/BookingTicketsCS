using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Services;

public class FreewayServiceImpl : IFreewayService
{
    private readonly DatabaseContext _databaseContext;

    public FreewayServiceImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(Freeway freeway)
    {
        try
        {
            _databaseContext.Freeways.Add(freeway);
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
            _databaseContext.Freeways.Remove(_databaseContext.Freeways.FirstOrDefault(acc => acc.Id == id)!);
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
            return _databaseContext.Freeways.AsNoTracking().Select(acc => new
            {
                Id = acc.Id,
                From = acc.IdFromNavigation.Name,
                To = acc.IdToNavigation.Name,
                CreateAt = acc.CreateAt,
                UpdateAt = acc.UpdateAt
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
            return _databaseContext.Freeways.AsNoTracking().Where(acc => acc.Id == id)!.Select(acc => new
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

    public bool Update(Freeway freeway)
    {
        try
        {
            _databaseContext.Freeways.Entry(freeway).State = EntityState.Modified;
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
