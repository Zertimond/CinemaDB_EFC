using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaDB_EFC.Models;

public partial class Hall
{
    [Key] public int HallId { get; set; }

    [Required] public int CinemaId { get; set; }

    public int HallNumber { get; set; }

    public string Schedule { get; set; }

    public string FilmList { get; set; }

    public int PlaceAmmount { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public virtual ICollection<Show> Shows { get; } = new List<Show>();
}
