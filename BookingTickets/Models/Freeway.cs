using System;
using System.Collections.Generic;

namespace BookingTickets.Models;

public partial class Freeway
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdFrom { get; set; }

    public int? IdTo { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual PlaceFrom? IdFromNavigation { get; set; }

    public virtual PlaceTo? IdToNavigation { get; set; }

    public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
}
