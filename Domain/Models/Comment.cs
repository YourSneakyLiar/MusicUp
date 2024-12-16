using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TrackId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Track Track { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
