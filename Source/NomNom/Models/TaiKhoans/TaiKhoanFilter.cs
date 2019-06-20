using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.TaiKhoans
{
    public class TaiKhoanFilter
    {
        public string TenTaiKhoan { get; set; }
        public int ChucVuID { get; set; }
        TaiKhoanFilter()
        {
            TenTaiKhoan = null;
            ChucVuID = 0;
        }
    }
}