using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilityManagement.Models​;

public partial class Building
{
    [Key]
    public int BuildingId { get; set; }

    [Display(Name = "Tên tòa nhà")]
    public string BuildingName { get; set; } = null!;

    public int? CampusId { get; set; }

    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    public virtual Campus? Campus { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}