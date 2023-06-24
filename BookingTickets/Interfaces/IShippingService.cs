using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface IShippingService
{
    public bool Add(Shipping shipping);
    public dynamic GetById(int id);
    public bool Update(Shipping discount);
    public bool Delete(int id);
}
