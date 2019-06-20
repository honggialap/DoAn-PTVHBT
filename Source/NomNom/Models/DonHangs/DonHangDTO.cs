using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.DonHangs
{
    public class DonHangDTO: Entity<int>
    {
        public DateTime Ngay { get; set; }
        public int KhachHangID { get; set; }
        public string KhachHangTen { get; set; }
        public int TinhTrangID { get; set; }
        public string TinhTrangTen { get; set; }
        public double ThanhTien { get; set; }
        public string TenNguoiNhan { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public int KhuVucID { get; set; }
        public string KhuVucTen { get; set; }
        public double PhiShip { get; set; }
        public DateTime NgayGiaoDuKienMin { get; set; }
        public DateTime NgayGiaoDuKienMax { get; set; }
        public DateTime? NgayHoanTat { get; set; }
    }
    public class ChiTietDonHangDTO: Entity<int>
    {
        public int DonHangID { get; set; }
        public int SanPhamID { get; set; }
        public string SanPhamTen { get; set; }
        public string SanPhamHinhAnh { get; set; }
        public int SoLuong { get; set; }
        public double GiaOrder { get; set; }
    }
}