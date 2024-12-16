using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Musician
{
    public int Id { get; set; }

    public string? Bio { get; set; }

    public string? DonationAccount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
