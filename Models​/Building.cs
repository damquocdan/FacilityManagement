﻿using System;
using System.Collections.Generic;

namespace FacilityManagement.Models​;

public partial class Building
{
    public int BuildingId { get; set; }

    public string BuildingName { get; set; } = null!;

    public int? CampusId { get; set; }

    public string? Description { get; set; }

    public virtual Campus? Campus { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
