using System;
using System.Collections.Generic;

namespace BookingTickets.Models;

public partial class InvoiceShipping
{
    public int Id { get; set; }

    public string RecipientName { get; set; } = null!;

    public string RecipientPhone { get; set; } = null!;

    public string RecipientAddress { get; set; } = null!;

    public string DeliveryName { get; set; } = null!;

    public string DeliveryPhone { get; set; } = null!;

    public string DeliveryAddress { get; set; } = null!;

    public int IdAccount { get; set; }

    public int IdShipping { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Shipping IdShippingNavigation { get; set; } = null!;
}
