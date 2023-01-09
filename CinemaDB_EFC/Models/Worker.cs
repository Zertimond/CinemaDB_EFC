using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaDB_EFC.Models;

public partial class Worker : Person
{

    [Required] public int CinemaId { get; set; }

    public decimal? Salary { get; set; }

    public int? Idcard { get; set; }

    public int? NumberId { get; set; }

    public string Telephone { get; set; }

    public string Adress { get; set; }

    public virtual Cinema? Cinema { get; set; }
}
