using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Globalization;

namespace BookingTickets.Services;

public class WorkSchedulesServiceImpl : IWorkSchedulesService
{
    private readonly DatabaseContext _databaseContext;

    public WorkSchedulesServiceImpl(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(WorkSchedule ws)
    {
        try
        {
            _databaseContext.WorkSchedules.Add(ws);
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
            _databaseContext.WorkSchedules.Remove(_databaseContext.WorkSchedules.FirstOrDefault(ws=>ws.Id == id)!);
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
            return _databaseContext.WorkSchedules.Where(w => w.Id == id).Select(w => new
            {
                Id = w.Id,
                WorkDay = w.WorkDay,
                IdTimeLine = w.IdTimeLine,
                IdFreeway = w.IdFreeway,
                IdAccount = w.IdAccount,
                IdCar = w.IdCar,
                CreateAt = w.CreateAt,
                UpdateAt = w.UpdateAt
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
            var time = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return _databaseContext.WorkSchedules.Where(w => w.WorkDay == time && w.IdAccount == idAccount || w.IdAccount == 2).Select(w => new
            {
                Id = w.Id,
                WorkDay = w.WorkDay,
                TimeLine = w.IdTimeLineNavigation.Line,
                From = w.IdFreewayNavigation.IdFromNavigation.Name,
                To = w.IdFreewayNavigation.IdToNavigation.Name,
                DriverName = w.IdAccountNavigation.FullName,
                Status = w.Status,
                IdAccount = w.IdAccount,
                IdCar = w.IdCar,
                DateNow = time
            }).ToList()!;
        }
        catch
        {
            return null!;
        }
    }

    public dynamic GetByIdAccount2(int idAccount, string status)
    {
        try
        {
            var time = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return _databaseContext.WorkSchedules.Where(w => w.WorkDay == time && w.IdAccount == idAccount && w.Status == status || w.IdAccount == 2).Select(w => new
            {
                Id = w.Id,
                WorkDay = w.WorkDay,
                TimeLine = w.IdTimeLineNavigation.Line,
                From = w.IdFreewayNavigation.IdFromNavigation.Name,
                To = w.IdFreewayNavigation.IdToNavigation.Name,
                DriverName = w.IdAccountNavigation.FullName,
                Status = w.Status,
                IdAccount = w.IdAccount,
                IdCar = w.IdCar,
                DateNow = time
            }).ToList()!;
        }
        catch
        {
            return null!;
        }
    }

    public dynamic GetByStatusCompleted(int idAccount, string status)
    {
        try
        {
            return _databaseContext.WorkSchedules.Where(w => w.IdAccount == idAccount && w.Status == status).Select(w => new
            {
                Id = w.Id,
                WorkDay = w.WorkDay,
                TimeLine = w.IdTimeLineNavigation.Line,
                From = w.IdFreewayNavigation.IdFromNavigation.Name,
                To = w.IdFreewayNavigation.IdToNavigation.Name,
                DriverName = w.IdAccountNavigation.FullName,
                Status = w.Status,
                IdAccount = w.IdAccount,
                IdCar = w.IdCar
            }).ToList()!;
        }
        catch
        {
            return null!;
        }
    }

    public dynamic GetIdCar(int idAccount)
    {
        try
        {
            //return _databaseContext.WorkSchedules.Where(w=>w.IdAccount == idAccount).Select(w => new
            //{

            //}
            return 123;
        }
        catch
        {
            return null!;
        }
    }

    public bool Update(WorkSchedule ws)
    {
        try
        {
            _databaseContext.Update(ws);
            return _databaseContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
