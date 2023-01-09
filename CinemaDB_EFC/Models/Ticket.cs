using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaDB_EFC.Models;

public partial class Ticket
{
    [Key] public int TicketId { get; set; }

    [Required] public int ShowId { get; set; }

    public int Place { get; set; }

    public int Cost { get; set; }

    public virtual Show? Show { get; set; }
}
