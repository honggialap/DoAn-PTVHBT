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
    }
}