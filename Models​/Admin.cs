using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilityManagement.Models​;

public partial class Admin
{
    [Key]
    public int AdminId { get; set; }

    [Display(Name = "Tên quản trị viên")]
    public string AdminName { get; set; } = null!;

    [Display(Name = "Tên đăng nhập")]
    public string Username { get; set; } = null!;

    [Display(Name = "Mật khẩu")]
    public string Password { get; set; } = null!;

    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Số điện thoại")]
    public string Phone { get; set; } = null!;

    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedAt { get; set; }
}