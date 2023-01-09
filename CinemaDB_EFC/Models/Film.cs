using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaDB_EFC.Models;

public partial class Film
{
    [Key] public int FilmId { get; set; }

    public string? FilmName { get; set; }

    public TimeSpan? Duration { get; set; }

    public string? FilmType { get; set; }

    public string? Genre { get; set; }

    public string? Actors { get; set; }

    public string? Anagraph { get; set; }

    public virtual ICollection<Show> Shows { get; } = new List<Show>();
}
