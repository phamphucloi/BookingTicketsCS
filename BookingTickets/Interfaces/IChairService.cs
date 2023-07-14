using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface IChairService
{
    public bool Add(Chair chair);
    public dynamic GetById(int id);
    public bool Update(Chair chair);
    public bool Delete(int id);
    public dynamic GetAll();
}
