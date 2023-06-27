using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface IInvoiceCarService
{
    public bool Add(InvoiceCar invoiceCar);
    public bool Update(InvoiceCar invoiceCar);
    public bool Delete(int id);
    public dynamic GetById(int id);
    public dynamic GetAll();

}
