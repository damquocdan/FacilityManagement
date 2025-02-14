using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilityManagement.Models​;

public partial class Campus
{
    [Key]
    public int CampusId { get; set; }

    [Display(Name = "Tên khu học xá")]
    public string CampusName { get; set; } = null!;

    [Display(Name = "Địa chỉ")]
    public string Address { get; set; } = null!;

    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();
}