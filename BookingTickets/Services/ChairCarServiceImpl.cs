using BookingTickets.Interfaces;
using BookingTickets.Models;
using System.Globalization;

namespace BookingTickets.Services;

public class ChairCarServiceImpl : IChairCarService
{
    private readonly DatabaseContext _databaseContext;

    public ChairCarServiceImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Create(ChairCar chairCar)
    {
        try
        {
            _databaseContext.ChairCars.Add(chairCar);
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
            _databaseContext.ChairCars.Remove(_databaseContext.ChairCars.FirstOrDefault(a => a.Id == id)!);
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
            return _databaseContext.ChairCars.Select(c => new
            {
                Id = c.Id,
                Status = c.Status,
                Price = c.Price,
                IdChair = c.IdChair,
                IdAccount = c.IdAccount,
                IdCar = c.IdCar,
                CreateAt = c.CreateAt,
                UpdateAt = c.UpdateAt
            }).ToList()!;
        }
        catch
        {
            return null!;
        }
    }

    public dynamic GetByIdCharAndIdCarAndDateBook(int idChair, string idCar, string dateBook)
    {
        try
        {
            var date = DateTime.ParseExact(dateBook,"dd-MM-yyyy",CultureInfo.InvariantCulture);

            return _databaseContext.ChairCars.Where(c => c.IdChair == idChair && c.IdCar == idCar && c.DateBook == date).Select(c => new
            {
                Id = c.Id,
                Status = c.Status,
                Price = c.Price,
                IdChair = c.IdChair,
                IdAccount = c.IdAccount,
                IdCar = c.IdCar,
                IdTimeLine = c.IdTimeLine,
                DateBook = c.DateBook,
                CreateAt = c.CreateAt,
                UpdateAt = c.UpdateAt
            }).FirstOrDefault()!;
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
            return _databaseContext.ChairCars.Where(c => c.Id == id).Select(c => new
            {
                Id = c.Id,
                Status = c.Status,
                Price = c.Price,
                IdChair = c.IdChair,
                IdAccount = c.IdAccount,
                IdCar = c.IdCar,
                CreateAt = c.CreateAt,
                UpdateAt = c.UpdateAt
            }).FirstOrDefault()!;
        }
        catch
        {
            return null!;
        }
    }

    public dynamic GetByIdCar(string idCar)
    {
        try
        {
            return _databaseContext.ChairCars.Where(c => c.IdCar == idCar).Select(c => new
            {
                Id = c.Id,
                Status = c.Status,
                Price = c.Price,
                IdChair = c.IdChair,
                IdAccount = c.IdAccount,
                IdCar = c.IdCar,
                CreateAt = c.CreateAt,
                UpdateAt = c.UpdateAt
            }).ToList();
        }
        catch
        {
            return null!;
        }
    }

    public dynamic GetByIdCarAndIdTimeLineAndDateBook(string idCar, int idTimeLine, string dateBook)
    {
        try
        {
            var a = DateTime.ParseExact(dateBook, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            return _databaseContext.ChairCars.Where(c => c.IdCar == idCar && c.IdTimeLine == idTimeLine && a == c.DateBook).Select(c => new
            {
                Id = c.Id,
                Status = c.Status,
                Price = c.Price,
                IdChair = c.IdChair,
                IdAccount = c.IdAccount,
                IdCar = c.IdCar,
                DateBook = c.DateBook,
                CreateAt = c.CreateAt,
                UpdateAt = c.UpdateAt
            }).ToList();
        }
        catch
        {
            return null!;
        }
    }

    public bool Update(ChairCar chairCar)
    {
        try
        {
            _databaseContext.ChairCars.Entry(chairCar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public int? CountTheChairAvailable(string idCar, int idTimeLine, string dateBook)
    {
        try
        {
            var date = DateTime.ParseExact(dateBook, "dd-MM-yyyy",CultureInfo.InvariantCulture);

            return _databaseContext.ChairCars.Count(c=>c.IdCar == idCar && c.IdTimeLine == idTimeLine && c.DateBook == date && c.Status == true);
        }
        catch
        {
            return null;
        }
    }
}
