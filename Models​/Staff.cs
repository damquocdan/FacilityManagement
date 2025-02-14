using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilityManagement.Models​;

public partial class Staff
{
    [Key]
    public int StaffId { get; set; }

    [Display(Name = "Tên nhân viên")]
    public string StaffName { get; set; } = null!;

    [Display(Name = "Chức vụ")]
    public string Position { get; set; } = null!;

    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }

    [Display(Name = "Email")]
    public string? Email { get; set; }

    public int? AssignedRoomId { get; set; }

    [Display(Name = "Phòng làm việc")]
    public virtual Room? AssignedRoom { get; set; }
}