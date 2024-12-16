using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Rating
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TrackId { get; set; }

    public int Rating1 { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Track Track { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
