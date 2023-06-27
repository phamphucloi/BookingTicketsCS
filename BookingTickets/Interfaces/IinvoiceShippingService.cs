using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface IinvoiceShippingService
{
    public bool Add(InvoiceShipping invoice);
    public dynamic GetById(int id);
    public bool Update(InvoiceShipping invoice);
    public bool Delete(int id);
    public dynamic GetAllInvoice();
}
