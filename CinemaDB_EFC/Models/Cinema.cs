using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaDB_EFC.Models;

public partial class Cinema
{
    [Key] public int CinemaId { get; set; }

    [Required] [MaxLength(20)] public string? CinemaName { get; set; }

    public int WorkerAmmount { get; set; }

    public virtual ICollection<Hall> Halls { get; } = new List<Hall>();

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
