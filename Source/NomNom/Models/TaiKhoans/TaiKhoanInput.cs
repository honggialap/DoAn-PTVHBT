using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.TaiKhoans
{
    public class TaiKhoanInput:Entity<int>
    {
        [Display(Name="Tài khoản")]
        public string TenTaiKhoan { get; set; }
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }
        [Display(Name = "Chức vụ")]
        public int ChucVuID { get; set; }
        [Display(Name = "Tên")]
        public string Ten { get; set; }
        [Display(Name = "Họ")]
        public string Ho { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }
        [Display(Name = "Địa chỉ Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "You won't see this")]
        public bool IsBan { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
    }
}