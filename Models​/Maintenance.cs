using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilityManagement.Models​;

public partial class Maintenance
{
    [Key]
    public int MaintenanceId { get; set; }

    public int? EquipmentId { get; set; }

    [Display(Name = "Ngày báo cáo")]
    public DateOnly MaintenanceDate { get; set; }

    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    [Display(Name = "Trạng thái")]
    public string? Status { get; set; }

    public virtual Equipment? Equipment { get; set; }
}