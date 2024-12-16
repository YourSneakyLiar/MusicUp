using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Advertisement
{
    public int Id { get; set; }

    public int AdvertiserId { get; set; }

    public string ImagePath { get; set; } = null!;

    public string Link { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User Advertiser { get; set; } = null!;
}
