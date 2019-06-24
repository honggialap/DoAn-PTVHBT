using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.TaiKhoans
{
    public class TaiKhoanInput:Entity<int>
    {
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        [Display(Name="Tài khoản")]
        public string TenTaiKhoan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }
        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        [Display(Name = "Nhập lại mật khẩu")]
        public string MatKhau2 { get; set; }
        [Display(Name = "Chức vụ")]
        public int ChucVuID { get; set; }
        [Display(Name = "Tên")]
        public string Ten { get; set; }
        [Display(Name = "Họ")]
        public string Ho { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }
        [Required(ErrorMessage = "vui lòng nhập địa chỉ Email")]
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