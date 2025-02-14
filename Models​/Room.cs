using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilityManagement.Models​;

public partial class Room
{
    [Key]
    public int RoomId { get; set; }

    [Display(Name = "Tên phòng")]
    public string RoomName { get; set; } = null!;

    public int? BuildingId { get; set; }

    [Display(Name = "Loại phòng")]
    public string RoomType { get; set; } = null!;

    [Display(Name = "Sức chứa")]
    public int Capacity { get; set; }

    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    public virtual Building? Building { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Usage> Usages { get; set; } = new List<Usage>();
}