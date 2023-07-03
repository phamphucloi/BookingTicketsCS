using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface ITimeService
{
    public bool Add(TimeLine time);
    public dynamic GetById(int id);
    public bool Update(TimeLine time);
    public bool Delete(int id);
}
