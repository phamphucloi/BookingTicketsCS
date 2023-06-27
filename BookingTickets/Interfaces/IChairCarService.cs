using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface IChairCarService
{
    public dynamic GetAll();
    public bool Create(ChairCar chairCar);
    public bool Update(ChairCar chairCar);
    public bool Delete(int id);
    public dynamic GetById(int id);
}
