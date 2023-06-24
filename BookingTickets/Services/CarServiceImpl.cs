using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Services;

public class CarServiceImpl : ICarService
{
    private readonly DatabaseContext _databaseContext;

    public CarServiceImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(Car car)
    {
        try
        {
            _databaseContext.Cars.Add(car);
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
            _databaseContext.Cars.Remove(_databaseContext.Cars.FirstOrDefault(car=>car.Id==id)!);
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
            return _databaseContext.Cars.AsNoTracking().Where(c => c.Id==id).Select(car=>new
            {
                Id = car.Id,
                LicensePlates = car.LicensePlates,
                RegistrationDate = car.RegistrationDate,
                IdCategory = car.IdCategory,
                CreateAt = car.CreateAt,
                UpdateAt = car.UpdateAt
            }).FirstOrDefault()!;
        }
        catch
        {
            return null!;
        }
    }

    public bool Update(Car bus)
    {
        try
        {
            _databaseContext.Cars.Entry(bus).State = EntityState.Modified;
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
