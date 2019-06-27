using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.ThongTinWebsites
{
    public class ThongTinWebsiteInput : Entity<int>
    {
        [Display(Name="Logo")]
        public string Logo { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Địa chỉ Email")]
        public string Email { get; set; }
        [Display(Name = "Thông tin")]
        public string ThongTin { get; set; }
    }
}