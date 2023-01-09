using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaDB_EFC.Models;

public partial class Show
{
    [Key] public int ShowId { get; set; }

    [Required] public int FilmId { get; set; }

    [Required] public int HallId { get; set; }

    public TimeSpan StartTime { get; set; }

    public DateTime ShowDate { get; set; }

    public int BoughtTickets { get; set; }

    public virtual Film? Film { get; set; }

    public virtual Hall? Hall { get; set; }

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
