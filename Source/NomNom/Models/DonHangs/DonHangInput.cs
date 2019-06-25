using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.DonHangs
{
    public class ChiTietDonHangInput : Entity<int>
    {
        public int DonHangID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public double GiaOrder { get; set; }
    }
    public class DonHangInput: Entity<int>
    {
        public DateTime Ngay { get; set; }
        public int KhachHangID { get; set; }
        public int TinhTrangID { get; set; }
        public double ThanhTien { get; set; }
        [Display(Name = "Tên người nhận")]
        public string TenNguoiNhan { get; set; }
        [Display(Name = "Số điện thoai")]
        public string SoDienThoai { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        public int KhuVucID { get; set; }
        public double PhiShip { get; set; }
        public DateTime NgayGiaoDuKienMin { get; set; }
        public DateTime NgayGiaoDuKienMax { get; set; }
        public List<ChiTietDonHangInput> ChiTiets { get; set; }
    }
}