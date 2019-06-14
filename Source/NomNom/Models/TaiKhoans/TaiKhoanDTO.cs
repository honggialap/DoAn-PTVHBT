using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.TaiKhoans
{
    public class TaiKhoanDTO: Entity<int>
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }
}