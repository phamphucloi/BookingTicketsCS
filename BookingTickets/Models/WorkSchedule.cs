using System;
using System.Collections.Generic;

namespace BookingTickets.Models;

public partial class WorkSchedule
{
    public int Id { get; set; }

    public DateTime WorkDay { get; set; }

    public int IdTime { get; set; }

    public int IdFreeway { get; set; }

    public int IdAccount { get; set; }

    public int IdCar { get; set; }

    public DateTime Date { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Car IdCarNavigation { get; set; } = null!;

    public virtual Freeway IdFreewayNavigation { get; set; } = null!;

    public virtual Time IdTimeNavigation { get; set; } = null!;
}
