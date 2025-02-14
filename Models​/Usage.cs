using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilityManagement.Models​;

public partial class Usage
{
    [Key]
    public int UsageId { get; set; }

    public int? RoomId { get; set; }

    [Display(Name = "Người sử dụng")]
    public string? UsedBy { get; set; }

    [Display(Name = "Ngày sử dụng")]
    public DateOnly UsageDate { get; set; }

    [Display(Name = "Mục đích sử dụng")]
    public string? Purpose { get; set; }

    public virtual Room? Room { get; set; }
}