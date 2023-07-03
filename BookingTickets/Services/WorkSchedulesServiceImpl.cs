using BookingTickets.Interfaces;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore.Storage;

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
        return null!;
        //try
        //{
        //    return _databaseContext.WorkSchedules.Where(ws => ws.IdAccount == idAccount).Select(w => new
        //    {
        //        Id = w.Id,
        //        WorkDay = w.WorkDay,
        //        TimeLine = w.IdTimeLineNavigation.Line.Where(t=>t.Id == w.IdTimeLine).Select(t => new
        //        {
        //            Line = t.Line
        //        }),
        //        Freeway = _databaseContext.Freeways.Where(t => t.Id == w.IdFreeway).Select(t => new
        //        {
        //            Begin = _databaseContext.PlaceFroms.Where(pf=>pf.Id == t.IdFrom).Select(pf => new
        //            {
        //                Name = pf.Name
        //            }).FirstOrDefault()!,
        //            Finished = _databaseContext.PlaceTos.Where(pt => pt.Id == t.IdTo).Select(pt => new
        //            {
        //                Name = pt.Name
        //            }).FirstOrDefault()!,
        //        }),
        //        DriverName = w.IdAccountNavigation.FullName
        //    }).ToList()!;
        //}
        //catch
        //{
        //    return null!;
        //}
    }

    public dynamic GetByIdAccount2(int idAccount, string status)
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
                Status = w.Status
            }).ToList()!;
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
