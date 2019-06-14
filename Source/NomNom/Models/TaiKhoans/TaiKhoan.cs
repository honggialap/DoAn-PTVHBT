using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.TaiKhoans
{
    public class TaiKhoan: BaseModel
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }
}