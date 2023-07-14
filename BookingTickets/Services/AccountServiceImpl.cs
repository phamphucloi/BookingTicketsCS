using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Services;

public class AccountServiceImpl : IAccountServive
{
    private readonly DatabaseContext _databaseContext;

    public AccountServiceImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(Account acc)
    {
        try
        {
            acc.Password = BCrypt.Net.BCrypt.HashPassword(acc.Password);

            _databaseContext.Accounts.Add(acc);
            return _databaseContext.SaveChanges() > 0;
        }catch 
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            _databaseContext.Accounts.Remove(_databaseContext.Accounts.FirstOrDefault(acc=>acc.Id==id)!);
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
            return _databaseContext.Accounts.Where(i=>i.Level == 3).Select(a => new
            {
                Id = a.Id,
                FullName = a.FullName,
                Address = a.Address,
                Email = a.Email,
                Password = a.Password,
                Phone = a.Phone,
                Level = a.Level,
                Status = a.Status
            }).ToList();
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
            return _databaseContext.Accounts.AsNoTracking().Where(acc => acc.Id == id)!.Select(acc => new
            {
                Id = acc.Id,
                FullName = acc.FullName,
                PassWord = acc.Password,
                Address = acc.Address,
                Email = acc.Email,
                Phone = acc.Phone,
                Level = acc.Level,
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

    public dynamic GetByEmail(string email)
    {
        try
        {
            return _databaseContext.Accounts.Where(a => a.Email == email).Select(a => new
            {
                Id = a.Id,
                FullName = a.FullName,
                Address = a.Address,
                DoB = a.DoB,
                Email = a.Email,
                Phone = a.Phone,
                Level = a.Level,
                Status = a.Status,
                SecurityCode = a.SecurityCode,
            }).FirstOrDefault()!;
        }
        catch
        {
            return null!;
        }
    }

    public bool Login(string email, string password)
    {
        try
        {
            var username = _databaseContext.Accounts.FirstOrDefault(l => l.Email == email);

            if (username!=null && username.Status == true)
            {
                return BCrypt.Net.BCrypt.Verify(password, username.Password);
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(Account acc)
    {
        try
        {
            _databaseContext.Accounts.Entry(acc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public Account GetById2(int id)
    {
        try
        {
            return _databaseContext.Accounts.AsNoTracking().FirstOrDefault(a=>a.Id == id)!;
        }
        catch
        {
            return null!;
        }
    }

    public bool CheckEmailExists(string email)
    {
        try
        {
            return _databaseContext.Accounts.Count(a=>a.Email == email) > 0;
        }
        catch
        {
            return false;
        }
    }
}
