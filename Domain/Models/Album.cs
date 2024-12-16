using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Album
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int ArtistId { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public string? CoverImagePath { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Musician Artist { get; set; } = null!;

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
