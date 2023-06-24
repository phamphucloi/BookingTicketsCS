using System;
using System.Collections.Generic;

namespace BookingTickets.Models;

public partial class Freeway
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
}
