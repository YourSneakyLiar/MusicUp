using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Listen
{
    public int Id { get; set; }

    public int ListenerId { get; set; }

    public int TrackId { get; set; }

    public DateTime? ListenedAt { get; set; }

    public virtual Listener Listener { get; set; } = null!;

    public virtual Track Track { get; set; } = null!;
}
