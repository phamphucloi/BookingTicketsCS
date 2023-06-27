using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;
namespace BookingTickets.Services;

public class CategoryServiceImpl : ICategoryService
{

    private readonly DatabaseContext _databaseContext;

    public CategoryServiceImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(CategoryCar category)
    {
        try
        {
            _databaseContext.CategoryCars.Add(category);
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
            _databaseContext.CategoryCars.Remove(_databaseContext.CategoryCars.FirstOrDefault(cate=>cate.Id == id)!);
            return _databaseContext?.SaveChanges() > 0;
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
            return _databaseContext.CategoryCars.AsNoTracking().Where(cate => cate.Id == id)!.Select(cate => new
            {
                Id = cate.Id,
                Name = cate.Name,
                CreateAt = cate.CreateAt,
                UpdateAt = cate.UpdateAt
            }).FirstOrDefault()!;
        }
        catch
        {
            return null!;
        }
    }

    public bool Update(CategoryCar category)
    {
        try
        {
            _databaseContext.CategoryCars.Entry(category).State = EntityState.Modified; 
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
    public dynamic GetAllCategory()
    {
        return _databaseContext.CategoryCars.Select(cate => new
        {
            Id = cate.Id,
            Name = cate.Name,
            CreateAt = cate.CreateAt,
            UpdateAt = cate.UpdateAt
        }).ToList();
    }

}
