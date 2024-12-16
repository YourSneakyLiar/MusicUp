using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Track
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int ArtistId { get; set; }

    public int? AlbumId { get; set; }

    public int GenreId { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public string FilePath { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Album? Album { get; set; }

    public virtual Musician Artist { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Listen> Listens { get; set; } = new List<Listen>();

    public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new List<PlaylistTrack>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Statistic> Statistics { get; set; } = new List<Statistic>();
}
