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

    public bool Delete(string LicensePlates)
    {
        try
        {
            _databaseContext.Cars.Remove(_databaseContext.Cars.FirstOrDefault(car=>car.LicensePlates== LicensePlates)!);
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public dynamic GetByLicensePlates(string LicensePlates)
    {
        try
        {
            return _databaseContext.Cars.AsNoTracking().Where(c => c.LicensePlates==LicensePlates).Select(car=>new
            {
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

    public dynamic GetAllCar()
    {
        try
        {
            return _databaseContext.Cars.Where(i=>i.IdCategory != 1).Select(car => new
            {
                LicensePlates = car.LicensePlates,
                RegistrationDate = car.RegistrationDate,
                IdCategory = car.IdCategory,
                CreateAt = car.CreateAt,
                UpdateAt = car.UpdateAt,
                Name = car.NameCar
            }).ToList();
        }
        catch
        {
            return null!;
        }
    }
}
