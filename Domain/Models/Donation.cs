using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Donation
{
    public int Id { get; set; }

    public int ListenerId { get; set; }

    public int MusicianId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Listener Listener { get; set; } = null!;

    public virtual Musician Musician { get; set; } = null!;
}
