using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Statistic
{
    public int Id { get; set; }

    public int TrackId { get; set; }

    public int? Listens { get; set; }

    public int? Likes { get; set; }

    public decimal? Donations { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Track Track { get; set; } = null!;
}
