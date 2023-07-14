using System;
using System.Collections.Generic;

namespace BookingTickets.Models;

public partial class ChairCar
{
    public int Id { get; set; }

    public bool? Status { get; set; }

    public int? Price { get; set; }

    public int? IdChair { get; set; }

    public int? IdAccount { get; set; }

    public int? IdTimeLine { get; set; }

    public string? IdCar { get; set; }
    public DateTime? DateBook { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Car? IdCarNavigation { get; set; }

    public virtual Chair? IdChairNavigation { get; set; }

    public virtual TimeLine? IdTimeLineNavigation { get; set; }

    public virtual ICollection<InvoiceDetailCar> InvoiceDetailCars { get; set; } = new List<InvoiceDetailCar>();
}
