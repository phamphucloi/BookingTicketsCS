using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface IAccountServive
{
    public bool Add(Account acc);
    public bool Update(Account acc);
    public bool Delete(int id);
    public dynamic GetById(int id);
    public dynamic GetAll();

}
