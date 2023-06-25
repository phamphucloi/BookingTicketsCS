using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface ITimeService
{
    public bool Add(Time time);
    public dynamic GetById(int id);
    public bool Update(Time time);
    public bool Delete(int id);
}
