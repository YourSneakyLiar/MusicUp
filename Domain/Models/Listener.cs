using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Listener
{
    public int Id { get; set; }

    public string? Preferences { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Listen> Listens { get; set; } = new List<Listen>();

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
