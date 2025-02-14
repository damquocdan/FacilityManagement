using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilityManagement.Models​;

public partial class Equipment
{
    [Key]
    public int EquipmentId { get; set; }

    [Display(Name = "Hình ảnh")]
    public string Image { get; set; } = null!;

    [Display(Name = "Tên thiết bị")]
    public string EquipmentName { get; set; } = null!;

    [Display(Name = "Loại thiết bị")]
    public string EquipmentType { get; set; } = null!;

    public int? RoomId { get; set; }

    [Display(Name = "Trạng thái")]
    public string? Status { get; set; }

    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual Room? Room { get; set; }
}