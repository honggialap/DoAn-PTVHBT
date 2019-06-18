using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.PhieuNhaps
{
    public class PhieuNhapDTO: Entity<int>
    {
        public DateTime Ngay { get; set; }
        public int NhaCungCapID { get; set; }
        public double TongChi { get; set; }
        public string GhiChu { get; set; }
        public string NhaCungCapTen { get; set; }
    }
    public class ChiTietPhieuNhapDTO : Entity<int>
    {
        public int PhieuNhapID { get; set; }
        public string SanPhamTen { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public double GiaNhap { get; set; }
    }
}