using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.PhieuNhaps
{
    [Table("ChiTietPhieuNhaps")]
    public class ChiTietPhieuNhap : BaseModel
    {
        public int PhieuNhapID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public double GiaNhap { get; set; }
    }
    [Table("PhieuNhaps")]
    public class PhieuNhap : BaseModel
    {     
        public DateTime Ngay { get; set; }
        public int NhaCungCapID { get; set; }
        public double TongChi { get; set; }
        public string GhiChu { get; set; }
    }
}