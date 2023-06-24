using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Services;

public class ChairServiceImpl : IChairService
{
    private readonly DatabaseContext _databaseContext;

    public ChairServiceImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(Chair chair)
    {
        try
        {
            _databaseContext.Chairs.Add(chair);
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
            _databaseContext.Chairs.Remove(_databaseContext.Chairs.FirstOrDefault(c=>c.Id==id)!);
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
            return _databaseContext.Chairs.AsNoTracking().Where(c => c.Id == id).Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
                CreateAt = c.CreateAt,
                UpdateAt = c.UpdateAt
            }).FirstOrDefault()!;
        }
        catch
        {
            return null!;
        }
    }

    public bool Update(Chair chair)
    {
        try
        {
            _databaseContext.Chairs.Entry(chair).State = EntityState.Modified;
            return _databaseContext.SaveChanges() > 0;
        }
        catch { return false; }
    }
}
