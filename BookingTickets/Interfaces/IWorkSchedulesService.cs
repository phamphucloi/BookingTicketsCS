using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface IWorkSchedulesService
{
    public bool Add(WorkSchedule ws);
    public dynamic GetById(int id);
    public bool Update(WorkSchedule ws);
    public bool Delete(int id);
    public dynamic GetByIdAccount(int idAccount);
    public dynamic GetByIdAccount2(int idAccount, string status);
    public dynamic GetIdCar(int idAccount);
    public dynamic GetByStatusCompleted(int idAccount, string status);

}
