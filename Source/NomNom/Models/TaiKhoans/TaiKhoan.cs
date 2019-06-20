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
        public int ChucVuID { get; set; }
        public string Ten { get; set; }
        public string Ho { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public bool IsBan { get; set; }
        public string Avatar { get; set; }
    }
}