
using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface IFreewayService
{
    public bool Add (Freeway freeway);
    public bool Update(Freeway freeway);
    public bool Delete(int id);
    public dynamic GetById(int id);
    public dynamic GetAll();
}
