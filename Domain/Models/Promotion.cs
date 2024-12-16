using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Promotion
{
    public int Id { get; set; }

    public int TrackId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Track Track { get; set; } = null!;
}
