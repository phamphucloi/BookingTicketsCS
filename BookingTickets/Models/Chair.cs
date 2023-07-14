using System;
using System.Collections.Generic;

namespace BookingTickets.Models;

public partial class Chair
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<ChairCar> ChairCars { get; set; } = new List<ChairCar>();
}
