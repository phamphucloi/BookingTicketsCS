using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface ICarService
{
    public bool Add(Car car);
    public bool Update(Car bus);
    public bool Delete(int id);
    public dynamic GetById(int id);


}
