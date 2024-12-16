using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
