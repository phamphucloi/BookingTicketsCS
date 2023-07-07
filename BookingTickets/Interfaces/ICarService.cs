using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface ICarService
{
    public bool Add(Car car);
    public bool Update(Car bus);
    public bool Delete(string LicensePlates);
    public dynamic GetByLicensePlates(string LicensePlates);
    public dynamic GetAllCar();
}
