using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Playlist
{
    public int Id { get; set; }

    public int ListenerId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Listener Listener { get; set; } = null!;

    public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new List<PlaylistTrack>();
}
